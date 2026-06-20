# 构建、测试与发布说明

本文档说明 `AirMeta.SelfWeave.Runtime` 的本地验证、打包和发布前检查。

## 项目文件

类库项目：

```text
src/AirMeta.SelfWeave.Runtime/AirMeta.SelfWeave.Runtime.csproj
```

测试项目：

```text
tests/AirMeta.SelfWeave.Runtime.Tests/AirMeta.SelfWeave.Runtime.Tests.csproj
```

解决方案：

```text
AirMeta.SelfWeave.Runtime.slnx
```

## 包信息

当前包标识：

```xml
<PackageId>AirMeta.SelfWeave.Runtime</PackageId>
```

项目开启 XML 文档生成：

```xml
<GenerateDocumentationFile>true</GenerateDocumentationFile>
```

公开类型和成员应保持中英文双语 XML 注释，便于 NuGet 包、IDE IntelliSense 和文档站生成。

## 本地验证命令

构建：

```text
dotnet build AirMeta.SelfWeave.Runtime.slnx
```

测试：

```text
dotnet test AirMeta.SelfWeave.Runtime.slnx
```

打包：

```text
dotnet pack src/AirMeta.SelfWeave.Runtime/AirMeta.SelfWeave.Runtime.csproj -c Release
```

如果已经 restore 过，可以使用：

```text
dotnet build AirMeta.SelfWeave.Runtime.slnx --no-restore
dotnet test AirMeta.SelfWeave.Runtime.slnx --no-restore
dotnet pack src/AirMeta.SelfWeave.Runtime/AirMeta.SelfWeave.Runtime.csproj -c Release --no-restore
```

## 发布前检查清单

发布前至少确认：

- `dotnet build` 通过。
- `dotnet test` 通过。
- `dotnet pack` 通过。
- 包名为 `AirMeta.SelfWeave.Runtime`。
- `Contracts` 目录按职责分层，并保持一个公开类型一个文件。
- 公开类型、方法、属性和 record 参数具有中英文 XML 注释。
- 没有引入 Air.Cloud、数据库、Repository、Domain、Service 或 Entry 依赖。
- 没有包含私有参数、调优数据、样本、trace、密钥或连接串。
- `RuntimeContractVersions` 已反映本次契约兼容性变化。

## 版本升级规则

建议按以下规则处理版本：

- 仅新增不破坏兼容的类型或可选字段：小版本升级。
- 修改字段语义、默认治理行为、接口签名或删除字段：主版本升级。
- 只改文档、注释、测试或文件拆分：不需要改变契约版本。

## 常见警告

如果本地 NuGet 源无法访问，可能出现：

```text
NU1900: 获取包漏洞数据时出错
```

该警告表示漏洞索引源不可访问。只要 restore、build、test 和 pack 均成功，它不表示契约代码失败。
