namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时传递给引擎的上下文快照；Represents a runtime context snapshot passed to an engine.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
/// <param name="ContextId">上下文标识；The context identifier.</param>
/// <param name="ReferenceIds">公开引用标识集合；The public reference identifiers.</param>
/// <param name="Metadata">公开上下文元数据；The public context metadata.</param>
public sealed record RuntimeContextSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string ContextId,
    IReadOnlyList<string> ReferenceIds,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);
