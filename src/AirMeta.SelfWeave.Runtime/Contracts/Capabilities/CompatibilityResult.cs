namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时对引擎能力匹配结果的判断。</para>
/// <para>en-us: Represents the runtime compatibility decision for an engine capability.</para>
/// </summary>
/// <param name="Status">
/// <para>zh-cn: 状态 参数。</para>
/// <para>en-us: The status parameter.</para>
/// </param>
/// <param name="ReasonCode">
/// <para>zh-cn: 原因代码 参数。</para>
/// <para>en-us: The reason code parameter.</para>
/// </param>
/// <param name="Compatible">
/// <para>zh-cn: 兼容 参数。</para>
/// <para>en-us: The compatible parameter.</para>
/// </param>
/// <param name="FallbackRequired">
/// <para>zh-cn: 降级要求 参数。</para>
/// <para>en-us: The fallback required parameter.</para>
/// </param>
/// <param name="TimeoutRequired">
/// <para>zh-cn: 超时要求 参数。</para>
/// <para>en-us: The timeout required parameter.</para>
/// </param>
public sealed record CompatibilityResult(
    CompatibilityStatus Status,
    string ReasonCode,
    bool Compatible,
    bool FallbackRequired,
    bool TimeoutRequired);
