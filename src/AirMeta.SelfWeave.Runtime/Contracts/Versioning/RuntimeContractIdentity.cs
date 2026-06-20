namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 标识生成契约输出的引擎和契约版本；Identifies the engine and contract version that produced a contract output.
/// </summary>
/// <param name="EngineId">引擎唯一标识；The unique engine identifier.</param>
/// <param name="EngineVersion">引擎版本；The engine version.</param>
/// <param name="ContractVersion">运行时契约版本；The runtime contract version.</param>
public sealed record RuntimeContractIdentity(
    string EngineId,
    string EngineVersion,
    string ContractVersion)
{
    /// <summary>
    /// 未指定引擎身份时使用的保守占位身份；The conservative placeholder identity used when no engine identity is specified.
    /// </summary>
    public static RuntimeContractIdentity Unspecified { get; } =
        new("unspecified", "unspecified", RuntimeContractVersions.Initial);
}
