namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 描述可由运行时加载或调用的引擎插件清单。</para>
/// <para>en-us: Describes an engine plugin manifest loadable or callable by the runtime.</para>
/// </summary>
/// <param name="PluginId">
/// <para>zh-cn: 插件标识 参数。</para>
/// <para>en-us: The plugin id parameter.</para>
/// </param>
/// <param name="PluginName">
/// <para>zh-cn: 插件名称 参数。</para>
/// <para>en-us: The plugin name parameter.</para>
/// </param>
/// <param name="PluginVersion">
/// <para>zh-cn: 插件版本 参数。</para>
/// <para>en-us: The plugin version parameter.</para>
/// </param>
/// <param name="EntryPoint">
/// <para>zh-cn: 入口点 参数。</para>
/// <para>en-us: The entry point parameter.</para>
/// </param>
/// <param name="IsolationLevel">
/// <para>zh-cn: 隔离等级 参数。</para>
/// <para>en-us: The isolation level parameter.</para>
/// </param>
/// <param name="ExecutionTimeout">
/// <para>zh-cn: 执行超时 参数。</para>
/// <para>en-us: The execution timeout parameter.</para>
/// </param>
/// <param name="Capability">
/// <para>zh-cn: 待评估的引擎能力声明。</para>
/// <para>en-us: The engine capability declaration to evaluate.</para>
/// </param>
public sealed record EnginePluginManifest(
    string PluginId,
    string PluginName,
    string PluginVersion,
    string EntryPoint,
    PluginIsolationLevel IsolationLevel,
    TimeSpan ExecutionTimeout,
    EngineCapability Capability);
