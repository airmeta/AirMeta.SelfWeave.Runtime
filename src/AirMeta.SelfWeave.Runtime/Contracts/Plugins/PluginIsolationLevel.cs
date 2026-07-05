namespace AirMeta.SelfWeave.Runtime.Contracts;

/// <summary>
/// <para>zh-cn: 表示插件运行隔离等级。</para>
/// <para>en-us: Represents plugin execution isolation levels.</para>
/// </summary>
public enum PluginIsolationLevel
{
    /// <summary>
    /// <para>zh-cn: 进程内适配器。</para>
    /// <para>en-us: In-process adapter.</para>
    /// </summary>
    InProcessAdapter,
    /// <summary>
    /// <para>zh-cn: 进程外适配器。</para>
    /// <para>en-us: Out-of-process adapter.</para>
    /// </summary>
    OutOfProcessAdapter,
    /// <summary>
    /// <para>zh-cn: 远程适配器。</para>
    /// <para>en-us: Remote adapter.</para>
    /// </summary>
    RemoteAdapter
}
