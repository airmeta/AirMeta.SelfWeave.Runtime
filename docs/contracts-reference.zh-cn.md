# Runtime Contracts 类型参考

本文档按职责说明 `AirMeta.SelfWeave.Runtime.Contracts` 命名空间下的公开类型。源码文件位于 `src/AirMeta.SelfWeave.Runtime/Contracts`，按职责分目录，并保持每个公开类型一个文件。

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

关键字段：

- `EngineId`：引擎唯一标识，应稳定且可进入 trace。
- `EngineName`：引擎显示名称。
- `EngineVersion`：引擎实现版本。
- `ContractVersion`：引擎实现的运行时契约版本。
- `SupportedContracts`：引擎支持的契约类型。
- `SupportedSnapshotVersions`：可读取的快照版本。
- `SupportedDecisionVersions`：可输出的决策版本。
- `MaxExecutionTime`：引擎声明的最长执行时间。
- `FallbackRequired`：运行时是否必须准备降级路径。
- `DeterminismLevel`：输出确定性等级。
- `TraceDisclosureLevel`：允许公开的追踪披露等级。

### RuntimeCompatibility

`RuntimeCompatibility.Evaluate` 用于比较运行时需求和引擎能力声明。它不会调用引擎，也不会修改状态，只返回 `CompatibilityResult`。

可能结果：

- `Compatible`：可以直接调用。
- `IncompatibleContract`：契约类型不匹配。
- `UnsupportedSnapshot`：快照版本不受支持。
- `UnsupportedDecision`：决策版本不受支持。
- `TimeoutRequired`：引擎最长执行时间超过运行时限制。
- `FallbackRequired`：可调用，但运行时必须准备降级。
- `TraceLimited`：可调用，但 trace 披露受限。

## 引擎接口

### 已启用接口

- `IProjectionDecisionEngine`：根据投影输入和认知上下文生成投影决策。
- `IWaveDynamicsEngine`：根据波运行快照和拓扑子图生成波传播决策。
- `ILearningPlasticityEngine`：根据学习证据提出突触调整或学习假设建议。
- `ICognitiveBiasEngine`：根据偏置信号和认知上下文生成运行时偏置决策。

### 预留接口

- `IResonanceDiscoveryEngine`
- `IAbstractionEngine`
- `IDreamSimulationEngine`
- `IPredictionPlanningEngine`

预留接口当前只定义能力声明方法，用于固定未来扩展入口。新增正式方法前应先更新契约版本和文档。

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

### CognitiveContextSnapshot

表示认知循环上下文，包含循环、交互、记忆引用、目标引用和状态因子。它用于让引擎理解当前输入所在的运行时上下文，但不允许引擎拿到可变运行时对象。

### ProjectionInputSnapshot

表示投影决策输入，包含输入摘要、候选节点、候选关系和上下文引用。它用于投影类引擎判断当前输入可能关联哪些公开节点或关系。

### TopologySubgraphSnapshot

表示运行时截取的拓扑子图，由 `TopologyNodeRef` 和 `TopologyEdgeRef` 组成。它只提供公开引用和必要元数据，不提供底层存储结构。

### WaveRuntimeSnapshot

表示波传播计算输入，包括初始节点、最大轮次、初始能量和运行时权重。

### LearningEvidenceSnapshot

表示学习可塑性判断输入，包括证据引用、最低证据强度和最低证据数量。

### RuntimeBiasSnapshot

表示运行时偏置判断输入，包括偏置信号和偏置原因码。

## 决策与建议 DTO

### EngineDecision

所有决策的基类。决策表示引擎判断结果，但不表示运行时已经执行。

公共字段：

- `Identity`
- `DecisionId`
- `InputSnapshotHash`
- `ReasonCodes`
- `Confidence`
- `GovernanceFlags`

### EngineProposal

所有建议的基类。建议比决策更明确地表达“希望运行时考虑某项变更”，但仍必须由运行时治理。

### ProjectionDecision

投影决策，输出建议节点引用和关系引用。

### WavePropagationDecision

波传播决策，输出激活节点、激活边和停止原因。

### RuntimeBiasDecision

运行时偏置决策，输出偏置因子调整建议。

### SynapseAdjustmentProposal

突触调整建议，描述源节点、目标节点和建议权重变化量。稳定突触提升必须经过运行时治理和 promote guard。

### LearningHypothesisProposal

学习假设建议，描述假设类型、建议动作和证据引用。

## 治理与追踪

### RuntimeGovernanceFlags

治理标记随每个决策或建议返回。默认值是保守的：

- `RequiresGovernanceReview = true`
- `TraceRequired = true`
- `PromotesStableNeuron = false`
- `PromotesStableSynapse = false`
- `FallbackSafe = true`

### GovernanceResult

表示运行时对引擎输出做出的治理结果。它属于运行时输出，不应由引擎伪造或替代。

### RuntimeTrace

表示公开审计追踪记录。Trace 应包含引擎真实身份、输入快照哈希、决策标识、原因码、置信度、治理结果和是否降级。

Trace 不应包含：

- 私有参数。
- 内部测试向量。
- 私有样本。
- 密钥、连接串、API key。

## 插件契约

### EnginePluginManifest

描述插件标识、版本、入口点、隔离等级、执行超时和能力声明。

### EnginePluginHandshake

描述运行时和插件之间的握手结果。插件不能隐藏真实引擎身份，也不能声明自己可以替代运行时治理。
