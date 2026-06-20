namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示突触权重调整建议；Represents a proposed synapse weight adjustment.
/// </summary>
/// <param name="Identity">生成建议的引擎和契约身份；The engine and contract identity that produced the proposal.</param>
/// <param name="ProposalId">建议唯一标识；The unique proposal identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ReasonCodes">解释建议原因的原因码集合；Reason codes explaining the proposal.</param>
/// <param name="Confidence">建议置信度；The confidence score for the proposal.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
/// <param name="SourceNodeId">源节点标识；The source node identifier.</param>
/// <param name="TargetNodeId">目标节点标识；The target node identifier.</param>
/// <param name="ProposedDelta">建议的权重变化量；The proposed weight delta.</param>
public sealed record SynapseAdjustmentProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ReasonCodes,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    string SourceNodeId,
    string TargetNodeId,
    decimal ProposedDelta)
    : EngineProposal(Identity, ProposalId, InputSnapshotHash, ReasonCodes, Confidence, GovernanceFlags);
