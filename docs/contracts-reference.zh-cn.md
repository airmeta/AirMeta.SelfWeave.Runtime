# Runtime Contracts 类型参考

本文档按职责说明 `AirMeta.SelfWeave.Runtime.Contracts` 命名空间下的公开类型分组。字段、构造函数和 XML 注释以源码为准，本文不展开可用于推导内部策略的业务语义。

源码目录分组：

- `Abstractions`：接口和契约类型枚举。
- `Capabilities`：能力声明、兼容性评估和能力相关枚举。
- `Snapshots`：快照 DTO 和拓扑/证据引用 DTO。
- `Decisions`：决策和建议 DTO。
- `Governance`：治理标记和治理结果。
- `Tracing`：运行时 trace。
- `Plugins`：插件清单和握手。
- `Validation`：契约校验和依赖边界。
- `Versioning`：契约版本和身份。

## 能力与兼容性

### EngineCapability

`EngineCapability` 描述引擎对运行时公开的能力。运行时在调用任何引擎前，应先读取能力声明并做兼容性判断。

能力声明只应包含身份、版本、兼容性、执行边界和披露等级等公开元数据。不要在能力声明中放入内部策略、私有参数或运行样本。

### RuntimeCompatibility

`RuntimeCompatibility.Evaluate` 用于比较运行时需求和引擎能力声明。它不会调用引擎，也不会修改状态，只返回 `CompatibilityResult`。

兼容性结果用于告诉运行时是否可以调用、是否必须拒绝、是否需要降级或限制审计披露。调用方应按源码枚举处理具体状态。

## 引擎接口

接口分组位于 `Contracts/Abstractions`。外部文档只说明这些接口属于 Runtime 到引擎的稳定边界；具体接口清单、签名和版本以源码为准。

## 快照 DTO

快照是运行时传给引擎的只读输入。快照必须满足：

- 不可变。
- 可序列化。
- 可哈希。
- 携带来源。
- 不包含数据库、服务对象、运行时宿主对象或可执行句柄。

### RuntimeSnapshot

所有快照的基类，包含：

- `SnapshotId`
- `SnapshotVersion`
- `SnapshotHash`
- `Provenance`
- `CreatedAt`

具体快照类型位于 `Contracts/Snapshots`。公开文档只承诺这些类型是只读输入，不承诺或解释内部生成策略、选择规则、评分规则或调优含义。

## 决策与建议 DTO

### EngineDecision

所有决策的基类。决策表示引擎判断结果，但不表示运行时已经执行。

公共字段用于身份、版本、输入关联、可审计解释和治理控制。字段含义以源码 XML 文档为准。

### EngineProposal

所有建议的基类。建议比决策更明确地表达“希望运行时考虑某项变更”，但仍必须由运行时治理。

具体决策和建议类型位于 `Contracts/Decisions`。它们只表达引擎输出的候选结果，不表示运行时已经执行、持久化或批准。

## 治理与追踪

### RuntimeGovernanceFlags

治理标记随每个决策或建议返回。默认值是保守的：

- `RequiresGovernanceReview = true`
- `TraceRequired = true`
- `AffectsStableState = false`
- `FallbackSafe = true`

### GovernanceResult

表示运行时对引擎输出做出的治理结果。它属于运行时输出，不应由引擎伪造或替代。

### RuntimeTrace

表示公开审计追踪记录。Trace 只应包含公开审计所需的最小记录，实际披露字段由运行时策略和契约版本控制。

Trace 不应包含：

- 私有参数。
- 内部测试向量。
- 私有样本。
- 密钥、连接串、API key。

## 插件契约

### EnginePluginManifest

描述插件公开元数据、入口边界、隔离等级、执行边界和能力声明。

### EnginePluginHandshake

描述运行时和插件之间的握手结果。插件不能隐藏真实引擎身份，也不能声明自己可以替代运行时治理。
