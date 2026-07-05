namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时和引擎插件之间的握手结果。</para>
/// <para>en-us: Represents the handshake result between the runtime and an engine plugin.</para>
/// </summary>
/// <param name="Manifest">
/// <para>zh-cn: 清单 参数。</para>
/// <para>en-us: The manifest parameter.</para>
/// </param>
/// <param name="Compatibility">
/// <para>zh-cn: Compatibility 参数。</para>
/// <para>en-us: The compatibility parameter.</para>
/// </param>
/// <param name="ActualEngineIdentity">
/// <para>zh-cn: 实际引擎身份 参数。</para>
/// <para>en-us: The actual engine identity parameter.</para>
/// </param>
/// <param name="TraceIdentityRequired">
/// <para>zh-cn: 追踪身份要求 参数。</para>
/// <para>en-us: The trace identity required parameter.</para>
/// </param>
/// <param name="MayReplaceRuntimeGovernance">
/// <para>zh-cn: 可以替代运行时治理 参数。</para>
/// <para>en-us: The may replace runtime governance parameter.</para>
/// </param>
public sealed record EnginePluginHandshake(
    EnginePluginManifest Manifest,
    CompatibilityResult Compatibility,
    RuntimeContractIdentity ActualEngineIdentity,
    bool TraceIdentityRequired = true,
    bool MayReplaceRuntimeGovernance = false);
