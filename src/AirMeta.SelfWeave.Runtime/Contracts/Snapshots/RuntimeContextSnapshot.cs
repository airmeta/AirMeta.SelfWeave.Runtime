namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时传递给引擎的上下文快照。</para>
/// <para>en-us: Represents a runtime context snapshot passed to an engine.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="ContextId">
/// <para>zh-cn: 上下文标识 参数。</para>
/// <para>en-us: The context id parameter.</para>
/// </param>
/// <param name="ReferenceIds">
/// <para>zh-cn: ReferenceIds 参数。</para>
/// <para>en-us: The reference ids parameter.</para>
/// </param>
/// <param name="Metadata">
/// <para>zh-cn: 公开元数据。</para>
/// <para>en-us: The public metadata.</para>
/// </param>
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
