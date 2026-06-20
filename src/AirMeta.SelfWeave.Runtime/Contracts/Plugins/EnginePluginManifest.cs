namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 描述可由运行时加载或调用的引擎插件清单；Describes an engine plugin manifest loadable or callable by the runtime.
/// </summary>
/// <param name="PluginId">插件唯一标识；The unique plugin identifier.</param>
/// <param name="PluginName">插件显示名称；The human-readable plugin name.</param>
/// <param name="PluginVersion">插件版本；The plugin version.</param>
/// <param name="EntryPoint">插件入口点；The plugin entry point.</param>
/// <param name="IsolationLevel">插件隔离等级；The plugin isolation level.</param>
/// <param name="ExecutionTimeout">插件执行超时时间；The plugin execution timeout.</param>
/// <param name="Capability">插件暴露的引擎能力；The engine capability exposed by the plugin.</param>
public sealed record EnginePluginManifest(
    string PluginId,
    string PluginName,
    string PluginVersion,
    string EntryPoint,
    PluginIsolationLevel IsolationLevel,
    TimeSpan ExecutionTimeout,
    EngineCapability Capability);
