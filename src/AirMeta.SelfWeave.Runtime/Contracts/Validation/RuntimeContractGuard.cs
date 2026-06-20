using System.Text.Json;
using System.Text.Json.Serialization;

namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 提供运行时契约输出、追踪、插件握手和依赖边界校验；Provides validation for runtime contract output, traces, plugin handshakes, and dependency boundaries.
/// </summary>
public static class RuntimeContractGuard
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() },
        WriteIndented = false
    };

    private static readonly string[] ForbiddenEngineOutputProperties =
    [
        "executed",
        "persisted",
        "governance_bypassed",
        "manual_confirmation_bypassed",
        "stable_state_mutated"
    ];

    private static readonly string[] ForbiddenTraceProperties =
    [
        "private_parameters",
        "internal_test_vectors",
        "private_samples",
        "secret",
        "connection_string",
        "api_key"
    ];

    /// <summary>
    /// 获取默认运行时契约依赖边界；Gets the default dependency boundary for runtime contracts.
    /// </summary>
    public static RuntimeDependencyBoundary DefaultDependencyBoundary { get; } = new(
        ["System", "Microsoft.CSharp", "AirMeta.SelfWeave.Runtime"],
        ["Air.Cloud", "EntityFramework", "Npgsql", "Dapper", "SqlSugar"],
        [
            "Microsoft.EntityFrameworkCore",
            "System.Data",
            "Air.Cloud",
            "AirMeta.SelfWeave.Repository",
            "AirMeta.SelfWeave.Domain",
            "AirMeta.SelfWeave.Service",
            "AirMeta.SelfWeave.Entry"
        ]);

    /// <summary>
    /// 校验引擎决策是否满足治理和输出边界；Validates whether an engine decision satisfies governance and output boundaries.
    /// </summary>
    /// <param name="decision">待校验的引擎决策；The engine decision to validate.</param>
    /// <returns>违规原因码集合；The validation violation reason codes.</returns>
    public static IReadOnlyList<string> ValidateDecision(EngineDecision decision)
    {
        var violations = ValidateEngineOutput(decision).ToList();

        if (!decision.GovernanceFlags.RequiresGovernanceReview)
        {
            violations.Add("requires_governance_review_must_default_to_true");
        }

        if (!decision.GovernanceFlags.TraceRequired)
        {
            violations.Add("trace_required_must_default_to_true");
        }

        return violations;
    }

    /// <summary>
    /// 校验引擎建议是否满足治理和状态保护边界；Validates whether an engine proposal satisfies governance and state-guard boundaries.
    /// </summary>
    /// <param name="proposal">待校验的引擎建议；The engine proposal to validate.</param>
    /// <returns>违规原因码集合；The validation violation reason codes.</returns>
    public static IReadOnlyList<string> ValidateProposal(EngineProposal proposal)
    {
        var violations = ValidateEngineOutput(proposal).ToList();

        if (proposal.GovernanceFlags.AffectsStableState)
        {
            if (!proposal.GovernanceFlags.RequiresGovernanceReview || !proposal.GovernanceFlags.RequiresStateGuard)
            {
                violations.Add("stable_state_requires_governance_and_state_guard");
            }
        }

        return violations;
    }

    /// <summary>
    /// 校验追踪记录是否泄露禁止公开的信息；Validates whether a trace record discloses forbidden information.
    /// </summary>
    /// <param name="trace">待校验的追踪记录；The trace record to validate.</param>
    /// <returns>违规原因码集合；The validation violation reason codes.</returns>
    public static IReadOnlyList<string> ValidateTrace(RuntimeTrace trace)
    {
        var json = JsonSerializer.Serialize(trace, JsonOptions);
        return ForbiddenTraceProperties
            .Where(property => json.Contains(property, StringComparison.OrdinalIgnoreCase))
            .Select(property => $"trace_contains_forbidden_property:{property}")
            .ToArray();
    }

    /// <summary>
    /// 校验插件握手是否遵守运行时治理和身份边界；Validates whether a plugin handshake follows runtime governance and identity boundaries.
    /// </summary>
    /// <param name="handshake">待校验的插件握手；The plugin handshake to validate.</param>
    /// <returns>违规原因码集合；The validation violation reason codes.</returns>
    public static IReadOnlyList<string> ValidatePluginHandshake(EnginePluginHandshake handshake)
    {
        var violations = new List<string>();

        if (!handshake.TraceIdentityRequired)
        {
            violations.Add("plugin_trace_identity_required_must_be_true");
        }

        if (handshake.MayReplaceRuntimeGovernance)
        {
            violations.Add("plugin_must_not_replace_runtime_governance");
        }

        if (!string.Equals(
                handshake.Manifest.Capability.EngineId,
                handshake.ActualEngineIdentity.EngineId,
                StringComparison.Ordinal))
        {
            violations.Add("plugin_actual_engine_identity_mismatch");
        }

        if (handshake.Manifest.ExecutionTimeout <= TimeSpan.Zero)
        {
            violations.Add("plugin_execution_timeout_required");
        }

        return violations;
    }

    /// <summary>
    /// 校验程序集和命名空间依赖是否越过运行时契约边界；Validates whether assembly and namespace dependencies cross runtime contract boundaries.
    /// </summary>
    /// <param name="assemblyNames">待校验的程序集名称集合；The assembly names to validate.</param>
    /// <param name="namespaceNames">待校验的命名空间集合；The namespace names to validate.</param>
    /// <param name="boundary">可选的依赖边界；The optional dependency boundary.</param>
    /// <returns>违规原因码集合；The validation violation reason codes.</returns>
    public static IReadOnlyList<string> ValidateDependencyBoundary(
        IEnumerable<string> assemblyNames,
        IEnumerable<string> namespaceNames,
        RuntimeDependencyBoundary? boundary = null)
    {
        boundary ??= DefaultDependencyBoundary;
        var violations = new List<string>();

        foreach (var assemblyName in assemblyNames)
        {
            if (boundary.ForbiddenAssemblyNamePrefixes.Any(prefix =>
                    assemblyName.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)))
            {
                violations.Add($"forbidden_assembly_dependency:{assemblyName}");
            }
        }

        foreach (var namespaceName in namespaceNames)
        {
            if (boundary.ForbiddenNamespacePrefixes.Any(prefix =>
                    namespaceName.StartsWith(prefix, StringComparison.Ordinal)))
            {
                violations.Add($"forbidden_namespace_dependency:{namespaceName}");
            }
        }

        return violations;
    }

    /// <summary>
    /// 使用运行时契约 JSON 设置序列化契约对象；Serializes a contract object with runtime contract JSON settings.
    /// </summary>
    /// <typeparam name="TContract">契约对象类型；The contract object type.</typeparam>
    /// <param name="contract">待序列化的契约对象；The contract object to serialize.</param>
    /// <returns>序列化后的 JSON 字符串；The serialized JSON string.</returns>
    public static string SerializeContract<TContract>(TContract contract)
    {
        return JsonSerializer.Serialize(contract, JsonOptions);
    }

    /// <summary>
    /// 使用运行时契约 JSON 设置反序列化契约对象；Deserializes a contract object with runtime contract JSON settings.
    /// </summary>
    /// <typeparam name="TContract">契约对象类型；The contract object type.</typeparam>
    /// <param name="json">待反序列化的 JSON 字符串；The JSON string to deserialize.</param>
    /// <returns>反序列化后的契约对象，失败时为空；The deserialized contract object, or null when deserialization fails.</returns>
    public static TContract? DeserializeContract<TContract>(string json)
    {
        return JsonSerializer.Deserialize<TContract>(json, JsonOptions);
    }

    /// <summary>
    /// 校验引擎输出 JSON 中是否包含禁止字段；Validates whether engine output JSON contains forbidden fields.
    /// </summary>
    /// <typeparam name="TOutput">引擎输出类型；The engine output type.</typeparam>
    /// <param name="output">待校验的引擎输出；The engine output to validate.</param>
    /// <returns>违规原因码序列；The validation violation reason code sequence.</returns>
    private static IEnumerable<string> ValidateEngineOutput<TOutput>(TOutput output)
    {
        var json = JsonSerializer.Serialize(output, JsonOptions);
        foreach (var property in ForbiddenEngineOutputProperties)
        {
            if (json.Contains(property, StringComparison.OrdinalIgnoreCase))
            {
                yield return $"engine_output_contains_forbidden_property:{property}";
            }
        }
    }
}
