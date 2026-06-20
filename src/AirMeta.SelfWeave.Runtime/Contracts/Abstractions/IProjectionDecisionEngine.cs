namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 定义投影决策引擎契约；Defines the contract for a projection decision engine.
/// </summary>
public interface IProjectionDecisionEngine
{
    /// <summary>
    /// 获取投影引擎能力声明；Gets the projection engine capability declaration.
    /// </summary>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>引擎能力声明；The engine capability declaration.</returns>
    ValueTask<EngineCapability> GetCapabilityAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 根据投影输入和认知上下文生成投影决策；Creates a projection decision from projection input and cognitive context.
    /// </summary>
    /// <param name="projection">投影输入快照；The projection input snapshot.</param>
    /// <param name="context">认知上下文快照；The cognitive context snapshot.</param>
    /// <param name="cancellationToken">取消异步操作的令牌；The token used to cancel the asynchronous operation.</param>
    /// <returns>投影决策；The projection decision.</returns>
    ValueTask<ProjectionDecision> DecideProjectionAsync(
        ProjectionInputSnapshot projection,
        CognitiveContextSnapshot context,
        CancellationToken cancellationToken = default);
}
