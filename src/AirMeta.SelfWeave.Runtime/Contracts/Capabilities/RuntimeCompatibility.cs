namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 提供运行时契约兼容性评估逻辑；Provides runtime contract compatibility evaluation logic.
/// </summary>
public static class RuntimeCompatibility
{
    /// <summary>
    /// 根据运行时需求评估引擎能力是否兼容；Evaluates whether an engine capability matches runtime requirements.
    /// </summary>
    /// <param name="capability">待评估的引擎能力声明；The engine capability declaration to evaluate.</param>
    /// <param name="requiredContract">运行时要求的契约类型；The contract kind required by the runtime.</param>
    /// <param name="requiredSnapshotVersion">运行时要求的快照版本；The snapshot version required by the runtime.</param>
    /// <param name="requiredDecisionVersion">运行时要求的决策版本；The decision version required by the runtime.</param>
    /// <param name="runtimeTimeout">运行时允许的最长执行时间；The maximum execution time allowed by the runtime.</param>
    /// <returns>兼容性评估结果；The compatibility evaluation result.</returns>
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
