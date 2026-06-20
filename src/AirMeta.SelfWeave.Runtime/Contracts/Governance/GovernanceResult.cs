namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时治理对引擎输出的处理结果；Represents the runtime governance result for engine output.
/// </summary>
/// <param name="Result">治理结果类型；The governance result kind.</param>
/// <param name="ReasonCodes">治理原因码集合；Governance reason codes.</param>
/// <param name="ManualConfirmationPresent">是否已提供人工确认；Whether manual confirmation is present.</param>
/// <param name="PromoteGuardPassed">提升保护是否通过；Whether promote guard validation passed.</param>
/// <param name="DecidedAt">治理决策时间；The governance decision time.</param>
public sealed record GovernanceResult(
    GovernanceResultKind Result,
    IReadOnlyList<string> ReasonCodes,
    bool ManualConfirmationPresent,
    bool PromoteGuardPassed,
    DateTimeOffset DecidedAt);
