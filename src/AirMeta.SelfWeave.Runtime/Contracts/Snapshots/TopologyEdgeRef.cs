namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示拓扑边的公开引用信息；Represents public reference information for a topology edge.
/// </summary>
/// <param name="EdgeId">边标识；The edge identifier.</param>
/// <param name="SourceNodeId">源节点标识；The source node identifier.</param>
/// <param name="TargetNodeId">目标节点标识；The target node identifier.</param>
/// <param name="EdgeType">边类型；The edge type.</param>
public sealed record TopologyEdgeRef(
    string EdgeId,
    string SourceNodeId,
    string TargetNodeId,
    string EdgeType);
