namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示引擎输出的确定性等级。</para>
/// <para>en-us: Represents the determinism level of engine output.</para>
/// </summary>
public enum DeterminismLevel
{
    /// <summary>
    /// <para>zh-cn: 确定性输出。</para>
    /// <para>en-us: Deterministic output.</para>
    /// </summary>
    Deterministic,
    /// <summary>
    /// <para>zh-cn: 有界非确定性输出。</para>
    /// <para>en-us: Bounded nondeterministic output.</para>
    /// </summary>
    BoundedNondeterministic,
    /// <summary>
    /// <para>zh-cn: 非确定性输出。</para>
    /// <para>en-us: Nondeterministic output.</para>
    /// </summary>
    Nondeterministic
}
