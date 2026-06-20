namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示引擎输出的确定性等级；Represents the determinism level of engine output.
/// </summary>
public enum DeterminismLevel
{
    /// <summary>确定性输出；Deterministic output.</summary>
    Deterministic,
    /// <summary>有界非确定性输出；Bounded nondeterministic output.</summary>
    BoundedNondeterministic,
    /// <summary>非确定性输出；Nondeterministic output.</summary>
    Nondeterministic
}
