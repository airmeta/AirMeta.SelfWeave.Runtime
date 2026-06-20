namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示引擎可读取的拓扑子图快照；Represents a topology subgraph snapshot readable by an engine.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
/// <param name="Nodes">子图节点引用集合；Subgraph node references.</param>
/// <param name="Edges">子图边引用集合；Subgraph edge references.</param>
public sealed record TopologySubgraphSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<TopologyNodeRef> Nodes,
    IReadOnlyList<TopologyEdgeRef> Edges)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);
