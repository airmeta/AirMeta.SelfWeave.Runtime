namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示波传播阶段的激活节点、边和停止原因决策；Represents a wave propagation decision with activated nodes, edges, and stop reason.
/// </summary>
/// <param name="Identity">生成决策的引擎和契约身份；The engine and contract identity that produced the decision.</param>
/// <param name="DecisionId">决策唯一标识；The unique decision identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ReasonCodes">解释决策原因的原因码集合；Reason codes explaining the decision.</param>
/// <param name="Confidence">决策置信度；The confidence score for the decision.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
/// <param name="ActivatedNodeRefs">被激活的节点引用集合；Activated node references.</param>
/// <param name="ActivatedEdgeRefs">被激活的边引用集合；Activated edge references.</param>
/// <param name="StopReason">波传播停止原因；The reason wave propagation stopped.</param>
public sealed record WavePropagationDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ReasonCodes,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyList<string> ActivatedNodeRefs,
    IReadOnlyList<string> ActivatedEdgeRefs,
    string StopReason)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ReasonCodes, Confidence, GovernanceFlags);
