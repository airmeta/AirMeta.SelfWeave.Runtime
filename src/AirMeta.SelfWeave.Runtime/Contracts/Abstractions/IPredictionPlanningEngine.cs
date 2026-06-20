namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义预测规划引擎契约；Defines the contract for a prediction planning engine.
/// </summary>
public interface IPredictionPlanningEngine
{
    /// <summary>
    /// 获取预测规划引擎能力声明；Gets the prediction planning engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);
}
