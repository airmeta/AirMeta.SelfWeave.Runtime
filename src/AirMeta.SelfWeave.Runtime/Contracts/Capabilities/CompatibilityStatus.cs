namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时和引擎之间的兼容性状态。</para>
/// <para>en-us: Represents compatibility status between runtime and engine.</para>
/// </summary>
public enum CompatibilityStatus
{
    /// <summary>
    /// <para>zh-cn: 完全兼容。</para>
    /// <para>en-us: Fully compatible.</para>
    /// </summary>
    Compatible,
    /// <summary>
    /// <para>zh-cn: 契约类型不兼容。</para>
    /// <para>en-us: The contract kind is incompatible.</para>
    /// </summary>
    IncompatibleContract,
    /// <summary>
    /// <para>zh-cn: 快照版本不受支持。</para>
    /// <para>en-us: The snapshot version is unsupported.</para>
    /// </summary>
    UnsupportedSnapshot,
    /// <summary>
    /// <para>zh-cn: 决策版本不受支持。</para>
    /// <para>en-us: The decision version is unsupported.</para>
    /// </summary>
    UnsupportedDecision,
    /// <summary>
    /// <para>zh-cn: 执行超时边界不满足。</para>
    /// <para>en-us: The execution timeout boundary is not satisfied.</para>
    /// </summary>
    TimeoutRequired,
    /// <summary>
    /// <para>zh-cn: 需要降级路径。</para>
    /// <para>en-us: A fallback path is required.</para>
    /// </summary>
    FallbackRequired,
    /// <summary>
    /// <para>zh-cn: 追踪披露受限但可兼容运行。</para>
    /// <para>en-us: Trace disclosure is limited but execution is compatible.</para>
    /// </summary>
    TraceLimited
}
