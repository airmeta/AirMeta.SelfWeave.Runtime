namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示引擎提出但必须由运行时治理处理的建议基类；Represents the base proposal emitted by an engine and governed by the runtime.
/// </summary>
/// <param name="Identity">生成建议的引擎和契约身份；The engine and contract identity that produced the proposal.</param>
/// <param name="ProposalId">建议唯一标识；The unique proposal identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ExplanationRefs">解释引用集合；The explanation references for the proposal.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
public abstract record EngineProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    RuntimeGovernanceFlags GovernanceFlags);
