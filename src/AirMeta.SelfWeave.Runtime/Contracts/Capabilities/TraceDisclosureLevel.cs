namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时追踪可披露的等级。</para>
/// <para>en-us: Represents the allowed trace disclosure level.</para>
/// </summary>
public enum TraceDisclosureLevel
{
    /// <summary>
    /// <para>zh-cn: 仅公开摘要。</para>
    /// <para>en-us: Public summary only.</para>
    /// </summary>
    PublicSummary,
    /// <summary>
    /// <para>zh-cn: 可公开审计信息。</para>
    /// <para>en-us: Public audit information is allowed.</para>
    /// </summary>
    PublicAudit,
    /// <summary>
    /// <para>zh-cn: 披露受限。</para>
    /// <para>en-us: Disclosure is restricted.</para>
    /// </summary>
    Restricted
}
