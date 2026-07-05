namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示引擎提出但必须由运行时治理处理的受控建议。</para>
/// <para>en-us: Represents a bounded proposal emitted by an engine and governed by the runtime.</para>
/// </summary>
/// <param name="Identity">
/// <para>zh-cn: 生成输出的引擎和契约身份。</para>
/// <para>en-us: The engine and contract identity that produced the output.</para>
/// </param>
/// <param name="ProposalId">
/// <para>zh-cn: 建议唯一标识。</para>
/// <para>en-us: The unique proposal identifier.</para>
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
/// <param name="ProposalRefs">
/// <para>zh-cn: Proposal引用集合 参数。</para>
/// <para>en-us: The proposal refs parameter.</para>
/// </param>
/// <param name="Metadata">
/// <para>zh-cn: 公开元数据。</para>
/// <para>en-us: The public metadata.</para>
/// </param>
public sealed record RuntimeProposal(
    RuntimeContractIdentity Identity,
    string ProposalId,
    string InputSnapshotHash,
    IReadOnlyList<string> ExplanationRefs,
    RuntimeGovernanceFlags GovernanceFlags,
    IReadOnlyList<string> ProposalRefs,
    IReadOnlyDictionary<string, string> Metadata)
    : EngineProposal(Identity, ProposalId, InputSnapshotHash, ExplanationRefs, GovernanceFlags);
