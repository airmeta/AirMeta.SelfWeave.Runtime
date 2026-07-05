namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 投影决策契约或投影引擎返回的受治理决策。</para>
/// <para>en-us: Projection decision contract or governed projection decision returned by an engine.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="SuggestedNodeRefs">
/// <para>zh-cn: Suggested节点引用集合 参数。</para>
/// <para>en-us: The suggested node refs parameter.</para>
/// </param>
/// <param name="SuggestedRelationRefs">
/// <para>zh-cn: Suggested关系引用集合 参数。</para>
/// <para>en-us: The suggested relation refs parameter.</para>
/// </param>
public sealed record ProjectionDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyList<string> SuggestedNodeRefs,
    IReadOnlyList<string> SuggestedRelationRefs)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示波动传播引擎返回的受治理决策。</para>
/// <para>en-us: Represents a governed wave propagation decision returned by an engine.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="ActivatedNodeRefs">
/// <para>zh-cn: 已激活节点引用集合 参数。</para>
/// <para>en-us: The activated node refs parameter.</para>
/// </param>
/// <param name="ActivatedEdgeRefs">
/// <para>zh-cn: 已激活边引用集合 参数。</para>
/// <para>en-us: The activated edge refs parameter.</para>
/// </param>
/// <param name="StopReason">
/// <para>zh-cn: Stop原因 参数。</para>
/// <para>en-us: The stop reason parameter.</para>
/// </param>
public sealed record WavePropagationDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyList<string> ActivatedNodeRefs,
    IReadOnlyList<string> ActivatedEdgeRefs,
    string StopReason)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示认知偏置引擎返回的受治理决策。</para>
/// <para>en-us: Represents a governed runtime bias decision returned by an engine.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="BiasAdjustments">
/// <para>zh-cn: 偏置Adjustments 参数。</para>
/// <para>en-us: The bias adjustments parameter.</para>
/// </param>
public sealed record RuntimeBiasDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyDictionary<string, decimal> BiasAdjustments)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示突触调整建议。</para>
/// <para>en-us: Represents a synapse adjustment proposal.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="ProposalId">
/// <para>zh-cn: 建议唯一标识。</para>
/// <para>en-us: The unique proposal identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="SourceNodeId">
/// <para>zh-cn: 来源节点标识 参数。</para>
/// <para>en-us: The source node id parameter.</para>
/// </param>
/// <param name="TargetNodeId">
/// <para>zh-cn: 目标节点标识 参数。</para>
/// <para>en-us: The target node id parameter.</para>
/// </param>
/// <param name="ProposedDelta">
/// <para>zh-cn: Proposed增量 参数。</para>
/// <para>en-us: The proposed delta parameter.</para>
/// </param>
public sealed record SynapseAdjustmentProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    string SourceNodeId,
    string TargetNodeId,
    decimal ProposedDelta)
    : EngineProposal(Identity, ProposalId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示学习假设建议。</para>
/// <para>en-us: Represents a learning hypothesis proposal.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="ProposalId">
/// <para>zh-cn: 建议唯一标识。</para>
/// <para>en-us: The unique proposal identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="HypothesisKind">
/// <para>zh-cn: 假设类型 参数。</para>
/// <para>en-us: The hypothesis kind parameter.</para>
/// </param>
/// <param name="RecommendedAction">
/// <para>zh-cn: 推荐动作 参数。</para>
/// <para>en-us: The recommended action parameter.</para>
/// </param>
/// <param name="EvidenceRefs">
/// <para>zh-cn: 证据引用集合 参数。</para>
/// <para>en-us: The evidence refs parameter.</para>
/// </param>
public sealed record LearningHypothesisProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    string HypothesisKind,
    string RecommendedAction,
    IReadOnlyList<string> EvidenceRefs)
    : EngineProposal(Identity, ProposalId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示受治理的记忆激活评分输出。</para>
/// <para>en-us: Represents governed memory activation scoring.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="MemoryActivationScores">
/// <para>zh-cn: 记忆激活评分集合 参数。</para>
/// <para>en-us: The memory activation scores parameter.</para>
/// </param>
public sealed record MemoryActivationDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyDictionary<string, decimal> MemoryActivationScores)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示受治理的本能驱动评分输出。</para>
/// <para>en-us: Represents governed instinct drive scoring.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="DriveScores">
/// <para>zh-cn: 驱动评分集合 参数。</para>
/// <para>en-us: The drive scores parameter.</para>
/// </param>
/// <param name="ActivatedDriveCodes">
/// <para>zh-cn: 已激活驱动代码集合 参数。</para>
/// <para>en-us: The activated drive codes parameter.</para>
/// </param>
/// <param name="PrimaryDriveCode">
/// <para>zh-cn: 主要驱动代码 参数。</para>
/// <para>en-us: The primary drive code parameter.</para>
/// </param>
public sealed record InstinctDriveDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyDictionary<string, decimal> DriveScores,
    IReadOnlyList<string> ActivatedDriveCodes,
    string PrimaryDriveCode)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示受治理的情绪人格评分输出。</para>
/// <para>en-us: Represents governed emotion and persona scoring.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="EmotionSignals">
/// <para>zh-cn: 情绪信号集合 参数。</para>
/// <para>en-us: The emotion signals parameter.</para>
/// </param>
/// <param name="PersonaFactors">
/// <para>zh-cn: 人格Factors 参数。</para>
/// <para>en-us: The persona factors parameter.</para>
/// </param>
/// <param name="SelfCoreFactors">
/// <para>zh-cn: 自我核心Factors 参数。</para>
/// <para>en-us: The self core factors parameter.</para>
/// </param>
public sealed record EmotionPersonaDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyDictionary<string, decimal> EmotionSignals,
    IReadOnlyDictionary<string, decimal> PersonaFactors,
    IReadOnlyDictionary<string, decimal> SelfCoreFactors)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示受治理的响应规划输出。</para>
/// <para>en-us: Represents governed response planning output.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="AssistantContentTemplate">
/// <para>zh-cn: Assistant内容模板 参数。</para>
/// <para>en-us: The assistant content template parameter.</para>
/// </param>
/// <param name="SemanticSummary">
/// <para>zh-cn: 语义摘要 参数。</para>
/// <para>en-us: The semantic summary parameter.</para>
/// </param>
/// <param name="DetectedIntent">
/// <para>zh-cn: Detected意图 参数。</para>
/// <para>en-us: The detected intent parameter.</para>
/// </param>
/// <param name="ActionSuggestion">
/// <para>zh-cn: 动作建议 参数。</para>
/// <para>en-us: The action suggestion parameter.</para>
/// </param>
public sealed record ResponsePlanningDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    string AssistantContentTemplate,
    string SemanticSummary,
    string DetectedIntent,
    string ActionSuggestion)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示受治理的策略规划输出。</para>
/// <para>en-us: Represents governed strategy planning output.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="CandidateScores">
/// <para>zh-cn: 候选评分集合 参数。</para>
/// <para>en-us: The candidate scores parameter.</para>
/// </param>
/// <param name="ScoredStrategy">
/// <para>zh-cn: Scored策略 参数。</para>
/// <para>en-us: The scored strategy parameter.</para>
/// </param>
/// <param name="SelectedStrategy">
/// <para>zh-cn: 选中策略 参数。</para>
/// <para>en-us: The selected strategy parameter.</para>
/// </param>
/// <param name="SelectedReason">
/// <para>zh-cn: 选中原因 参数。</para>
/// <para>en-us: The selected reason parameter.</para>
/// </param>
/// <param name="InstinctWeight">
/// <para>zh-cn: Instinct权重 参数。</para>
/// <para>en-us: The instinct weight parameter.</para>
/// </param>
/// <param name="ActionRiskBoundary">
/// <para>zh-cn: 动作风险边界 参数。</para>
/// <para>en-us: The action risk boundary parameter.</para>
/// </param>
/// <param name="RequiresManualConfirmation">
/// <para>zh-cn: 要求人工确认 参数。</para>
/// <para>en-us: The requires manual confirmation parameter.</para>
/// </param>
/// <param name="AllowedActionScope">
/// <para>zh-cn: 允许动作Scope 参数。</para>
/// <para>en-us: The allowed action scope parameter.</para>
/// </param>
/// <param name="OutcomeScore">
/// <para>zh-cn: 结果评分 参数。</para>
/// <para>en-us: The outcome score parameter.</para>
/// </param>
public sealed record StrategyPlanningDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyDictionary<string, decimal> CandidateScores,
    string ScoredStrategy,
    string SelectedStrategy,
    string SelectedReason,
    decimal InstinctWeight,
    string ActionRiskBoundary,
    bool RequiresManualConfirmation,
    string AllowedActionScope,
    decimal OutcomeScore)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);

/// <summary>
/// <para>zh-cn: 表示受治理的皮层输入编排输出。</para>
/// <para>en-us: Represents governed cortical input orchestration output.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="NormalizedText">
/// <para>zh-cn: 归一化文本 参数。</para>
/// <para>en-us: The normalized text parameter.</para>
/// </param>
/// <param name="CorrectedText">
/// <para>zh-cn: 纠正文本 参数。</para>
/// <para>en-us: The corrected text parameter.</para>
/// </param>
/// <param name="SemanticOptimizedText">
/// <para>zh-cn: 语义优化文本 参数。</para>
/// <para>en-us: The semantic optimized text parameter.</para>
/// </param>
/// <param name="KeyTerms">
/// <para>zh-cn: 关键词项集合 参数。</para>
/// <para>en-us: The key terms parameter.</para>
/// </param>
/// <param name="KeyNeuralChars">
/// <para>zh-cn: 关键神经字符集合 参数。</para>
/// <para>en-us: The key neural chars parameter.</para>
/// </param>
/// <param name="KeyNeuralTokens">
/// <para>zh-cn: 关键神经令牌集合 参数。</para>
/// <para>en-us: The key neural tokens parameter.</para>
/// </param>
/// <param name="KeyPhrases">
/// <para>zh-cn: 关键短语集合 参数。</para>
/// <para>en-us: The key phrases parameter.</para>
/// </param>
/// <param name="KeySentences">
/// <para>zh-cn: 关键句子集合 参数。</para>
/// <para>en-us: The key sentences parameter.</para>
/// </param>
/// <param name="Entities">
/// <para>zh-cn: 实体集合 参数。</para>
/// <para>en-us: The entities parameter.</para>
/// </param>
/// <param name="Topics">
/// <para>zh-cn: 主题集合 参数。</para>
/// <para>en-us: The topics parameter.</para>
/// </param>
/// <param name="TaskBreakdown">
/// <para>zh-cn: 任务拆解 参数。</para>
/// <para>en-us: The task breakdown parameter.</para>
/// </param>
/// <param name="AssociativeNeurons">
/// <para>zh-cn: 联想Neurons 参数。</para>
/// <para>en-us: The associative neurons parameter.</para>
/// </param>
/// <param name="NoiseTerms">
/// <para>zh-cn: 噪声词项集合 参数。</para>
/// <para>en-us: The noise terms parameter.</para>
/// </param>
/// <param name="ShouldUseExternalJsonOrchestration">
/// <para>zh-cn: 是否应该使用外部JSON编排 参数。</para>
/// <para>en-us: The should use external json orchestration parameter.</para>
/// </param>
public sealed record CorticalOrchestrationDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    decimal Confidence,
    RuntimeGovernanceFlags GovernanceFlags,
    string NormalizedText,
    string CorrectedText,
    string SemanticOptimizedText,
    IReadOnlyList<string> KeyTerms,
    IReadOnlyList<string> KeyNeuralChars,
    IReadOnlyList<string> KeyNeuralTokens,
    IReadOnlyList<string> KeyPhrases,
    IReadOnlyList<string> KeySentences,
    IReadOnlyList<string> Entities,
    IReadOnlyList<string> Topics,
    IReadOnlyList<CorticalTaskRef> TaskBreakdown,
    IReadOnlyList<CorticalAssociativeNeuronRef> AssociativeNeurons,
    IReadOnlyList<string> NoiseTerms,
    bool ShouldUseExternalJsonOrchestration)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);
