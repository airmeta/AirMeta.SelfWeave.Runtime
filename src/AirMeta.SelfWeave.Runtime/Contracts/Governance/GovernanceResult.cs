namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时治理对引擎输出的处理结果。</para>
/// <para>en-us: Represents the runtime governance result for engine output.</para>
/// </summary>
/// <param name="Result">
/// <para>zh-cn: 结果 参数。</para>
/// <para>en-us: The result parameter.</para>
/// </param>
/// <param name="ReasonCodes">
/// <para>zh-cn: 原因代码集合 参数。</para>
/// <para>en-us: The reason codes parameter.</para>
/// </param>
/// <param name="ManualConfirmationPresent">
/// <para>zh-cn: 人工确认已提供 参数。</para>
/// <para>en-us: The manual confirmation present parameter.</para>
/// </param>
/// <param name="PromoteGuardPassed">
/// <para>zh-cn: 提升保护已通过 参数。</para>
/// <para>en-us: The promote guard passed parameter.</para>
/// </param>
/// <param name="DecidedAt">
/// <para>zh-cn: 决策时间 参数。</para>
/// <para>en-us: The decided at parameter.</para>
/// </param>
public sealed record GovernanceResult(
    GovernanceResultKind Result,
    IReadOnlyList<string> ReasonCodes,
    bool ManualConfirmationPresent,
    bool PromoteGuardPassed,
    DateTimeOffset DecidedAt);
