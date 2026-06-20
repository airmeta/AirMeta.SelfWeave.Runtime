namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时和引擎之间的兼容性状态；Represents compatibility status between runtime and engine.
/// </summary>
public enum CompatibilityStatus
{
    /// <summary>完全兼容；Fully compatible.</summary>
    Compatible,
    /// <summary>契约类型不兼容；The contract kind is incompatible.</summary>
    IncompatibleContract,
    /// <summary>快照版本不受支持；The snapshot version is unsupported.</summary>
    UnsupportedSnapshot,
    /// <summary>决策版本不受支持；The decision version is unsupported.</summary>
    UnsupportedDecision,
    /// <summary>执行超时边界不满足；The execution timeout boundary is not satisfied.</summary>
    TimeoutRequired,
    /// <summary>需要降级路径；A fallback path is required.</summary>
    FallbackRequired,
    /// <summary>追踪披露受限但可兼容运行；Trace disclosure is limited but execution is compatible.</summary>
    TraceLimited
}
