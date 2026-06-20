namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示引擎提出但必须由运行时治理处理的受控建议；Represents a bounded proposal emitted by an engine and governed by the runtime.
/// </summary>
/// <param name="Identity">生成建议的引擎和契约身份；The engine and contract identity that produced the proposal.</param>
/// <param name="ProposalId">建议唯一标识；The unique proposal identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ExplanationRefs">解释引用集合；The explanation references.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
/// <param name="ProposalRefs">建议引用集合；The proposal references.</param>
/// <param name="Metadata">公开建议元数据；The public proposal metadata.</param>
public sealed record RuntimeProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyList<string> ProposalRefs,
    IReadOnlyDictionary<string, string> Metadata)
    : EngineProposal(Identity, ProposalId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);
