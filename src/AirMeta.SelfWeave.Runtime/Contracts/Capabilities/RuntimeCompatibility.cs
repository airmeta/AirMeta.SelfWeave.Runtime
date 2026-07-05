namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 提供运行时契约兼容性评估逻辑。</para>
/// <para>en-us: Provides runtime contract compatibility evaluation logic.</para>
/// </summary>
public static class RuntimeCompatibility
{
    /// <summary>
    /// <para>zh-cn: 根据运行时需求评估引擎能力是否兼容。</para>
    /// <para>en-us: Evaluates whether an engine capability matches runtime requirements.</para>
    /// </summary>
    /// <param name="capability">
    /// <para>zh-cn: 待评估的引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration to evaluate.</para>
    /// </param>
    /// <param name="requiredContract">
    /// <para>zh-cn: 运行时要求的契约类型。</para>
    /// <para>en-us: The contract kind required by the runtime.</para>
    /// </param>
    /// <param name="requiredSnapshotVersion">
    /// <para>zh-cn: 运行时要求的快照版本。</para>
    /// <para>en-us: The snapshot version required by the runtime.</para>
    /// </param>
    /// <param name="requiredDecisionVersion">
    /// <para>zh-cn: 运行时要求的决策版本。</para>
    /// <para>en-us: The decision version required by the runtime.</para>
    /// </param>
    /// <param name="runtimeTimeout">
    /// <para>zh-cn: 运行时允许的最长执行时间。</para>
    /// <para>en-us: The maximum execution time allowed by the runtime.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 兼容性评估结果。</para>
    /// <para>en-us: The compatibility evaluation result.</para>
    /// </returns>
    public static CompatibilityResult Evaluate(
        EngineCapability capability,
        RuntimeContractKind requiredContract,
        string requiredSnapshotVersion,
        string requiredDecisionVersion,
        TimeSpan runtimeTimeout)
    {
        if (!capability.SupportedContracts.Contains(requiredContract))
        {
            return new(CompatibilityStatus.IncompatibleContract, "incompatible_contract", false, false, false);
        }

        if (!capability.SupportedSnapshotVersions.Contains(requiredSnapshotVersion))
        {
            return new(CompatibilityStatus.UnsupportedSnapshot, "unsupported_snapshot", false, false, false);
        }

        if (!capability.SupportedDecisionVersions.Contains(requiredDecisionVersion))
        {
            return new(CompatibilityStatus.UnsupportedDecision, "unsupported_decision", false, false, false);
        }

        if (capability.MaxExecutionTime > runtimeTimeout)
        {
            return new(CompatibilityStatus.TimeoutRequired, "timeout_required", false, capability.FallbackRequired, true);
        }

        if (capability.FallbackRequired)
        {
            return new(CompatibilityStatus.FallbackRequired, "fallback_required", true, true, false);
        }

        if (capability.TraceDisclosureLevel == TraceDisclosureLevel.Restricted)
        {
            return new(CompatibilityStatus.TraceLimited, "trace_limited", true, false, false);
        }

        return new(CompatibilityStatus.Compatible, "compatible", true, false, false);
    }
}
