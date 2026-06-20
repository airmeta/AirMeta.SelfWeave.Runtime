namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示运行时对引擎能力匹配结果的判断；Represents the runtime compatibility decision for an engine capability.
/// </summary>
/// <param name="Status">兼容性状态；The compatibility status.</param>
/// <param name="ReasonCode">机器可读原因码；The machine-readable reason code.</param>
/// <param name="Compatible">是否可直接使用；Whether the engine is directly compatible.</param>
/// <param name="FallbackRequired">是否需要降级路径；Whether a fallback path is required.</param>
/// <param name="TimeoutRequired">是否因超时边界不满足而失败；Whether the check failed because of timeout requirements.</param>
public sealed record CompatibilityResult(
    CompatibilityStatus Status,
    string ReasonCode,
    bool Compatible,
    bool FallbackRequired,
    bool TimeoutRequired);
