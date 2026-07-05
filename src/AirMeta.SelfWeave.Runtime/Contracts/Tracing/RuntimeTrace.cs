namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示可公开审计的运行时追踪记录。</para>
/// <para>en-us: Represents a publicly auditable runtime trace record.</para>
/// </summary>
/// <param name="TraceId">
/// <para>zh-cn: 追踪标识 参数。</para>
/// <para>en-us: The trace id parameter.</para>
/// </param>
/// <param name="CycleId">
/// <para>zh-cn: 循环标识 参数。</para>
/// <para>en-us: The cycle id parameter.</para>
/// </param>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="AuditRefs">
/// <para>zh-cn: 审计引用集合 参数。</para>
/// <para>en-us: The audit refs parameter.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="GovernanceResult">
/// <para>zh-cn: 治理结果 参数。</para>
/// <para>en-us: The governance result parameter.</para>
/// </param>
/// <param name="FallbackUsed">
/// <para>zh-cn: 降级已使用 参数。</para>
/// <para>en-us: The fallback used parameter.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
public sealed record RuntimeTrace(
    string TraceId,
    string CycleId,
    RuntimeContractIdentity Identity,
    string InputSnapshotHash,
    string DecisionId,
    IReadOnlyList<string> AuditRefs,
    RuntimeGovernanceFlags GovernanceFlags,
    GovernanceResult GovernanceResult,
    bool FallbackUsed,
    DateTimeOffset CreatedAt);
