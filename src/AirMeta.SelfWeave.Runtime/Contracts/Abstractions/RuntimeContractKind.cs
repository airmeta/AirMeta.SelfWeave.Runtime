namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时可请求的引擎契约类型；Represents engine contract kinds the runtime may request.
/// </summary>
public enum RuntimeContractKind
{
    /// <summary>运行时决策契约；Runtime decision contract.</summary>
    RuntimeDecision,

    /// <summary>投影决策契约；Projection decision contract.</summary>
    ProjectionDecision,

    /// <summary>波动传播契约；Wave dynamics contract.</summary>
    WaveDynamics,

    /// <summary>学习可塑性契约；Learning plasticity contract.</summary>
    LearningPlasticity,

    /// <summary>认知偏置契约；Cognitive bias contract.</summary>
    CognitiveBias,

    /// <summary>记忆激活契约；Memory activation contract.</summary>
    MemoryActivation,

    /// <summary>本能驱动契约；Instinct drive contract.</summary>
    InstinctDrive,

    /// <summary>情绪人格契约；Emotion and persona contract.</summary>
    EmotionPersona,

    /// <summary>响应规划契约；Response planning contract.</summary>
    ResponsePlanning,

    /// <summary>策略规划契约；Strategy planning contract.</summary>
    StrategyPlanning,

    /// <summary>皮层输入编排契约；Cortical input orchestration contract.</summary>
    CorticalOrchestration
}
