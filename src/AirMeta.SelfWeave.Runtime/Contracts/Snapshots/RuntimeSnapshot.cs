namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时传递给引擎的不可变快照基类；Represents the base immutable snapshot passed from runtime to engine.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
public abstract record RuntimeSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt);
