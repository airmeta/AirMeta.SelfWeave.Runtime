namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示拓扑节点的公开引用信息；Represents public reference information for a topology node.
/// </summary>
/// <param name="NodeId">节点标识；The node identifier.</param>
/// <param name="NodeType">节点类型；The node type.</param>
/// <param name="NormalizedKey">归一化键；The normalized key.</param>
/// <param name="AbstractLevel">抽象层级；The abstraction level.</param>
/// <param name="IsSelfCore">是否属于自我核心；Whether the node belongs to the self core.</param>
public sealed record TopologyNodeRef(
    string NodeId,
    string NodeType,
    string NormalizedKey,
    int AbstractLevel,
    bool IsSelfCore);
