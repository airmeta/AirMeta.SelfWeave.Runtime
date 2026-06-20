# AirMeta.SelfWeave.Runtime

[English](README.md)

`AirMeta.SelfWeave.Runtime` 是 SelfWeave 引擎集成的公开运行时契约边界。它只定义 Runtime host 与引擎实现之间交换不可变输入、受控输出、版本元数据、治理要求、可安全审计记录和插件握手所需的最小公开契约面。

## 本仓库包含什么

- `src/AirMeta.SelfWeave.Runtime/Contracts` 下的公开 .NET Runtime 契约。
- 按运行时职责分组的引擎抽象接口和契约 DTO。
- Snapshot、Decision、Proposal、Capability、Compatibility、Governance、Trace、Versioning、Plugin 等契约类型。
- `RuntimeContractGuard` 等运行时校验工具，用于序列化、依赖边界、输出校验、Trace 校验和插件握手校验。
- MSTest 测试，覆盖保守治理默认值、契约兼容性、JSON 往返和禁止依赖。
- `docs/` 下的运行时边界说明文档。

## 本仓库不包含什么

- Runtime host 实现。
- 业务载体流程代码。
- 数据访问代码。
- 引擎内部计算实现。
- 私有参数、调优数据、排序规则、样本、Trace、密钥或私有包源。

Runtime 是治理归属方。引擎可以返回决策和建议，但不能绕过治理、人工确认、promote guard、审计结果、权限决策或运行时生命周期规则。

## 仓库结构

```text
AirMeta.SelfWeave.Runtime.slnx
src/
  AirMeta.SelfWeave.Runtime/
    Contracts/
      Abstractions/
      Capabilities/
      Decisions/
      Governance/
      Plugins/
      Snapshots/
      Tracing/
      Validation/
      Versioning/
tests/
  AirMeta.SelfWeave.Runtime.Tests/
docs/
```

## 项目

- `src/AirMeta.SelfWeave.Runtime/Contracts`：公开 .NET 契约包，按职责拆分目录。
- `tests/AirMeta.SelfWeave.Runtime.Tests`：验证默认治理、版本协商、序列化和禁止输出状态。
- `docs/`：运行时边界说明文档，文档索引从 `docs/README.md` 开始。

## 构建与测试

要求：

- 面向 `net10.0` 的 .NET SDK。

命令：

```powershell
dotnet build AirMeta.SelfWeave.Runtime.slnx --no-restore
dotnet test AirMeta.SelfWeave.Runtime.slnx --no-restore
```

如果依赖还没有 restore，去掉 `--no-restore` 再执行。

## 核心契约

本包公开 Runtime 到引擎的抽象接口、不可变输入 DTO、受控输出 DTO、能力元数据、治理标记、可安全审计 DTO 和插件握手类型。准确 API 以源码和生成的 XML 文档为准。

引擎只接收不可变 Snapshot DTO，并返回 Decision 或 Proposal。Runtime host 继续负责校验、裁剪、provenance 检查、持久化、Trace 写入、人工确认和受控状态变更。

## 契约默认值

所有引擎 Decision 和 Proposal 默认采用保守治理：

- `RequiresGovernanceReview = true`
- `TraceRequired = true`
- `AffectsStableState = false`

稳定状态变更必须经过 Runtime governance 和 guard 校验。引擎输出不能声称某个决策已经执行、已经持久化，或可以豁免治理。

## 引擎边界

引擎实现可以使用这些契约，但必须由 Runtime host 进行加载，并完成能力协商、兼容性检查、插件身份校验、超时控制和降级处理。

引擎不能接收或持有：

- `DbContext`、Repository、Domain 或 ServiceProvider 引用。
- HTTP Context 或后台任务服务。
- 稳定状态写入服务。
- 权限、审计、人工确认或 promote guard 的所有权。

本 Runtime 包只定义契约面，不发布私有算法实现。

## 校验

契约测试覆盖：

- 保守治理标记默认值。
- Capability 和版本协商。
- 插件身份和治理边界。
- 禁止引入载体层和数据访问依赖。
- 契约 DTO 的公开 JSON 序列化。

运行时校验工具入口为 `RuntimeContractGuard`。

## 文档

建议从这些文档开始：

- `docs/README.md`
- `docs/engine-contract.md`
- `docs/plugin-contract.md`
- `docs/contract-validation.md`
- `docs/runtime-constraints.md`
- `docs/private-exclusion-list.md`

中文接入说明和总览文档位于 `docs/*.zh-cn.md`。

## 许可证

Apache-2.0。详见 `LICENSE`。
