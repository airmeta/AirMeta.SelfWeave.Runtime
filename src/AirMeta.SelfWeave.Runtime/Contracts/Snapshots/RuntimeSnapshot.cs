namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时传递给引擎的不可变快照基类。</para>
/// <para>en-us: Represents the base immutable snapshot passed from runtime to engine.</para>
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
public abstract record RuntimeSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt);
