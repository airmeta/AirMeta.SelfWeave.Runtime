namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示投影引擎返回的受治理决策；Represents a governed projection decision returned by an engine.
/// </summary>
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
/// 表示波动传播引擎返回的受治理决策；Represents a governed wave propagation decision returned by an engine.
/// </summary>
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
/// 表示认知偏置引擎返回的受治理决策；Represents a governed runtime bias decision returned by an engine.
/// </summary>
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
/// 表示突触调整建议；Represents a synapse adjustment proposal.
/// </summary>
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
/// 表示学习假设建议；Represents a learning hypothesis proposal.
/// </summary>
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
/// Represents governed memory activation scoring.
/// </summary>
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
/// Represents governed instinct drive scoring.
/// </summary>
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
/// Represents governed emotion and persona scoring.
/// </summary>
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
/// Represents governed response planning output.
/// </summary>
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
/// Represents governed strategy planning output.
/// </summary>
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
/// Represents governed cortical input orchestration output.
/// </summary>
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
