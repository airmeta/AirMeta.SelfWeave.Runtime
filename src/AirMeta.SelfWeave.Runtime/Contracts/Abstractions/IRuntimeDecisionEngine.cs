namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 定义运行时决策引擎契约。</para>
/// <para>en-us: Defines the contract for a runtime decision engine.</para>
/// </summary>
public interface IRuntimeDecisionEngine
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
    /// <para>zh-cn: 根据运行时输入和上下文生成受控决策。</para>
    /// <para>en-us: Creates a bounded decision from runtime input and context.</para>
    /// </summary>
    /// <param name="input">
    /// <para>zh-cn: 运行时输入快照。</para>
    /// <para>en-us: The runtime input snapshot.</para>
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
    /// <para>zh-cn: 运行时决策。</para>
    /// <para>en-us: The runtime decision.</para>
    /// </returns>
    ValueTask<RuntimeDecision> DecideAsync(
        RuntimeInputSnapshot input,
        RuntimeContextSnapshot context,
        CancellationToken cancellationToken = default);
}
