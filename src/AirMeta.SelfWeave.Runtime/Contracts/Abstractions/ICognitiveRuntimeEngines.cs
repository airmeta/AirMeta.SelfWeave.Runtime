namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义投影决策引擎契约；Defines the projection decision engine contract.
/// </summary>
public interface IProjectionDecisionEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a governed projection decision from immutable snapshots.
    /// </summary>
    ValueTask<ProjectionDecision> DecideProjectionAsync(
        ProjectionInputSnapshot projection,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// 定义波动传播引擎契约；Defines the wave dynamics engine contract.
/// </summary>
public interface IWaveDynamicsEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a governed wave propagation decision from immutable snapshots.
    /// </summary>
    ValueTask<WavePropagationDecision> DecideWavePropagationAsync(
        WaveRuntimeSnapshot wave,
        TopologySubgraphSnapshot topology,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// 定义学习可塑性引擎契约；Defines the learning plasticity engine contract.
/// </summary>
public interface ILearningPlasticityEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a governed synapse adjustment proposal from immutable snapshots.
    /// </summary>
    ValueTask<SynapseAdjustmentProposal> ProposeSynapseAdjustmentAsync(
        LearningEvidenceSnapshot evidence,
        TopologySubgraphSnapshot topology,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a governed learning hypothesis proposal from immutable snapshots.
    /// </summary>
    ValueTask<LearningHypothesisProposal> ProposeLearningHypothesisAsync(
        LearningEvidenceSnapshot evidence,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// 定义认知偏置引擎契约；Defines the cognitive bias engine contract.
/// </summary>
public interface ICognitiveBiasEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a governed runtime bias decision from immutable snapshots.
    /// </summary>
    ValueTask<RuntimeBiasDecision> DecideRuntimeBiasAsync(
        RuntimeBiasSnapshot bias,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Defines the memory activation engine contract.
/// </summary>
public interface IMemoryActivationEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Scores memory activation candidates from immutable snapshots.
    /// </summary>
    ValueTask<MemoryActivationDecision> DecideMemoryActivationAsync(
        MemoryActivationSnapshot memory,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Defines the instinct drive engine contract.
/// </summary>
public interface IInstinctDriveEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Scores instinct drives from immutable snapshots.
    /// </summary>
    ValueTask<InstinctDriveDecision> DecideInstinctDriveAsync(
        InstinctDriveSnapshot instinct,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Defines the emotion and persona engine contract.
/// </summary>
public interface IEmotionPersonaEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Scores emotion, persona, and self-core signals from immutable snapshots.
    /// </summary>
    ValueTask<EmotionPersonaDecision> DecideEmotionPersonaAsync(
        EmotionPersonaSnapshot emotionPersona,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Defines the response planning engine contract.
/// </summary>
public interface IResponsePlanningEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Plans a local cognitive response from immutable snapshots.
    /// </summary>
    ValueTask<ResponsePlanningDecision> DecideResponsePlanningAsync(
        ResponsePlanningSnapshot response,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Defines the strategy planning engine contract.
/// </summary>
public interface IStrategyPlanningEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Plans strategy selection, action boundary, and inline outcome scoring from immutable snapshots.
    /// </summary>
    ValueTask<StrategyPlanningDecision> DecideStrategyPlanningAsync(
        StrategyPlanningSnapshot strategy,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// Defines the cortical input orchestration engine contract.
/// </summary>
public interface ICorticalOrchestrationEngine
{
    /// <summary>
    /// Gets the engine capability declaration.
    /// </summary>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Builds or hardens cortical input candidates from immutable snapshots.
    /// </summary>
    ValueTask<CorticalOrchestrationDecision> DecideCorticalOrchestrationAsync(
        CorticalOrchestrationSnapshot cortical,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}
