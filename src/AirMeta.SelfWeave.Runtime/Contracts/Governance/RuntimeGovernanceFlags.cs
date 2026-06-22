namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 描述引擎输出必须交由运行时治理处理的控制标记；Describes governance control flags that runtime must enforce for engine output.
/// </summary>
/// <param name="RequiresGovernanceReview">是否需要治理审核；Whether governance review is required.</param>
/// <param name="RequiresManualConfirmation">是否需要人工确认；Whether manual confirmation is required.</param>
/// <param name="RequiresPromoteGuard">是否需要提升保护校验；Whether promote-guard validation is required.</param>
/// <param name="RequiresStateGuard">是否需要状态保护校验；Whether state-guard validation is required.</param>
/// <param name="PromotesStableNeuron">是否建议提升稳定神经元；Whether stable neuron promotion is proposed.</param>
/// <param name="PromotesStableSynapse">是否建议提升稳定突触；Whether stable synapse promotion is proposed.</param>
/// <param name="AffectsStableState">是否影响稳定状态；Whether stable state may be affected.</param>
/// <param name="AffectsLongTermState">是否影响长期状态；Whether long-term state may be affected.</param>
/// <param name="AffectsHighRiskAction">是否影响高风险动作；Whether high-risk actions may be affected.</param>
/// <param name="TraceRequired">是否必须记录追踪；Whether trace recording is required.</param>
/// <param name="FallbackSafe">是否可安全降级；Whether fallback is safe.</param>
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
