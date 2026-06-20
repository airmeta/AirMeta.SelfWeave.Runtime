namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示学习证据的公开引用和质量信息；Represents public reference and quality information for learning evidence.
/// </summary>
/// <param name="EvidenceId">证据标识；The evidence identifier.</param>
/// <param name="SourceType">证据来源类型；The evidence source type.</param>
/// <param name="Direction">证据方向；The evidence direction.</param>
/// <param name="Strength">证据强度；The evidence strength.</param>
/// <param name="QualityScore">证据质量分数；The evidence quality score.</param>
public sealed record LearningEvidenceRef(
    string EvidenceId,
    string SourceType,
    string Direction,
    decimal Strength,
    decimal QualityScore);
