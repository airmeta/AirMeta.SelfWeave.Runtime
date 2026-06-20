namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示引擎提出但必须由运行时治理处理的建议基类；Represents the base proposal emitted by an engine and governed by the runtime.
/// </summary>
/// <param name="Identity">生成建议的引擎和契约身份；The engine and contract identity that produced the proposal.</param>
/// <param name="ProposalId">建议唯一标识；The unique proposal identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ReasonCodes">解释建议原因的原因码集合；Reason codes explaining the proposal.</param>
/// <param name="Confidence">建议置信度；The confidence score for the proposal.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
public abstract record EngineProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ReasonCodes,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags);
