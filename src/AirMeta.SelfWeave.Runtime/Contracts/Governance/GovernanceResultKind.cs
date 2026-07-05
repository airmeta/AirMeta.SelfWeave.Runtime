namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示治理处理结果类型。</para>
/// <para>en-us: Represents governance result kinds.</para>
/// </summary>
public enum GovernanceResultKind
{
    /// <summary>
    /// <para>zh-cn: 等待治理处理。</para>
    /// <para>en-us: Pending governance processing.</para>
    /// </summary>
    Pending,
    /// <summary>
    /// <para>zh-cn: 治理已批准。</para>
    /// <para>en-us: Governance approved.</para>
    /// </summary>
    Approved,
    /// <summary>
    /// <para>zh-cn: 治理已拒绝。</para>
    /// <para>en-us: Governance rejected.</para>
    /// </summary>
    Rejected,
    /// <summary>
    /// <para>zh-cn: 需要人工确认。</para>
    /// <para>en-us: Manual confirmation is required.</para>
    /// </summary>
    ManualConfirmationRequired,
    /// <summary>
    /// <para>zh-cn: 需要提升保护校验。</para>
    /// <para>en-us: Promote-guard validation is required.</para>
    /// </summary>
    PromoteGuardRequired,
    /// <summary>
    /// <para>zh-cn: 已应用降级路径。</para>
    /// <para>en-us: Fallback has been applied.</para>
    /// </summary>
    FallbackApplied
}
