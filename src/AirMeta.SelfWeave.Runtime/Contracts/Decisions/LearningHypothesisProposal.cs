namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示未知学习或证据归纳产生的学习假设建议；Represents a learning hypothesis proposal derived from evidence.
/// </summary>
/// <param name="Identity">生成建议的引擎和契约身份；The engine and contract identity that produced the proposal.</param>
/// <param name="ProposalId">建议唯一标识；The unique proposal identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ReasonCodes">解释建议原因的原因码集合；Reason codes explaining the proposal.</param>
/// <param name="Confidence">建议置信度；The confidence score for the proposal.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
/// <param name="HypothesisType">学习假设类型；The learning hypothesis type.</param>
/// <param name="RecommendedAction">建议运行时采取的动作；The action recommended to the runtime.</param>
/// <param name="EvidenceRefs">支持该假设的证据引用集合；Evidence references supporting the hypothesis.</param>
public sealed record LearningHypothesisProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ReasonCodes,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    string HypothesisType,
    string RecommendedAction,
    IReadOnlyList<string> EvidenceRefs)
    : EngineProposal(Identity, ProposalId, InputSnapshotHash, ReasonCodes, Confidence, GovernanceFlags);
