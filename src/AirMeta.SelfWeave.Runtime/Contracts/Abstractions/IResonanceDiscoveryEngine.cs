namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义共振发现引擎契约；Defines the contract for a resonance discovery engine.
/// </summary>
public interface IResonanceDiscoveryEngine
{
    /// <summary>
    /// 获取共振发现引擎能力声明；Gets the resonance discovery engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);
}
