# Runtime 接入指南

本文档说明 Runtime host、引擎实现或插件适配器如何接入 `AirMeta.SelfWeave.Runtime`。它只描述公开契约边界，不提供可复用的引擎实现样例。

## 接入方角色

### Runtime host

运行时宿主负责：

- 构造不可变快照。
- 选择引擎实现。
- 获取并校验引擎能力。
- 调用引擎接口。
- 校验引擎输出。
- 执行治理、人工确认、promote guard 和 fallback。
- 写入审计记录，并由运行时自身处理允许的状态变更。

### Engine

引擎负责：

- 实现一个或多个引擎接口。
- 返回能力声明。
- 读取运行时快照。
- 返回决策或建议。
- 提供运行时允许公开的解释性元数据。

引擎不负责：

- 数据库写入。
- 运行时生命周期推进。
- 权限判定。
- 治理批准。
- 人工确认。
- 稳定状态直接变更。

### Plugin adapter

插件适配器负责把进程内、进程外或远程引擎包装为固定入口。插件也必须返回能力声明和实际引擎身份。

## 推荐接入原则

接入方应按“能力声明、兼容性判断、只读输入、受控输出、运行时校验、运行时治理、最小审计”的顺序组织调用链。公开文档不提供具体引擎实现代码，避免把示例误用为业务算法或基线能力。

## 运行时调用要求

运行时调用前应完成：

1. 读取 `EngineCapability`。
2. 使用 `RuntimeCompatibility.Evaluate` 校验契约类型、快照版本、决策版本和超时限制。
3. 构造不可变快照，并生成运行时可验证的输入摘要。
4. 调用引擎接口。
5. 使用 `RuntimeContractGuard` 校验决策、建议或 trace。
6. 根据 `RuntimeGovernanceFlags` 执行治理。
7. 按运行时策略写入最小审计记录。

## 错误处理建议

运行时遇到以下情况应拒绝调用或进入 fallback：

- `IncompatibleContract`
- `UnsupportedSnapshot`
- `UnsupportedDecision`
- `TimeoutRequired`
- 插件握手身份不一致。
- 插件声明可替代运行时治理。
- 输出包含 `executed`、`persisted`、`governance_bypassed`、`stable_state_mutated` 等禁止字段。

运行时遇到以下情况可以调用但应增强审计：

- `FallbackRequired`
- `TraceLimited`
- `RequiresManualConfirmation = true`
- 需要受控状态变更校验。
- `AffectsLongTermState = true`
- `AffectsHighRiskAction = true`

## 包引用方式

项目引用示例：

```xml
<ProjectReference Include="..\..\Runtime\AirMeta.SelfWeave.Runtime\src\AirMeta.SelfWeave.Runtime\AirMeta.SelfWeave.Runtime.csproj" />
```

NuGet 包引用示例：

```xml
<PackageReference Include="AirMeta.SelfWeave.Runtime" Version="1.0.0" />
```

## 接入禁忌

- 不要从引擎项目引用 API、Repository、Domain、Service 或 Entry 项目。
- 不要把 `DbContext`、连接串、服务容器、HTTP 请求上下文传给引擎。
- 不要让引擎直接写稳定状态或治理结果。
- 不要在公开 trace 中写入私有样本、调优数据或内部测试向量。
- 不要把引擎内部算法写入该 Runtime 仓库。
