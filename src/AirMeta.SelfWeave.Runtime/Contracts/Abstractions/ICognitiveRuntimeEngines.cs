namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 定义投影决策引擎契约。</para>
/// <para>en-us: Defines the projection decision engine contract.</para>
/// </summary>
public interface IProjectionDecisionEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照创建受治理的投影决策。</para>
    /// <para>en-us: Creates a governed projection decision from immutable snapshots.</para>
    /// </summary>
    /// <param name="projection">
    /// <para>zh-cn: 投影输入快照。</para>
    /// <para>en-us: The projection input snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的投影决策。</para>
    /// <para>en-us: The governed projection decision.</para>
    /// </returns>
    ValueTask<ProjectionDecision> DecideProjectionAsync(
        ProjectionInputSnapshot projection,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义波动传播引擎契约。</para>
/// <para>en-us: Defines the wave dynamics engine contract.</para>
/// </summary>
public interface IWaveDynamicsEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照创建受治理的波动传播决策。</para>
    /// <para>en-us: Creates a governed wave propagation decision from immutable snapshots.</para>
    /// </summary>
    /// <param name="wave">
    /// <para>zh-cn: 波动运行快照。</para>
    /// <para>en-us: The wave runtime snapshot.</para>
    /// </param>
    /// <param name="topology">
    /// <para>zh-cn: 拓扑子图快照。</para>
    /// <para>en-us: The topology subgraph snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的波动传播决策。</para>
    /// <para>en-us: The governed wave propagation decision.</para>
    /// </returns>
    ValueTask<WavePropagationDecision> DecideWavePropagationAsync(
        WaveRuntimeSnapshot wave,
        TopologySubgraphSnapshot topology,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义学习可塑性引擎契约。</para>
/// <para>en-us: Defines the learning plasticity engine contract.</para>
/// </summary>
public interface ILearningPlasticityEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照创建受治理的突触调整建议。</para>
    /// <para>en-us: Creates a governed synapse adjustment proposal from immutable snapshots.</para>
    /// </summary>
    /// <param name="evidence">
    /// <para>zh-cn: 学习证据快照。</para>
    /// <para>en-us: The learning evidence snapshot.</para>
    /// </param>
    /// <param name="topology">
    /// <para>zh-cn: 拓扑子图快照。</para>
    /// <para>en-us: The topology subgraph snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的突触调整建议。</para>
    /// <para>en-us: The governed synapse adjustment proposal.</para>
    /// </returns>
    ValueTask<SynapseAdjustmentProposal> ProposeSynapseAdjustmentAsync(
        LearningEvidenceSnapshot evidence,
        TopologySubgraphSnapshot topology,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照创建受治理的学习假设建议。</para>
    /// <para>en-us: Creates a governed learning hypothesis proposal from immutable snapshots.</para>
    /// </summary>
    /// <param name="evidence">
    /// <para>zh-cn: 学习证据快照。</para>
    /// <para>en-us: The learning evidence snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的学习假设建议。</para>
    /// <para>en-us: The governed learning hypothesis proposal.</para>
    /// </returns>
    ValueTask<LearningHypothesisProposal> ProposeLearningHypothesisAsync(
        LearningEvidenceSnapshot evidence,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义认知偏置引擎契约。</para>
/// <para>en-us: Defines the cognitive bias engine contract.</para>
/// </summary>
public interface ICognitiveBiasEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照创建受治理的运行时偏置决策。</para>
    /// <para>en-us: Creates a governed runtime bias decision from immutable snapshots.</para>
    /// </summary>
    /// <param name="bias">
    /// <para>zh-cn: 运行时偏置快照。</para>
    /// <para>en-us: The runtime bias snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的运行时偏置决策。</para>
    /// <para>en-us: The governed runtime bias decision.</para>
    /// </returns>
    ValueTask<RuntimeBiasDecision> DecideRuntimeBiasAsync(
        RuntimeBiasSnapshot bias,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义记忆激活引擎契约。</para>
/// <para>en-us: Defines the memory activation engine contract.</para>
/// </summary>
public interface IMemoryActivationEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照为记忆激活候选评分。</para>
    /// <para>en-us: Scores memory activation candidates from immutable snapshots.</para>
    /// </summary>
    /// <param name="memory">
    /// <para>zh-cn: 记忆激活快照。</para>
    /// <para>en-us: The memory activation snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的记忆激活决策。</para>
    /// <para>en-us: The governed memory activation decision.</para>
    /// </returns>
    ValueTask<MemoryActivationDecision> DecideMemoryActivationAsync(
        MemoryActivationSnapshot memory,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义本能驱动引擎契约。</para>
/// <para>en-us: Defines the instinct drive engine contract.</para>
/// </summary>
public interface IInstinctDriveEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照为本能驱动评分。</para>
    /// <para>en-us: Scores instinct drives from immutable snapshots.</para>
    /// </summary>
    /// <param name="instinct">
    /// <para>zh-cn: 本能驱动快照。</para>
    /// <para>en-us: The instinct drive snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的本能驱动决策。</para>
    /// <para>en-us: The governed instinct drive decision.</para>
    /// </returns>
    ValueTask<InstinctDriveDecision> DecideInstinctDriveAsync(
        InstinctDriveSnapshot instinct,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义情绪人格引擎契约。</para>
/// <para>en-us: Defines the emotion and persona engine contract.</para>
/// </summary>
public interface IEmotionPersonaEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照为情绪、人格和自我核心信号评分。</para>
    /// <para>en-us: Scores emotion, persona, and self-core signals from immutable snapshots.</para>
    /// </summary>
    /// <param name="emotionPersona">
    /// <para>zh-cn: 情绪人格快照。</para>
    /// <para>en-us: The emotion and persona snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的情绪人格决策。</para>
    /// <para>en-us: The governed emotion and persona decision.</para>
    /// </returns>
    ValueTask<EmotionPersonaDecision> DecideEmotionPersonaAsync(
        EmotionPersonaSnapshot emotionPersona,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义响应规划引擎契约。</para>
/// <para>en-us: Defines the response planning engine contract.</para>
/// </summary>
public interface IResponsePlanningEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照规划本地认知响应。</para>
    /// <para>en-us: Plans a local cognitive response from immutable snapshots.</para>
    /// </summary>
    /// <param name="response">
    /// <para>zh-cn: 响应规划快照。</para>
    /// <para>en-us: The response planning snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的响应规划决策。</para>
    /// <para>en-us: The governed response planning decision.</para>
    /// </returns>
    ValueTask<ResponsePlanningDecision> DecideResponsePlanningAsync(
        ResponsePlanningSnapshot response,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义策略规划引擎契约。</para>
/// <para>en-us: Defines the strategy planning engine contract.</para>
/// </summary>
public interface IStrategyPlanningEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照规划策略选择、动作边界和结果评分。</para>
    /// <para>en-us: Plans strategy selection, action boundary, and inline outcome scoring from immutable snapshots.</para>
    /// </summary>
    /// <param name="strategy">
    /// <para>zh-cn: 策略规划快照。</para>
    /// <para>en-us: The strategy planning snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的策略规划决策。</para>
    /// <para>en-us: The governed strategy planning decision.</para>
    /// </returns>
    ValueTask<StrategyPlanningDecision> DecideStrategyPlanningAsync(
        StrategyPlanningSnapshot strategy,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}

/// <summary>
/// <para>zh-cn: 定义皮层输入编排引擎契约。</para>
/// <para>en-us: Defines the cortical input orchestration engine contract.</para>
/// </summary>
public interface ICorticalOrchestrationEngine
{
    /// <summary>
    /// <para>zh-cn: 获取引擎能力声明。</para>
    /// <para>en-us: Gets the engine capability declaration.</para>
    /// </summary>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 引擎能力声明。</para>
    /// <para>en-us: The engine capability declaration.</para>
    /// </returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// <para>zh-cn: 根据不可变快照构建或加固皮层输入候选。</para>
    /// <para>en-us: Builds or hardens cortical input candidates from immutable snapshots.</para>
    /// </summary>
    /// <param name="cortical">
    /// <para>zh-cn: 皮层输入编排快照。</para>
    /// <para>en-us: The cortical input orchestration snapshot.</para>
    /// </param>
    /// <param name="context">
    /// <para>zh-cn: 运行时上下文快照。</para>
    /// <para>en-us: The runtime context snapshot.</para>
    /// </param>
    /// <param name="cancellationToken">
    /// <para>zh-cn: 取消异步操作的令牌。</para>
    /// <para>en-us: The token used to cancel the asynchronous operation.</para>
    /// </param>
    /// <returns>
    /// <para>zh-cn: 受治理的皮层输入编排决策。</para>
    /// <para>en-us: The governed cortical input orchestration decision.</para>
    /// </returns>
    ValueTask<CorticalOrchestrationDecision> DecideCorticalOrchestrationAsync(
        CorticalOrchestrationSnapshot cortical,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}
