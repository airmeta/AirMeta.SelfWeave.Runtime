namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 提供运行时宿主已加载认知引擎的访问入口。</para>
/// <para>en-us: Provides access to cognitive engines loaded by a runtime host.</para>
/// </summary>
public interface ICognitiveRuntimeEngineAccessor
{
    /// <summary>
    /// <para>zh-cn: 获取或表示 ProjectionDecision引擎。</para>
    /// <para>en-us: Gets or represents projection decision engine.</para>
    /// </summary>
    IProjectionDecisionEngine? ProjectionDecisionEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 WaveDynamics引擎。</para>
    /// <para>en-us: Gets or represents wave dynamics engine.</para>
    /// </summary>
    IWaveDynamicsEngine? WaveDynamicsEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 学习可塑性引擎。</para>
    /// <para>en-us: Gets or represents learning plasticity engine.</para>
    /// </summary>
    ILearningPlasticityEngine? LearningPlasticityEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 认知偏置引擎。</para>
    /// <para>en-us: Gets or represents cognitive bias engine.</para>
    /// </summary>
    ICognitiveBiasEngine? CognitiveBiasEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 记忆激活引擎。</para>
    /// <para>en-us: Gets or represents memory activation engine.</para>
    /// </summary>
    IMemoryActivationEngine? MemoryActivationEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 Instinct驱动引擎。</para>
    /// <para>en-us: Gets or represents instinct drive engine.</para>
    /// </summary>
    IInstinctDriveEngine? InstinctDriveEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 情绪人格引擎。</para>
    /// <para>en-us: Gets or represents emotion persona engine.</para>
    /// </summary>
    IEmotionPersonaEngine? EmotionPersonaEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 响应规划引擎。</para>
    /// <para>en-us: Gets or represents response planning engine.</para>
    /// </summary>
    IResponsePlanningEngine? ResponsePlanningEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 策略规划引擎。</para>
    /// <para>en-us: Gets or represents strategy planning engine.</para>
    /// </summary>
    IStrategyPlanningEngine? StrategyPlanningEngine { get; }

    /// <summary>
    /// <para>zh-cn: 获取或表示 皮层编排引擎。</para>
    /// <para>en-us: Gets or represents cortical orchestration engine.</para>
    /// </summary>
    ICorticalOrchestrationEngine? CorticalOrchestrationEngine { get; }
}

/// <summary>
/// <para>zh-cn: 提供运行时宿主已加载投影决策引擎的可选访问入口。</para>
/// <para>en-us: Provides optional access to a projection decision engine loaded by a runtime host.</para>
/// </summary>
public interface IProjectionDecisionEngineAccessor : ICognitiveRuntimeEngineAccessor
{
}
