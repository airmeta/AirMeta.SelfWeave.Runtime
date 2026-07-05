namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示投影引擎输入快照。</para>
/// <para>en-us: Represents a projection input snapshot.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="InputDigest">
/// <para>zh-cn: 输入摘要 参数。</para>
/// <para>en-us: The input digest parameter.</para>
/// </param>
/// <param name="CandidateNodeRefs">
/// <para>zh-cn: 候选节点引用集合 参数。</para>
/// <para>en-us: The candidate node refs parameter.</para>
/// </param>
/// <param name="CandidateRelationRefs">
/// <para>zh-cn: 候选关系引用集合 参数。</para>
/// <para>en-us: The candidate relation refs parameter.</para>
/// </param>
/// <param name="Metadata">
/// <para>zh-cn: 公开元数据。</para>
/// <para>en-us: The public metadata.</para>
/// </param>
public sealed record ProjectionInputSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    IReadOnlyList<string> CandidateNodeRefs,
    IReadOnlyList<string> CandidateRelationRefs,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示认知上下文快照。</para>
/// <para>en-us: Represents a cognitive context snapshot.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="CognitiveCycleId">
/// <para>zh-cn: 认知循环标识 参数。</para>
/// <para>en-us: The cognitive cycle id parameter.</para>
/// </param>
/// <param name="InteractionId">
/// <para>zh-cn: 交互标识 参数。</para>
/// <para>en-us: The interaction id parameter.</para>
/// </param>
/// <param name="MemoryRefs">
/// <para>zh-cn: 记忆引用集合 参数。</para>
/// <para>en-us: The memory refs parameter.</para>
/// </param>
/// <param name="GoalRefs">
/// <para>zh-cn: 目标引用集合 参数。</para>
/// <para>en-us: The goal refs parameter.</para>
/// </param>
/// <param name="RuntimeSignals">
/// <para>zh-cn: 运行时信号集合。</para>
/// <para>en-us: The runtime signal collection.</para>
/// </param>
public sealed record CognitiveContextSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string CognitiveCycleId,
    string InteractionId,
    IReadOnlyList<string> MemoryRefs,
    IReadOnlyList<string> GoalRefs,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示波动运行快照。</para>
/// <para>en-us: Represents a wave runtime snapshot.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="InitialNodeRefs">
/// <para>zh-cn: 初始节点引用集合 参数。</para>
/// <para>en-us: The initial node refs parameter.</para>
/// </param>
/// <param name="MaxRounds">
/// <para>zh-cn: 最大轮次 参数。</para>
/// <para>en-us: The max rounds parameter.</para>
/// </param>
/// <param name="InitialEnergy">
/// <para>zh-cn: 初始能量 参数。</para>
/// <para>en-us: The initial energy parameter.</para>
/// </param>
/// <param name="BiasSignals">
/// <para>zh-cn: 偏置信号集合 参数。</para>
/// <para>en-us: The bias signals parameter.</para>
/// </param>
public sealed record WaveRuntimeSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<string> InitialNodeRefs,
    int MaxRounds,
    decimal InitialEnergy,
    IReadOnlyDictionary<string, decimal> BiasSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示拓扑子图快照。</para>
/// <para>en-us: Represents a topology subgraph snapshot.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="Nodes">
/// <para>zh-cn: 节点集合 参数。</para>
/// <para>en-us: The nodes parameter.</para>
/// </param>
/// <param name="Edges">
/// <para>zh-cn: 边集合 参数。</para>
/// <para>en-us: The edges parameter.</para>
/// </param>
public sealed record TopologySubgraphSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<TopologyNodeRef> Nodes,
    IReadOnlyList<TopologyEdgeRef> Edges)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示公开拓扑节点引用。</para>
/// <para>en-us: Represents a public topology node reference.</para>
/// </summary>
/// <param name="NodeId">
/// <para>zh-cn: 节点标识 参数。</para>
/// <para>en-us: The node id parameter.</para>
/// </param>
/// <param name="NodeType">
/// <para>zh-cn: 节点类型 参数。</para>
/// <para>en-us: The node type parameter.</para>
/// </param>
/// <param name="Label">
/// <para>zh-cn: 标签 参数。</para>
/// <para>en-us: The label parameter.</para>
/// </param>
/// <param name="StabilityScore">
/// <para>zh-cn: 稳定性评分 参数。</para>
/// <para>en-us: The stability score parameter.</para>
/// </param>
/// <param name="FireThreshold">
/// <para>zh-cn: 触发阈值 参数。</para>
/// <para>en-us: The fire threshold parameter.</para>
/// </param>
/// <param name="InhibitionThreshold">
/// <para>zh-cn: 抑制阈值 参数。</para>
/// <para>en-us: The inhibition threshold parameter.</para>
/// </param>
/// <param name="IsSelfCore">
/// <para>zh-cn: 是否自我核心 参数。</para>
/// <para>en-us: The is self core parameter.</para>
/// </param>
public sealed record TopologyNodeRef(
    string NodeId,
    string NodeType,
    string Label,
    decimal StabilityScore,
    decimal FireThreshold,
    decimal InhibitionThreshold,
    bool IsSelfCore);

/// <summary>
/// <para>zh-cn: 表示公开拓扑边引用。</para>
/// <para>en-us: Represents a public topology edge reference.</para>
/// </summary>
/// <param name="EdgeId">
/// <para>zh-cn: 边标识 参数。</para>
/// <para>en-us: The edge id parameter.</para>
/// </param>
/// <param name="SourceNodeId">
/// <para>zh-cn: 来源节点标识 参数。</para>
/// <para>en-us: The source node id parameter.</para>
/// </param>
/// <param name="TargetNodeId">
/// <para>zh-cn: 目标节点标识 参数。</para>
/// <para>en-us: The target node id parameter.</para>
/// </param>
/// <param name="RelationType">
/// <para>zh-cn: 关系类型 参数。</para>
/// <para>en-us: The relation type parameter.</para>
/// </param>
/// <param name="Strength">
/// <para>zh-cn: 强度 参数。</para>
/// <para>en-us: The strength parameter.</para>
/// </param>
/// <param name="Plasticity">
/// <para>zh-cn: 可塑性 参数。</para>
/// <para>en-us: The plasticity parameter.</para>
/// </param>
public sealed record TopologyEdgeRef(
    string EdgeId,
    string SourceNodeId,
    string TargetNodeId,
    string RelationType,
    decimal Strength,
    decimal Plasticity);

/// <summary>
/// <para>zh-cn: 表示学习证据快照。</para>
/// <para>en-us: Represents a learning evidence snapshot.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="EvidenceRefs">
/// <para>zh-cn: 证据引用集合 参数。</para>
/// <para>en-us: The evidence refs parameter.</para>
/// </param>
/// <param name="MinimumEvidenceStrength">
/// <para>zh-cn: 最小证据强度 参数。</para>
/// <para>en-us: The minimum evidence strength parameter.</para>
/// </param>
/// <param name="MinimumEvidenceCount">
/// <para>zh-cn: 最小证据数量 参数。</para>
/// <para>en-us: The minimum evidence count parameter.</para>
/// </param>
public sealed record LearningEvidenceSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<LearningEvidenceRef> EvidenceRefs,
    decimal MinimumEvidenceStrength,
    int MinimumEvidenceCount)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示公开学习证据引用。</para>
/// <para>en-us: Represents a public learning evidence reference.</para>
/// </summary>
/// <param name="EvidenceId">
/// <para>zh-cn: 证据标识 参数。</para>
/// <para>en-us: The evidence id parameter.</para>
/// </param>
/// <param name="Source">
/// <para>zh-cn: 来源 参数。</para>
/// <para>en-us: The source parameter.</para>
/// </param>
/// <param name="Direction">
/// <para>zh-cn: 方向 参数。</para>
/// <para>en-us: The direction parameter.</para>
/// </param>
/// <param name="Strength">
/// <para>zh-cn: 强度 参数。</para>
/// <para>en-us: The strength parameter.</para>
/// </param>
/// <param name="QualityScore">
/// <para>zh-cn: 质量评分 参数。</para>
/// <para>en-us: The quality score parameter.</para>
/// </param>
public sealed record LearningEvidenceRef(
    string EvidenceId,
    string Source,
    string Direction,
    decimal Strength,
    decimal QualityScore);

/// <summary>
/// <para>zh-cn: 表示运行时偏置快照。</para>
/// <para>en-us: Represents a runtime bias snapshot.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="BiasSignals">
/// <para>zh-cn: 偏置信号集合 参数。</para>
/// <para>en-us: The bias signals parameter.</para>
/// </param>
/// <param name="TargetRefs">
/// <para>zh-cn: 目标引用集合 参数。</para>
/// <para>en-us: The target refs parameter.</para>
/// </param>
public sealed record RuntimeBiasSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyDictionary<string, decimal> BiasSignals,
    IReadOnlyList<string> TargetRefs)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示记忆激活候选输入快照。</para>
/// <para>en-us: Represents memory activation candidates for an engine.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="ActivatedNodeRefs">
/// <para>zh-cn: 已激活节点引用集合 参数。</para>
/// <para>en-us: The activated node refs parameter.</para>
/// </param>
/// <param name="CandidateMemories">
/// <para>zh-cn: 候选Memories 参数。</para>
/// <para>en-us: The candidate memories parameter.</para>
/// </param>
/// <param name="RuntimeSignals">
/// <para>zh-cn: 运行时信号集合。</para>
/// <para>en-us: The runtime signal collection.</para>
/// </param>
public sealed record MemoryActivationSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    IReadOnlyList<string> ActivatedNodeRefs,
    IReadOnlyList<MemoryCandidateRef> CandidateMemories,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示记忆候选引用。</para>
/// <para>en-us: Represents a memory candidate reference.</para>
/// </summary>
/// <param name="MemoryId">
/// <para>zh-cn: 记忆标识 参数。</para>
/// <para>en-us: The memory id parameter.</para>
/// </param>
/// <param name="MatchedNodeCount">
/// <para>zh-cn: 匹配节点数量 参数。</para>
/// <para>en-us: The matched node count parameter.</para>
/// </param>
/// <param name="RefWeight">
/// <para>zh-cn: 引用权重 参数。</para>
/// <para>en-us: The ref weight parameter.</para>
/// </param>
/// <param name="ActivationWeight">
/// <para>zh-cn: 激活权重 参数。</para>
/// <para>en-us: The activation weight parameter.</para>
/// </param>
public sealed record MemoryCandidateRef(
    string MemoryId,
    int MatchedNodeCount,
    decimal RefWeight,
    decimal ActivationWeight);

/// <summary>
/// <para>zh-cn: 表示本能驱动评分输入快照。</para>
/// <para>en-us: Represents instinct drive scoring input.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="InputDigest">
/// <para>zh-cn: 输入摘要 参数。</para>
/// <para>en-us: The input digest parameter.</para>
/// </param>
/// <param name="Drives">
/// <para>zh-cn: 驱动集合 参数。</para>
/// <para>en-us: The drives parameter.</para>
/// </param>
/// <param name="RuntimeSignals">
/// <para>zh-cn: 运行时信号集合。</para>
/// <para>en-us: The runtime signal collection.</para>
/// </param>
public sealed record InstinctDriveSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    IReadOnlyList<InstinctDriveRef> Drives,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示公开本能驱动引用。</para>
/// <para>en-us: Represents a public instinct drive reference.</para>
/// </summary>
/// <param name="DriveCode">
/// <para>zh-cn: 驱动代码 参数。</para>
/// <para>en-us: The drive code parameter.</para>
/// </param>
/// <param name="BaselineWeight">
/// <para>zh-cn: 基线权重 参数。</para>
/// <para>en-us: The baseline weight parameter.</para>
/// </param>
/// <param name="ActivationThreshold">
/// <para>zh-cn: 激活阈值 参数。</para>
/// <para>en-us: The activation threshold parameter.</para>
/// </param>
/// <param name="DecayRate">
/// <para>zh-cn: 衰减速率 参数。</para>
/// <para>en-us: The decay rate parameter.</para>
/// </param>
public sealed record InstinctDriveRef(
    string DriveCode,
    decimal BaselineWeight,
    decimal ActivationThreshold,
    decimal DecayRate);

/// <summary>
/// <para>zh-cn: 表示情绪人格评分输入快照。</para>
/// <para>en-us: Represents emotion and persona scoring input.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="InputDigest">
/// <para>zh-cn: 输入摘要 参数。</para>
/// <para>en-us: The input digest parameter.</para>
/// </param>
/// <param name="SemanticSummary">
/// <para>zh-cn: 语义摘要 参数。</para>
/// <para>en-us: The semantic summary parameter.</para>
/// </param>
/// <param name="RuntimeSignals">
/// <para>zh-cn: 运行时信号集合。</para>
/// <para>en-us: The runtime signal collection.</para>
/// </param>
public sealed record EmotionPersonaSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    string SemanticSummary,
    IReadOnlyDictionary<string, decimal> RuntimeSignals)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示响应规划输入快照。</para>
/// <para>en-us: Represents response planning input.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="InputDigest">
/// <para>zh-cn: 输入摘要 参数。</para>
/// <para>en-us: The input digest parameter.</para>
/// </param>
/// <param name="SelectedStrategy">
/// <para>zh-cn: 选中策略 参数。</para>
/// <para>en-us: The selected strategy parameter.</para>
/// </param>
/// <param name="ResponsePolicy">
/// <para>zh-cn: 响应策略 参数。</para>
/// <para>en-us: The response policy parameter.</para>
/// </param>
/// <param name="RuntimeSignals">
/// <para>zh-cn: 运行时信号集合。</para>
/// <para>en-us: The runtime signal collection.</para>
/// </param>
/// <param name="Metadata">
/// <para>zh-cn: 公开元数据。</para>
/// <para>en-us: The public metadata.</para>
/// </param>
public sealed record ResponsePlanningSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputDigest,
    string SelectedStrategy,
    string ResponsePolicy,
    IReadOnlyDictionary<string, decimal> RuntimeSignals,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示策略规划输入快照。</para>
/// <para>en-us: Represents strategy planning input.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="Confidence">
/// <para>zh-cn: 决策或建议的置信度。</para>
/// <para>en-us: The confidence of the decision or proposal.</para>
/// </param>
/// <param name="Uncertainty">
/// <para>zh-cn: Uncertainty 参数。</para>
/// <para>en-us: The uncertainty parameter.</para>
/// </param>
/// <param name="MemorySupport">
/// <para>zh-cn: 记忆Support 参数。</para>
/// <para>en-us: The memory support parameter.</para>
/// </param>
/// <param name="HasActivatedMemory">
/// <para>zh-cn: 是否存在已激活记忆 参数。</para>
/// <para>en-us: The has activated memory parameter.</para>
/// </param>
/// <param name="AverageMemoryActivationScore">
/// <para>zh-cn: 平均记忆激活评分 参数。</para>
/// <para>en-us: The average memory activation score parameter.</para>
/// </param>
/// <param name="LearningHypothesisStrategyBiasScore">
/// <para>zh-cn: 学习假设策略偏置评分 参数。</para>
/// <para>en-us: The learning hypothesis strategy bias score parameter.</para>
/// </param>
/// <param name="ResponseSelectedStrategy">
/// <para>zh-cn: 响应选中策略 参数。</para>
/// <para>en-us: The response selected strategy parameter.</para>
/// </param>
/// <param name="DriveScores">
/// <para>zh-cn: 驱动评分集合 参数。</para>
/// <para>en-us: The drive scores parameter.</para>
/// </param>
/// <param name="Metadata">
/// <para>zh-cn: 公开元数据。</para>
/// <para>en-us: The public metadata.</para>
/// </param>
public sealed record StrategyPlanningSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    decimal Confidence,
    decimal Uncertainty,
    decimal MemorySupport,
    bool HasActivatedMemory,
    decimal AverageMemoryActivationScore,
    decimal LearningHypothesisStrategyBiasScore,
    string? ResponseSelectedStrategy,
    IReadOnlyDictionary<string, decimal> DriveScores,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示皮层输入编排输入快照。</para>
/// <para>en-us: Represents cortical input orchestration input.</para>
/// </summary>
/// <param name="SnapshotId">
/// <para>zh-cn: 快照唯一标识。</para>
/// <para>en-us: The unique snapshot identifier.</para>
/// </param>
/// <param name="SnapshotVersion">
/// <para>zh-cn: 快照契约版本。</para>
/// <para>en-us: The snapshot contract version.</para>
/// </param>
/// <param name="SnapshotHash">
/// <para>zh-cn: 快照内容哈希。</para>
/// <para>en-us: The snapshot content hash.</para>
/// </param>
/// <param name="Provenance">
/// <para>zh-cn: 快照来源说明。</para>
/// <para>en-us: The snapshot provenance.</para>
/// </param>
/// <param name="CreatedAt">
/// <para>zh-cn: 快照创建时间。</para>
/// <para>en-us: The snapshot creation time.</para>
/// </param>
/// <param name="InputText">
/// <para>zh-cn: 输入文本 参数。</para>
/// <para>en-us: The input text parameter.</para>
/// </param>
/// <param name="DetectedIntent">
/// <para>zh-cn: Detected意图 参数。</para>
/// <para>en-us: The detected intent parameter.</para>
/// </param>
/// <param name="HasExternalCandidates">
/// <para>zh-cn: 是否存在外部候选集合 参数。</para>
/// <para>en-us: The has external candidates parameter.</para>
/// </param>
/// <param name="SuppliedCorrectedText">
/// <para>zh-cn: 外部提供纠正文本 参数。</para>
/// <para>en-us: The supplied corrected text parameter.</para>
/// </param>
/// <param name="SuppliedSemanticOptimizedText">
/// <para>zh-cn: 外部提供语义优化文本 参数。</para>
/// <para>en-us: The supplied semantic optimized text parameter.</para>
/// </param>
/// <param name="SuppliedKeyTerms">
/// <para>zh-cn: 外部提供关键词项集合 参数。</para>
/// <para>en-us: The supplied key terms parameter.</para>
/// </param>
/// <param name="SuppliedKeyNeuralChars">
/// <para>zh-cn: 外部提供关键神经字符集合 参数。</para>
/// <para>en-us: The supplied key neural chars parameter.</para>
/// </param>
/// <param name="SuppliedKeyNeuralTokens">
/// <para>zh-cn: 外部提供关键神经令牌集合 参数。</para>
/// <para>en-us: The supplied key neural tokens parameter.</para>
/// </param>
/// <param name="SuppliedKeyPhrases">
/// <para>zh-cn: 外部提供关键短语集合 参数。</para>
/// <para>en-us: The supplied key phrases parameter.</para>
/// </param>
/// <param name="SuppliedKeySentences">
/// <para>zh-cn: 外部提供关键句子集合 参数。</para>
/// <para>en-us: The supplied key sentences parameter.</para>
/// </param>
/// <param name="SuppliedEntities">
/// <para>zh-cn: 外部提供实体集合 参数。</para>
/// <para>en-us: The supplied entities parameter.</para>
/// </param>
/// <param name="SuppliedTopics">
/// <para>zh-cn: 外部提供主题集合 参数。</para>
/// <para>en-us: The supplied topics parameter.</para>
/// </param>
/// <param name="SuppliedTaskBreakdown">
/// <para>zh-cn: 外部提供任务拆解 参数。</para>
/// <para>en-us: The supplied task breakdown parameter.</para>
/// </param>
/// <param name="SuppliedAssociativeNeurons">
/// <para>zh-cn: 外部提供联想Neurons 参数。</para>
/// <para>en-us: The supplied associative neurons parameter.</para>
/// </param>
/// <param name="SuppliedNoiseTerms">
/// <para>zh-cn: 外部提供噪声词项集合 参数。</para>
/// <para>en-us: The supplied noise terms parameter.</para>
/// </param>
/// <param name="SuppliedConfidence">
/// <para>zh-cn: 外部提供Confidence 参数。</para>
/// <para>en-us: The supplied confidence parameter.</para>
/// </param>
/// <param name="Metadata">
/// <para>zh-cn: 公开元数据。</para>
/// <para>en-us: The public metadata.</para>
/// </param>
public sealed record CorticalOrchestrationSnapshot(
    string SnapshotId,
    string SnapshotVersion,
    string SnapshotHash,
    string Provenance,
    DateTimeOffset CreatedAt,
    string InputText,
    string DetectedIntent,
    bool HasExternalCandidates,
    string? SuppliedCorrectedText,
    string? SuppliedSemanticOptimizedText,
    IReadOnlyList<string> SuppliedKeyTerms,
    IReadOnlyList<string> SuppliedKeyNeuralChars,
    IReadOnlyList<string> SuppliedKeyNeuralTokens,
    IReadOnlyList<string> SuppliedKeyPhrases,
    IReadOnlyList<string> SuppliedKeySentences,
    IReadOnlyList<string> SuppliedEntities,
    IReadOnlyList<string> SuppliedTopics,
    IReadOnlyList<CorticalTaskRef> SuppliedTaskBreakdown,
    IReadOnlyList<CorticalAssociativeNeuronRef> SuppliedAssociativeNeurons,
    IReadOnlyList<string> SuppliedNoiseTerms,
    decimal? SuppliedConfidence,
    IReadOnlyDictionary<string, string> Metadata)
    : RuntimeSnapshot(SnapshotId, SnapshotVersion, SnapshotHash, Provenance, CreatedAt);

/// <summary>
/// <para>zh-cn: 表示皮层任务拆解引用。</para>
/// <para>en-us: Represents a cortical task breakdown reference.</para>
/// </summary>
/// <param name="Order">
/// <para>zh-cn: 顺序 参数。</para>
/// <para>en-us: The order parameter.</para>
/// </param>
/// <param name="Content">
/// <para>zh-cn: 内容 参数。</para>
/// <para>en-us: The content parameter.</para>
/// </param>
/// <param name="IsCognitiveArchitectureRelated">
/// <para>zh-cn: 是否认知ArchitectureRelated 参数。</para>
/// <para>en-us: The is cognitive architecture related parameter.</para>
/// </param>
/// <param name="HandlingMode">
/// <para>zh-cn: 处理模式 参数。</para>
/// <para>en-us: The handling mode parameter.</para>
/// </param>
/// <param name="GoalType">
/// <para>zh-cn: 目标类型 参数。</para>
/// <para>en-us: The goal type parameter.</para>
/// </param>
/// <param name="Reason">
/// <para>zh-cn: 原因 参数。</para>
/// <para>en-us: The reason parameter.</para>
/// </param>
public sealed record CorticalTaskRef(
    int Order,
    string Content,
    bool IsCognitiveArchitectureRelated,
    string HandlingMode,
    string GoalType,
    string Reason);

/// <summary>
/// <para>zh-cn: 表示联想神经元候选引用。</para>
/// <para>en-us: Represents an associative neuron candidate reference.</para>
/// </summary>
/// <param name="Text">
/// <para>zh-cn: 文本 参数。</para>
/// <para>en-us: The text parameter.</para>
/// </param>
/// <param name="Relation">
/// <para>zh-cn: 关系 参数。</para>
/// <para>en-us: The relation parameter.</para>
/// </param>
/// <param name="Weight">
/// <para>zh-cn: 权重 参数。</para>
/// <para>en-us: The weight parameter.</para>
/// </param>
public sealed record CorticalAssociativeNeuronRef(
    string Text,
    string Relation,
    decimal Weight);
