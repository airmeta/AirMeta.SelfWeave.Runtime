namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 描述运行时契约类库允许和禁止的依赖边界；Describes allowed and forbidden dependency boundaries for the runtime contract library.
/// </summary>
/// <param name="AllowedAssemblyNamePrefixes">允许的程序集名称前缀；Allowed assembly name prefixes.</param>
/// <param name="ForbiddenAssemblyNamePrefixes">禁止的程序集名称前缀；Forbidden assembly name prefixes.</param>
/// <param name="ForbiddenNamespacePrefixes">禁止的命名空间前缀；Forbidden namespace prefixes.</param>
public sealed record RuntimeDependencyBoundary(
    IReadOnlyList<string> AllowedAssemblyNamePrefixes,
    IReadOnlyList<string> ForbiddenAssemblyNamePrefixes,
    IReadOnlyList<string> ForbiddenNamespacePrefixes);
