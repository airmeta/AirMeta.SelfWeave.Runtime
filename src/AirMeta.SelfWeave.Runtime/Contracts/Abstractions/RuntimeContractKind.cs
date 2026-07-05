namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示运行时可请求的引擎契约类型。</para>
/// <para>en-us: Represents engine contract kinds the runtime may request.</para>
/// </summary>
public enum RuntimeContractKind
{
    /// <summary>
    /// <para>zh-cn: 运行时决策契约。</para>
    /// <para>en-us: Runtime decision contract.</para>
    /// </summary>
    RuntimeDecision,

    /// <summary>
    /// <para>zh-cn: 投影决策契约或投影引擎返回的受治理决策。</para>
    /// <para>en-us: Projection decision contract or governed projection decision returned by an engine.</para>
    /// </summary>
    ProjectionDecision,

    /// <summary>
    /// <para>zh-cn: 波动传播契约。</para>
    /// <para>en-us: Wave dynamics contract.</para>
    /// </summary>
    WaveDynamics,

    /// <summary>
    /// <para>zh-cn: 学习可塑性契约。</para>
    /// <para>en-us: Learning plasticity contract.</para>
    /// </summary>
    LearningPlasticity,

    /// <summary>
    /// <para>zh-cn: 认知偏置契约。</para>
    /// <para>en-us: Cognitive bias contract.</para>
    /// </summary>
    CognitiveBias,

    /// <summary>
    /// <para>zh-cn: 记忆激活契约。</para>
    /// <para>en-us: Memory activation contract.</para>
    /// </summary>
    MemoryActivation,

    /// <summary>
    /// <para>zh-cn: 本能驱动契约。</para>
    /// <para>en-us: Instinct drive contract.</para>
    /// </summary>
    InstinctDrive,

    /// <summary>
    /// <para>zh-cn: 情绪人格契约。</para>
    /// <para>en-us: Emotion and persona contract.</para>
    /// </summary>
    EmotionPersona,

    /// <summary>
    /// <para>zh-cn: 响应规划契约。</para>
    /// <para>en-us: Response planning contract.</para>
    /// </summary>
    ResponsePlanning,

    /// <summary>
    /// <para>zh-cn: 策略规划契约。</para>
    /// <para>en-us: Strategy planning contract.</para>
    /// </summary>
    StrategyPlanning,

    /// <summary>
    /// <para>zh-cn: 皮层输入编排契约。</para>
    /// <para>en-us: Cortical input orchestration contract.</para>
    /// </summary>
    CorticalOrchestration
}
