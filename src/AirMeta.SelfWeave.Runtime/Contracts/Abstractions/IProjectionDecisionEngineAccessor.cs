namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// Provides access to cognitive engines loaded by a runtime host.
/// </summary>
public interface ICognitiveRuntimeEngineAccessor
{
    /// <summary>
    /// Gets the currently available projection decision engine.
    /// </summary>
    IProjectionDecisionEngine? ProjectionDecisionEngine { get; }

    /// <summary>
    /// Gets the currently available wave dynamics engine.
    /// </summary>
    IWaveDynamicsEngine? WaveDynamicsEngine { get; }

    /// <summary>
    /// Gets the currently available learning plasticity engine.
    /// </summary>
    ILearningPlasticityEngine? LearningPlasticityEngine { get; }

    /// <summary>
    /// Gets the currently available cognitive bias engine.
    /// </summary>
    ICognitiveBiasEngine? CognitiveBiasEngine { get; }

    /// <summary>
    /// Gets the currently available memory activation engine.
    /// </summary>
    IMemoryActivationEngine? MemoryActivationEngine { get; }

    /// <summary>
    /// Gets the currently available instinct drive engine.
    /// </summary>
    IInstinctDriveEngine? InstinctDriveEngine { get; }

    /// <summary>
    /// Gets the currently available emotion and persona engine.
    /// </summary>
    IEmotionPersonaEngine? EmotionPersonaEngine { get; }

    /// <summary>
    /// Gets the currently available response planning engine.
    /// </summary>
    IResponsePlanningEngine? ResponsePlanningEngine { get; }

    /// <summary>
    /// Gets the currently available strategy planning engine.
    /// </summary>
    IStrategyPlanningEngine? StrategyPlanningEngine { get; }

    /// <summary>
    /// Gets the currently available cortical input orchestration engine.
    /// </summary>
    ICorticalOrchestrationEngine? CorticalOrchestrationEngine { get; }
}

/// <summary>
/// Provides optional access to a projection decision engine loaded by a runtime host.
/// </summary>
public interface IProjectionDecisionEngineAccessor : ICognitiveRuntimeEngineAccessor
{
}
