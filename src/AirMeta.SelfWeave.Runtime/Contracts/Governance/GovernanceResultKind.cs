namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示治理处理结果类型；Represents governance result kinds.
/// </summary>
public enum GovernanceResultKind
{
    /// <summary>等待治理处理；Pending governance processing.</summary>
    Pending,
    /// <summary>治理已批准；Governance approved.</summary>
    Approved,
    /// <summary>治理已拒绝；Governance rejected.</summary>
    Rejected,
    /// <summary>需要人工确认；Manual confirmation is required.</summary>
    ManualConfirmationRequired,
    /// <summary>需要提升保护校验；Promote-guard validation is required.</summary>
    PromoteGuardRequired,
    /// <summary>已应用降级路径；Fallback has been applied.</summary>
    FallbackApplied
}
