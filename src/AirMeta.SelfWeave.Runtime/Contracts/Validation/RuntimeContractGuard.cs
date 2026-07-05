using System.Text.Json;
using System.Text.Json.Serialization;

namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 提供运行时契约输出、追踪、插件握手和依赖边界校验。</para>
/// <para>en-us: Provides validation for runtime contract output, traces, plugin handshakes, and dependency boundaries.</para>
/// </summary>
public static class RuntimeContractGuard
{
    /// <summary>
    /// <para>zh-cn: 运行时契约 JSON 序列化设置。</para>
    /// <para>en-us: Runtime contract JSON serialization settings.</para>
    /// </summary>
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() },
        WriteIndented = false
    };

    /// <summary>
    /// <para>zh-cn: 引擎输出中禁止出现的字段名称集合。</para>
    /// <para>en-us: Field names forbidden in engine output.</para>
    /// </summary>
    private static readonly string[] ForbiddenEngineOutputProperties =
    [
        "executed",
        "persisted",
        "governance_bypassed",
        "manual_confirmation_bypassed",
        "stable_state_mutated"
    ];

    /// <summary>
    /// <para>zh-cn: 公开追踪记录中禁止出现的字段名称集合。</para>
    /// <para>en-us: Field names forbidden in public trace records.</para>
    /// </summary>
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
    /// <para>zh-cn: 获取默认运行时契约依赖边界。</para>
    /// <para>en-us: Gets the default dependency boundary for runtime contracts.</para>
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
    /// <para>zh-cn: 校验引擎决策是否满足治理和输出边界。</para>
    /// <para>en-us: Validates whether an engine decision satisfies governance and output boundaries.</para>
    /// </summary>
    /// <param name="decision">
    /// <para>zh-cn: 待校验的引擎决策。</para>
    /// <para>en-us: The engine decision to validate.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 违规原因码集合。</para>
    /// <para>en-us: The validation violation reason codes.</para>
    /// </returns>
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
    /// <para>zh-cn: 校验引擎建议是否满足治理和状态保护边界。</para>
    /// <para>en-us: Validates whether an engine proposal satisfies governance and state-guard boundaries.</para>
    /// </summary>
    /// <param name="proposal">
    /// <para>zh-cn: 待校验的引擎建议。</para>
    /// <para>en-us: The engine proposal to validate.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 违规原因码集合。</para>
    /// <para>en-us: The validation violation reason codes.</para>
    /// </returns>
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
    /// <para>zh-cn: 校验追踪记录是否泄露禁止公开的信息。</para>
    /// <para>en-us: Validates whether a trace record discloses forbidden information.</para>
    /// </summary>
    /// <param name="trace">
    /// <para>zh-cn: 待校验的追踪记录。</para>
    /// <para>en-us: The trace record to validate.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 违规原因码集合。</para>
    /// <para>en-us: The validation violation reason codes.</para>
    /// </returns>
    public static IReadOnlyList<string> ValidateTrace(RuntimeTrace trace)
    {
        var json = JsonSerializer.Serialize(trace, JsonOptions);
        return ForbiddenTraceProperties
            .Where(property => json.Contains(property, StringComparison.OrdinalIgnoreCase))
            .Select(property => $"trace_contains_forbidden_property:{property}")
            .ToArray();
    }

    /// <summary>
    /// <para>zh-cn: 校验插件握手是否遵守运行时治理和身份边界。</para>
    /// <para>en-us: Validates whether a plugin handshake follows runtime governance and identity boundaries.</para>
    /// </summary>
    /// <param name="handshake">
    /// <para>zh-cn: 待校验的插件握手。</para>
    /// <para>en-us: The plugin handshake to validate.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 违规原因码集合。</para>
    /// <para>en-us: The validation violation reason codes.</para>
    /// </returns>
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
    /// <para>zh-cn: 校验程序集和命名空间依赖是否越过运行时契约边界。</para>
    /// <para>en-us: Validates whether assembly and namespace dependencies cross runtime contract boundaries.</para>
    /// </summary>
    /// <param name="assemblyNames">
    /// <para>zh-cn: 待校验的程序集名称集合。</para>
    /// <para>en-us: The assembly names to validate.</para>
    /// </param>
    /// <param name="namespaceNames">
    /// <para>zh-cn: 待校验的命名空间集合。</para>
    /// <para>en-us: The namespace names to validate.</para>
    /// </param>
    /// <param name="boundary">
    /// <para>zh-cn: 可选的依赖边界。</para>
    /// <para>en-us: The optional dependency boundary.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 违规原因码集合。</para>
    /// <para>en-us: The validation violation reason codes.</para>
    /// </returns>
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
    /// <para>zh-cn: 使用运行时契约 JSON 设置序列化契约对象。</para>
    /// <para>en-us: Serializes a contract object with runtime contract JSON settings.</para>
    /// </summary>
    /// <typeparam name="TContract">
    /// <para>zh-cn: 契约对象类型。</para>
    /// <para>en-us: The contract object type.</para>
    /// </typeparam>
    /// <param name="contract">
    /// <para>zh-cn: 待序列化的契约对象。</para>
    /// <para>en-us: The contract object to serialize.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 序列化后的 JSON 字符串。</para>
    /// <para>en-us: The serialized JSON string.</para>
    /// </returns>
    public static string SerializeContract<TContract>(TContract contract)
    {
        return JsonSerializer.Serialize(contract, JsonOptions);
    }

    /// <summary>
    /// <para>zh-cn: 使用运行时契约 JSON 设置反序列化契约对象。</para>
    /// <para>en-us: Deserializes a contract object with runtime contract JSON settings.</para>
    /// </summary>
    /// <typeparam name="TContract">
    /// <para>zh-cn: 契约对象类型。</para>
    /// <para>en-us: The contract object type.</para>
    /// </typeparam>
    /// <param name="json">
    /// <para>zh-cn: 待反序列化的 JSON 字符串。</para>
    /// <para>en-us: The JSON string to deserialize.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 反序列化后的契约对象，失败时为空。</para>
    /// <para>en-us: The deserialized contract object, or null when deserialization fails.</para>
    /// </returns>
    public static TContract? DeserializeContract<TContract>(string json)
    {
        return JsonSerializer.Deserialize<TContract>(json, JsonOptions);
    }

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
