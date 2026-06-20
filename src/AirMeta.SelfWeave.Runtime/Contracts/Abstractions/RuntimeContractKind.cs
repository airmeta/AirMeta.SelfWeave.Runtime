namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时可请求的引擎契约类型；Represents engine contract kinds the runtime may request.
/// </summary>
public enum RuntimeContractKind
{
    /// <summary>投影决策契约；Projection decision contract.</summary>
    ProjectionDecision,
    /// <summary>波动力传播契约；Wave dynamics contract.</summary>
    WaveDynamics,
    /// <summary>学习可塑性契约；Learning plasticity contract.</summary>
    LearningPlasticity,
    /// <summary>认知偏置契约；Cognitive bias contract.</summary>
    CognitiveBias,
    /// <summary>共振发现契约；Resonance discovery contract.</summary>
    ResonanceDiscovery,
    /// <summary>抽象归纳契约；Abstraction contract.</summary>
    Abstraction,
    /// <summary>梦境模拟契约；Dream simulation contract.</summary>
    DreamSimulation,
    /// <summary>预测规划契约；Prediction planning contract.</summary>
    PredictionPlanning
}
