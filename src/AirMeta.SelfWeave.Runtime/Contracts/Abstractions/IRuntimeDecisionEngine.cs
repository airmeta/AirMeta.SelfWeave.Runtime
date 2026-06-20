namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义运行时决策引擎契约；Defines the contract for a runtime decision engine.
/// </summary>
public interface IRuntimeDecisionEngine
{
    /// <summary>
    /// 获取引擎能力声明；Gets the engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 根据运行时输入和上下文生成受控决策；Creates a bounded decision from runtime input and context.
    /// </summary>
    /// <param name="input">运行时输入快照；The runtime input snapshot.</param>
    /// <param name="context">运行时上下文快照；The runtime context snapshot.</param>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>运行时决策；The runtime decision.</returns>
    ValueTask<RuntimeDecision> DecideAsync(
        RuntimeInputSnapshot input,
        RuntimeContextSnapshot context,
        CancellationToken cancellationToken = default);
}
