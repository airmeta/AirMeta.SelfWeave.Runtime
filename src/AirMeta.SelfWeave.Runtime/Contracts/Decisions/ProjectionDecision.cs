namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示投影阶段给出的候选节点和关系决策；Represents a projection decision with suggested nodes and relations.
/// </summary>
/// <param name="Identity">生成决策的引擎和契约身份；The engine and contract identity that produced the decision.</param>
/// <param name="DecisionId">决策唯一标识；The unique decision identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ReasonCodes">解释决策原因的原因码集合；Reason codes explaining the decision.</param>
/// <param name="Confidence">决策置信度；The confidence score for the decision.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
/// <param name="SuggestedNodeRefs">建议关联的节点引用集合；Suggested node references.</param>
/// <param name="SuggestedRelationRefs">建议关联的关系引用集合；Suggested relation references.</param>
public sealed record ProjectionDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ReasonCodes,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyList<string> SuggestedNodeRefs,
    IReadOnlyList<string> SuggestedRelationRefs)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ReasonCodes, Confidence, GovernanceFlags);
