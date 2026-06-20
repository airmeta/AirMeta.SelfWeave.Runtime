namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义学习可塑性引擎契约；Defines the contract for a learning plasticity engine.
/// </summary>
public interface ILearningPlasticityEngine
{
    /// <summary>
    /// 获取学习可塑性引擎能力声明；Gets the learning plasticity engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 根据学习证据和拓扑子图提出突触调整建议；Proposes a synapse adjustment from learning evidence and topology snapshots.
    /// </summary>
    /// <param name="evidence">学习证据快照；The learning evidence snapshot.</param>
    /// <param name="topology">拓扑子图快照；The topology subgraph snapshot.</param>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>突触调整建议；The synapse adjustment proposal.</returns>
    ValueTask<SynapseAdjustmentProposal> ProposeSynapseAdjustmentAsync(
        LearningEvidenceSnapshot evidence,
        TopologySubgraphSnapshot topology,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// 根据学习证据和认知上下文提出学习假设；Proposes a learning hypothesis from learning evidence and cognitive context.
    /// </summary>
    /// <param name="evidence">学习证据快照；The learning evidence snapshot.</param>
    /// <param name="context">认知上下文快照；The cognitive context snapshot.</param>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>学习假设建议；The learning hypothesis proposal.</returns>
    ValueTask<LearningHypothesisProposal> ProposeLearningHypothesisAsync(
        LearningEvidenceSnapshot evidence,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}
