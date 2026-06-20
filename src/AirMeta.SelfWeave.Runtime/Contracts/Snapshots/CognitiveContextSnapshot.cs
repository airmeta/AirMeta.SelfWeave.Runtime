namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示当前认知循环、交互、记忆、目标和状态因子的上下文快照；Represents context for the current cognitive cycle, interaction, memory, goals, and state factors.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
/// <param name="CycleId">认知循环标识；The cognitive cycle identifier.</param>
/// <param name="InteractionEventId">交互事件标识；The interaction event identifier.</param>
/// <param name="MemoryRefs">相关记忆引用集合；Related memory references.</param>
/// <param name="ActiveGoalRefs">活跃目标引用集合；Active goal references.</param>
/// <param name="StateFactors">运行时状态因子；Runtime state factors.</param>
public sealed record CognitiveContextSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string CycleId,
    string InteractionEventId,
    IReadOnlyList<string> MemoryRefs,
    IReadOnlyList<string> ActiveGoalRefs,
    IReadOnlyDictionary<string, decimal> StateFactors)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);
