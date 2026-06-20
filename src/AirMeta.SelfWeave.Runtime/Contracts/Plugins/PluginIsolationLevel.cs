namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// 表示插件运行隔离等级；Represents plugin execution isolation levels.
/// </summary>
public enum PluginIsolationLevel
{
    /// <summary>进程内适配器；In-process adapter.</summary>
    InProcessAdapter,
    /// <summary>进程外适配器；Out-of-process adapter.</summary>
    OutOfProcessAdapter,
    /// <summary>远程适配器；Remote adapter.</summary>
    RemoteAdapter
}
