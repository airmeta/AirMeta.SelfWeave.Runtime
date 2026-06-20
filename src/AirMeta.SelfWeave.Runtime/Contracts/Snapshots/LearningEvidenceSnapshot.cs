namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示学习可塑性判断所需的证据集合和最低质量门槛；Represents evidence and minimum quality gates needed for learning plasticity.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
/// <param name="EvidenceRefs">学习证据引用集合；Learning evidence references.</param>
/// <param name="MinimumEvidenceStrength">最低证据强度；The minimum evidence strength.</param>
/// <param name="MinimumEvidenceCount">最低证据数量；The minimum evidence count.</param>
public sealed record LearningEvidenceSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<LearningEvidenceRef> EvidenceRefs,
    decimal MinimumEvidenceStrength,
    int MinimumEvidenceCount)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);
