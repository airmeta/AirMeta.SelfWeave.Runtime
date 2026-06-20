namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义抽象归纳引擎契约；Defines the contract for an abstraction engine.
/// </summary>
public interface IAbstractionEngine
{
    /// <summary>
    /// 获取抽象归纳引擎能力声明；Gets the abstraction engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);
}
