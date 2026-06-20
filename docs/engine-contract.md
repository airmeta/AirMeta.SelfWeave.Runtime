# Engine Contract

Initial contracts:

- `IProjectionDecisionEngine`
- `IWaveDynamicsEngine`
- `ILearningPlasticityEngine`
- `ICognitiveBiasEngine`

Reserved contracts:

- `IResonanceDiscoveryEngine`
- `IAbstractionEngine`
- `IDreamSimulationEngine`
- `IPredictionPlanningEngine`

Snapshot DTOs:

- `CognitiveContextSnapshot`
- `ProjectionInputSnapshot`
- `TopologySubgraphSnapshot`
- `WaveRuntimeSnapshot`
- `LearningEvidenceSnapshot`
- `RuntimeBiasSnapshot`

Decision and proposal DTOs:

- `ProjectionDecision`
- `WavePropagationDecision`
- `SynapseAdjustmentProposal`
- `LearningHypothesisProposal`
- `RuntimeBiasDecision`

Snapshots must be immutable, serializable, hashable, and provenance-bearing. They must not carry mutable runtime objects, carrier instances, or executable handles.

Decisions and Proposals must carry Engine identity, contract version, decision or proposal identity, input snapshot hash, reason codes, confidence, and governance flags.

Decisions and Proposals must not carry or imply:

- `executed = true`
- `persisted = true`
- `governance_bypassed = true`
- `manual_confirmation_bypassed = true`
- `stable_state_mutated = true`
