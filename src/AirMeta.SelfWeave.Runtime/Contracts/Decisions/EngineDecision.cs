namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示引擎返回给运行时的只读决策基类；Represents the base read-only decision returned from an engine to the runtime.
/// </summary>
/// <param name="Identity">生成决策的引擎和契约身份；The engine and contract identity that produced the decision.</param>
/// <param name="DecisionId">决策唯一标识；The unique decision identifier.</param>
/// <param name="InputSnapshotHash">输入快照哈希；The hash of the input snapshot.</param>
/// <param name="ExplanationRefs">解释引用集合；The explanation references for the decision.</param>
/// <param name="GovernanceFlags">运行时治理标记；Runtime governance flags.</param>
public abstract record EngineDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    RuntimeGovernanceFlags GovernanceFlags);
