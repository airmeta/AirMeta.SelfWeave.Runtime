namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 描述引擎可提供的契约能力、版本和运行边界；Describes the contract capability, versions, and runtime limits exposed by an engine.
/// </summary>
/// <param name="EngineId">引擎唯一标识；The unique engine identifier.</param>
/// <param name="EngineName">引擎显示名称；The human-readable engine name.</param>
/// <param name="EngineVersion">引擎实现版本；The engine implementation version.</param>
/// <param name="ContractVersion">引擎遵循的运行时契约版本；The runtime contract version implemented by the engine.</param>
/// <param name="SupportedContracts">引擎支持的契约类型集合；The contract kinds supported by the engine.</param>
/// <param name="SupportedSnapshotVersions">引擎可读取的快照版本集合；The snapshot versions the engine can read.</param>
/// <param name="SupportedDecisionVersions">引擎可输出的决策版本集合；The decision versions the engine can emit.</param>
/// <param name="MaxExecutionTime">引擎声明的最长执行时间；The maximum execution time declared by the engine.</param>
/// <param name="FallbackRequired">是否要求运行时准备降级路径；Whether the runtime must prepare a fallback path.</param>
/// <param name="DeterminismLevel">引擎输出的确定性等级；The determinism level of engine output.</param>
/// <param name="TraceDisclosureLevel">引擎允许公开的追踪披露等级；The trace disclosure level allowed by the engine.</param>
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
