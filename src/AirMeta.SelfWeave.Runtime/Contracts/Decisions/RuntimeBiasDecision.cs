namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示对运行时偏置因子的调整决策；Represents a decision to adjust runtime bias factors.
/// </summary>
/// <param name="Identity">生成决策的引擎和契约身份；The engine and contract identity that produced the decision.</param>
/// <param name="DecisionId">决策唯一标识；The unique decision identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ReasonCodes">解释决策原因的原因码集合；Reason codes explaining the decision.</param>
/// <param name="Confidence">决策置信度；The confidence score for the decision.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
/// <param name="BiasAdjustments">偏置因子调整值；Bias factor adjustments.</param>
public sealed record RuntimeBiasDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ReasonCodes,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyDictionary<string, decimal> BiasAdjustments)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ReasonCodes, Confidence, GovernanceFlags);
