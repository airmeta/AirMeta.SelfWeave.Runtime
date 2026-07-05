namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 描述引擎输出必须交由运行时治理处理的控制标记。</para>
/// <para>en-us: Describes governance control flags that runtime must enforce for engine output.</para>
/// </summary>
/// <param name="RequiresGovernanceReview">
/// <para>zh-cn: 要求治理Review 参数。</para>
/// <para>en-us: The requires governance review parameter.</para>
/// </param>
/// <param name="RequiresManualConfirmation">
/// <para>zh-cn: 要求人工确认 参数。</para>
/// <para>en-us: The requires manual confirmation parameter.</para>
/// </param>
/// <param name="RequiresPromoteGuard">
/// <para>zh-cn: 要求提升保护 参数。</para>
/// <para>en-us: The requires promote guard parameter.</para>
/// </param>
/// <param name="RequiresStateGuard">
/// <para>zh-cn: 要求状态保护 参数。</para>
/// <para>en-us: The requires state guard parameter.</para>
/// </param>
/// <param name="PromotesStableNeuron">
/// <para>zh-cn: 提升稳定神经元 参数。</para>
/// <para>en-us: The promotes stable neuron parameter.</para>
/// </param>
/// <param name="PromotesStableSynapse">
/// <para>zh-cn: 提升稳定Synapse 参数。</para>
/// <para>en-us: The promotes stable synapse parameter.</para>
/// </param>
/// <param name="AffectsStableState">
/// <para>zh-cn: 影响稳定状态 参数。</para>
/// <para>en-us: The affects stable state parameter.</para>
/// </param>
/// <param name="AffectsLongTermState">
/// <para>zh-cn: 影响长期Term状态 参数。</para>
/// <para>en-us: The affects long term state parameter.</para>
/// </param>
/// <param name="AffectsHighRiskAction">
/// <para>zh-cn: 影响高风险动作 参数。</para>
/// <para>en-us: The affects high risk action parameter.</para>
/// </param>
/// <param name="TraceRequired">
/// <para>zh-cn: 追踪要求 参数。</para>
/// <para>en-us: The trace required parameter.</para>
/// </param>
/// <param name="FallbackSafe">
/// <para>zh-cn: 降级安全 参数。</para>
/// <para>en-us: The fallback safe parameter.</para>
/// </param>
public sealed record RuntimeGovernanceFlags(
    bool RequiresGovernanceReview = true,
    bool RequiresManualConfirmation = false,
    bool RequiresPromoteGuard = false,
    bool RequiresStateGuard = false,
    bool PromotesStableNeuron = false,
    bool PromotesStableSynapse = false,
    bool AffectsStableState = false,
    bool AffectsLongTermState = false,
    bool AffectsHighRiskAction = false,
    bool TraceRequired = true,
    bool FallbackSafe = true);
