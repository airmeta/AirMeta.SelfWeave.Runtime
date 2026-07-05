namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 描述引擎可提供的契约能力、版本和运行边界。</para>
/// <para>en-us: Describes the contract capability, versions, and runtime limits exposed by an engine.</para>
/// </summary>
/// <param name="EngineId">
/// <para>zh-cn: 引擎标识 参数。</para>
/// <para>en-us: The engine id parameter.</para>
/// </param>
/// <param name="EngineName">
/// <para>zh-cn: 引擎名称 参数。</para>
/// <para>en-us: The engine name parameter.</para>
/// </param>
/// <param name="EngineVersion">
/// <para>zh-cn: 引擎版本 参数。</para>
/// <para>en-us: The engine version parameter.</para>
/// </param>
/// <param name="ContractVersion">
/// <para>zh-cn: 契约版本 参数。</para>
/// <para>en-us: The contract version parameter.</para>
/// </param>
/// <param name="SupportedContracts">
/// <para>zh-cn: 支持Contracts 参数。</para>
/// <para>en-us: The supported contracts parameter.</para>
/// </param>
/// <param name="SupportedSnapshotVersions">
/// <para>zh-cn: 支持快照Versions 参数。</para>
/// <para>en-us: The supported snapshot versions parameter.</para>
/// </param>
/// <param name="SupportedDecisionVersions">
/// <para>zh-cn: 支持DecisionVersions 参数。</para>
/// <para>en-us: The supported decision versions parameter.</para>
/// </param>
/// <param name="MaxExecutionTime">
/// <para>zh-cn: 最大执行时间 参数。</para>
/// <para>en-us: The max execution time parameter.</para>
/// </param>
/// <param name="FallbackRequired">
/// <para>zh-cn: 降级要求 参数。</para>
/// <para>en-us: The fallback required parameter.</para>
/// </param>
/// <param name="DeterminismLevel">
/// <para>zh-cn: 确定性等级 参数。</para>
/// <para>en-us: The determinism level parameter.</para>
/// </param>
/// <param name="TraceDisclosureLevel">
/// <para>zh-cn: 追踪披露等级 参数。</para>
/// <para>en-us: The trace disclosure level parameter.</para>
/// </param>
public sealed record EngineCapability(
    string EngineId,
    string EngineName,
    string EngineVersion,
    string ContractVersion,
    IReadOnlyList<RuntimeContractKind> SupportedContracts,
    IReadOnlyList<string> SupportedSnapshotVersions,
    IReadOnlyList<string> SupportedDecisionVersions,
    TimeSpan MaxExecutionTime,
    bool FallbackRequired,
    DeterminismLevel DeterminismLevel,
    TraceDisclosureLevel TraceDisclosureLevel);
