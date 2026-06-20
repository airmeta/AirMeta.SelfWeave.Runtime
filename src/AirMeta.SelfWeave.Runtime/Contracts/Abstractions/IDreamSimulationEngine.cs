namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义梦境模拟引擎契约；Defines the contract for a dream simulation engine.
/// </summary>
public interface IDreamSimulationEngine
{
    /// <summary>
    /// 获取梦境模拟引擎能力声明；Gets the dream simulation engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);
}
