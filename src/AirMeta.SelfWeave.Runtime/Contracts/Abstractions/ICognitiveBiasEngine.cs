namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义认知偏置引擎契约；Defines the contract for a cognitive bias engine.
/// </summary>
public interface ICognitiveBiasEngine
{
    /// <summary>
    /// 获取认知偏置引擎能力声明；Gets the cognitive bias engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 根据偏置信号和认知上下文生成运行时偏置决策；Creates a runtime bias decision from bias signals and cognitive context.
    /// </summary>
    /// <param name="bias">运行时偏置快照；The runtime bias snapshot.</param>
    /// <param name="context">认知上下文快照；The cognitive context snapshot.</param>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>运行时偏置决策；The runtime bias decision.</returns>
    ValueTask<RuntimeBiasDecision> DecideRuntimeBiasAsync(
        RuntimeBiasSnapshot bias,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}
