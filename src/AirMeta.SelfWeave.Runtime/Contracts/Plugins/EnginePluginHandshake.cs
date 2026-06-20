namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时和引擎插件之间的握手结果；Represents the handshake result between the runtime and an engine plugin.
/// </summary>
/// <param name="Manifest">插件清单；The plugin manifest.</param>
/// <param name="Compatibility">兼容性评估结果；The compatibility evaluation result.</param>
/// <param name="ActualEngineIdentity">插件实际返回的引擎身份；The actual engine identity returned by the plugin.</param>
/// <param name="TraceIdentityRequired">是否要求追踪中保留真实身份；Whether trace records must keep the actual identity.</param>
/// <param name="MayReplaceRuntimeGovernance">插件是否声称可替代运行时治理；Whether the plugin claims it may replace runtime governance.</param>
public sealed record EnginePluginHandshake(
    EnginePluginManifest Manifest,
    CompatibilityResult Compatibility,
    RuntimeContractIdentity ActualEngineIdentity,
    bool TraceIdentityRequired = true,
    bool MayReplaceRuntimeGovernance = false);
