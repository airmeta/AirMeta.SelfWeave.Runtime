namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时追踪可披露的等级；Represents the allowed trace disclosure level.
/// </summary>
public enum TraceDisclosureLevel
{
    /// <summary>仅公开摘要；Public summary only.</summary>
    PublicSummary,
    /// <summary>可公开审计信息；Public audit information is allowed.</summary>
    PublicAudit,
    /// <summary>披露受限；Disclosure is restricted.</summary>
    Restricted
}
