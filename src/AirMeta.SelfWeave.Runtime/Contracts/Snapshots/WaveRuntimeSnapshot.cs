namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示波传播计算所需的初始节点、轮次、能量和权重快照；Represents initial nodes, rounds, energy, and weights needed for wave propagation.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
/// <param name="InitialNodeRefs">初始激活节点引用集合；Initial activated node references.</param>
/// <param name="MaxRounds">最大传播轮次；The maximum propagation rounds.</param>
/// <param name="InitialEnergy">初始传播能量；The initial propagation energy.</param>
/// <param name="RuntimeWeights">运行时权重字典；Runtime weight dictionary.</param>
public sealed record WaveRuntimeSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<string> InitialNodeRefs,
    int MaxRounds,
    decimal InitialEnergy,
    IReadOnlyDictionary<string, decimal> RuntimeWeights)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);
