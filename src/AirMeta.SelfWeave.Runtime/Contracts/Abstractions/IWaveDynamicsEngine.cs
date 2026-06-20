namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义波动力传播引擎契约；Defines the contract for a wave dynamics engine.
/// </summary>
public interface IWaveDynamicsEngine
{
    /// <summary>
    /// 获取波动力引擎能力声明；Gets the wave dynamics engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 根据波运行快照和拓扑子图生成传播决策；Creates a wave propagation decision from wave runtime and topology snapshots.
    /// </summary>
    /// <param name="wave">波运行快照；The wave runtime snapshot.</param>
    /// <param name="topology">拓扑子图快照；The topology subgraph snapshot.</param>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>波传播决策；The wave propagation decision.</returns>
    ValueTask<WavePropagationDecision> DecideWavePropagationAsync(
        WaveRuntimeSnapshot wave,
        TopologySubgraphSnapshot topology,
        CancellationToken cancellationToken = default);
}
