namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 运行时决策契约。</para>
/// <para>en-us: Runtime decision contract.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="DecisionId">
/// <para>zh-cn: 决策唯一标识。</para>
/// <para>en-us: The unique decision identifier.</para>
/// </param>
/// <param name="InputSnapshotHash">
/// <para>zh-cn: 输入快照哈希。</para>
/// <para>en-us: The hash of the input snapshot.</para>
/// </param>
/// <param name="ExplanationRefs">
/// <para>zh-cn: 解释引用集合。</para>
/// <para>en-us: The explanation references.</para>
/// </param>
/// <param name="GovernanceFlags">
/// <para>zh-cn: 运行时治理标记。</para>
/// <para>en-us: Runtime governance flags.</para>
/// </param>
/// <param name="OutputRefs">
/// <para>zh-cn: 输出引用集合 参数。</para>
/// <para>en-us: The output refs parameter.</para>
/// </param>
/// <param name="Metadata">
/// <para>zh-cn: 公开元数据。</para>
/// <para>en-us: The public metadata.</para>
/// </param>
public sealed record RuntimeDecision(
    RuntimeContractIdentity Identity,
    string DecisionId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyList<string> OutputRefs,
    IReadOnlyDictionary<string, string> Metadata)
    : EngineDecision(Identity, DecisionId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);
