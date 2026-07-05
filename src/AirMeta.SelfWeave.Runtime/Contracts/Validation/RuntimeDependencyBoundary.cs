namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 描述运行时契约类库允许和禁止的依赖边界。</para>
/// <para>en-us: Describes allowed and forbidden dependency boundaries for the runtime contract library.</para>
/// </summary>
/// <param name="AllowedAssemblyNamePrefixes">
/// <para>zh-cn: 允许程序集名称前缀集合 参数。</para>
/// <para>en-us: The allowed assembly name prefixes parameter.</para>
/// </param>
/// <param name="ForbiddenAssemblyNamePrefixes">
/// <para>zh-cn: 禁止程序集名称前缀集合 参数。</para>
/// <para>en-us: The forbidden assembly name prefixes parameter.</para>
/// </param>
/// <param name="ForbiddenNamespacePrefixes">
/// <para>zh-cn: 禁止命名空间前缀集合 参数。</para>
/// <para>en-us: The forbidden namespace prefixes parameter.</para>
/// </param>
public sealed record RuntimeDependencyBoundary(
    IReadOnlyList<string> AllowedAssemblyNamePrefixes,
    IReadOnlyList<string> ForbiddenAssemblyNamePrefixes,
    IReadOnlyList<string> ForbiddenNamespacePrefixes);
