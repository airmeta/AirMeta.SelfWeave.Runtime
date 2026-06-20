namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示可公开审计的运行时追踪记录；Represents a publicly auditable runtime trace record.
/// </summary>
/// <param name="TraceId">追踪唯一标识；The unique trace identifier.</param>
/// <param name="CycleId">认知循环标识；The cognitive cycle identifier.</param>
/// <param name="Identity">生成输出的引擎和契约身份；The engine and contract identity that produced the output.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="DecisionId">关联决策标识；The related decision identifier.</param>
/// <param name="AuditRefs">审计引用集合；The audit references.</param>
/// <param name="GovernanceFlags">治理控制标记；Governance control flags.</param>
/// <param name="GovernanceResult">治理处理结果；The governance processing result.</param>
/// <param name="FallbackUsed">是否使用降级路径；Whether fallback was used.</param>
/// <param name="CreatedAt">追踪创建时间；The trace creation time.</param>
public sealed record RuntimeTrace(
    string TraceId,
    string CycleId,
    RuntimeContractIdentity Identity,
    string InputSnapshotHash,
    string DecisionId,
    IReadOnlyList<string> AuditRefs,
    RuntimeGovernanceFlags GovernanceFlags,
    GovernanceResult GovernanceResult,
    bool FallbackUsed,
    DateTimeOffset CreatedAt);
