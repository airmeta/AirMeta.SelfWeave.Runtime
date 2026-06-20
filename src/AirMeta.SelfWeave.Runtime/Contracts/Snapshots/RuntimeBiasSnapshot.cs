namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时偏置决策所需的偏置信号和原因码；Represents bias signals and reason codes needed for runtime bias decisions.
/// </summary>
/// <param name="SnapshotId">快照唯一标识；The unique snapshot identifier.</param>
/// <param name="SnapshotVersion">快照契约版本；The snapshot contract version.</param>
/// <param name="SnapshotHash">快照内容哈希；The snapshot content hash.</param>
/// <param name="Provenance">快照来源说明；The snapshot provenance.</param>
/// <param name="CreatedAt">快照创建时间；The snapshot creation time.</param>
/// <param name="BiasSignals">偏置信号字典；Bias signal dictionary.</param>
/// <param name="BiasReasonCodes">偏置原因码集合；Bias reason codes.</param>
public sealed record RuntimeBiasSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<string, decimal> BiasSignals,
    IReadOnlyList<string> BiasReasonCodes)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);
