namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 标识生成契约输出的引擎和契约版本。</para>
/// <para>en-us: Identifies the engine and contract version that produced a contract output.</para>
/// </summary>
/// <param name="EngineId">
/// <para>zh-cn: 引擎标识 参数。</para>
/// <para>en-us: The engine id parameter.</para>
/// </param>
/// <param name="EngineVersion">
/// <para>zh-cn: 引擎版本 参数。</para>
/// <para>en-us: The engine version parameter.</para>
/// </param>
/// <param name="ContractVersion">
/// <para>zh-cn: 契约版本 参数。</para>
/// <para>en-us: The contract version parameter.</para>
/// </param>
public sealed record RuntimeContractIdentity(
    string EngineId,
    string EngineVersion,
    string ContractVersion)
{
    /// <summary>
    /// <para>zh-cn: 获取或表示 Unspecified。</para>
    /// <para>en-us: Gets or represents unspecified.</para>
    /// </summary>
    public static RuntimeContractIdentity Unspecified { get; } =
        new("unspecified", "unspecified", RuntimeContractVersions.Initial);
}
