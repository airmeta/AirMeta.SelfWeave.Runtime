namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示投影决策所需的输入摘要、候选节点、候选关系和上下文引用；Represents projection input digest, candidate nodes, candidate relations, and context references.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
/// <param name="InputDigest">输入内容摘要；The digest of the input content.</param>
/// <param name="CandidateNodeRefs">候选节点引用集合；Candidate node references.</param>
/// <param name="CandidateRelationRefs">候选关系引用集合；Candidate relation references.</param>
/// <param name="ContextRefs">上下文引用字典；Context reference dictionary.</param>
public sealed record ProjectionInputSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    IReadOnlyList<string> CandidateNodeRefs,
    IReadOnlyList<string> CandidateRelationRefs,
    IReadOnlyDictionary<string, string> ContextRefs)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);
