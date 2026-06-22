namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示投影输入快照；Represents a projection input snapshot.
/// </summary>
public sealed record ProjectionInputSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    IReadOnlyList<string> CandidateNodeRefs,
    IReadOnlyList<string> CandidateRelationRefs,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// 表示认知上下文快照；Represents a cognitive context snapshot.
/// </summary>
public sealed record CognitiveContextSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string CognitiveCycleId,
    string InteractionId,
    IReadOnlyList<string> MemoryRefs,
    IReadOnlyList<string> GoalRefs,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// 表示波动运行快照；Represents a wave runtime snapshot.
/// </summary>
public sealed record WaveRuntimeSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<string> InitialNodeRefs,
    int MaxRounds,
    decimal InitialEnergy,
    IReadOnlyDictionary<string, decimal> BiasSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// 表示拓扑子图快照；Represents a topology subgraph snapshot.
/// </summary>
public sealed record TopologySubgraphSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<TopologyNodeRef> Nodes,
    IReadOnlyList<TopologyEdgeRef> Edges)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents a public topology node reference.
/// </summary>
/// <param name="NodeId">The node identifier.</param>
/// <param name="NodeType">The node type.</param>
/// <param name="Label">The node label.</param>
/// <param name="StabilityScore">The public stability score.</param>
/// <param name="FireThreshold">The activation threshold.</param>
/// <param name="InhibitionThreshold">The inhibition threshold.</param>
/// <param name="IsSelfCore">Whether this node is marked as self-core.</param>
public sealed record TopologyNodeRef(
    string NodeId,
    string NodeType,
    string Label,
    decimal StabilityScore,
    decimal FireThreshold,
    decimal InhibitionThreshold,
    bool IsSelfCore);

/// <summary>
/// Represents a public topology edge reference.
/// </summary>
/// <param name="EdgeId">The edge identifier.</param>
/// <param name="SourceNodeId">The source node identifier.</param>
/// <param name="TargetNodeId">The target node identifier.</param>
/// <param name="RelationType">The relation type.</param>
/// <param name="Strength">The edge strength.</param>
/// <param name="Plasticity">The edge plasticity.</param>
public sealed record TopologyEdgeRef(
    string EdgeId,
    string SourceNodeId,
    string TargetNodeId,
    string RelationType,
    decimal Strength,
    decimal Plasticity);

/// <summary>
/// 表示学习证据快照；Represents a learning evidence snapshot.
/// </summary>
public sealed record LearningEvidenceSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<LearningEvidenceRef> EvidenceRefs,
    decimal MinimumEvidenceStrength,
    int MinimumEvidenceCount)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents a public learning evidence reference.
/// </summary>
/// <param name="EvidenceId">The evidence identifier.</param>
/// <param name="Source">The evidence source.</param>
/// <param name="Direction">The evidence direction.</param>
/// <param name="Strength">The evidence strength.</param>
/// <param name="QualityScore">The evidence quality score.</param>
public sealed record LearningEvidenceRef(
    string EvidenceId,
    string Source,
    string Direction,
    decimal Strength,
    decimal QualityScore);

/// <summary>
/// 表示运行时偏置快照；Represents a runtime bias snapshot.
/// </summary>
public sealed record RuntimeBiasSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<string, decimal> BiasSignals,
    IReadOnlyList<string> TargetRefs)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents memory activation candidates for an engine.
/// </summary>
public sealed record MemoryActivationSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<string> ActivatedNodeRefs,
    IReadOnlyList<MemoryCandidateRef> CandidateMemories,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents a memory candidate reference.
/// </summary>
public sealed record MemoryCandidateRef(
    string MemoryId,
    int MatchedNodeCount,
    decimal RefWeight,
    decimal ActivationWeight);

/// <summary>
/// Represents instinct drive scoring input.
/// </summary>
public sealed record InstinctDriveSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    IReadOnlyList<InstinctDriveRef> Drives,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents a public instinct drive reference.
/// </summary>
public sealed record InstinctDriveRef(
    string DriveCode,
    decimal BaselineWeight,
    decimal ActivationThreshold,
    decimal DecayRate);

/// <summary>
/// Represents emotion and persona scoring input.
/// </summary>
public sealed record EmotionPersonaSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    string SemanticSummary,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents response planning input.
/// </summary>
public sealed record ResponsePlanningSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    string SelectedStrategy,
    string ResponsePolicy,
    IReadOnlyDictionary<string, decimal> RuntimeSignals,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents strategy planning input.
/// </summary>
public sealed record StrategyPlanningSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    decimal Confidence,
    decimal Uncertainty,
    decimal MemorySupport,
    bool HasActivatedMemory,
    decimal AverageMemoryActivationScore,
    decimal LearningHypothesisStrategyBiasScore,
    string? ResponseSelectedStrategy,
    IReadOnlyDictionary<string, decimal> DriveScores,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents cortical input orchestration input.
/// </summary>
public sealed record CorticalOrchestrationSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputText,
    string DetectedIntent,
    bool HasExternalCandidates,
    string? SuppliedCorrectedText,
    string? SuppliedSemanticOptimizedText,
    IReadOnlyList<string> SuppliedKeyTerms,
    IReadOnlyList<string> SuppliedKeyNeuralChars,
    IReadOnlyList<string> SuppliedKeyNeuralTokens,
    IReadOnlyList<string> SuppliedKeyPhrases,
    IReadOnlyList<string> SuppliedKeySentences,
    IReadOnlyList<string> SuppliedEntities,
    IReadOnlyList<string> SuppliedTopics,
    IReadOnlyList<CorticalTaskRef> SuppliedTaskBreakdown,
    IReadOnlyList<CorticalAssociativeNeuronRef> SuppliedAssociativeNeurons,
    IReadOnlyList<string> SuppliedNoiseTerms,
    decimal? SuppliedConfidence,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// Represents a cortical task breakdown reference.
/// </summary>
public sealed record CorticalTaskRef(
    int Order,
    string Content,
    bool IsCognitiveArchitectureRelated,
    string HandlingMode,
    string GoalType,
    string Reason);

/// <summary>
/// Represents an associative neuron candidate reference.
/// </summary>
public sealed record CorticalAssociativeNeuronRef(
    string Text,
    string Relation,
    decimal Weight);
