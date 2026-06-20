# AirMeta.SelfWeave.Runtime

[简体中文](README.zh-cn.md)

`AirMeta.SelfWeave.Runtime` is the public runtime contract boundary for SelfWeave engine integration. It is the package
that open runtime hosts, commercial/private engines, and future community engines use to agree on snapshots, decisions,
proposals, version negotiation, governance flags, trace disclosure, and plugin handshakes.

## What This Repository Contains

- Public .NET runtime contracts under `src/AirMeta.SelfWeave.Runtime/Contracts`.
- Engine abstraction interfaces such as `IProjectionDecisionEngine`, `IWaveDynamicsEngine`, `ILearningPlasticityEngine`, and `ICognitiveBiasEngine`.
- Snapshot, decision, proposal, capability, compatibility, governance, trace, versioning, and plugin DTOs.
- Runtime guard helpers for serialization, dependency boundary checks, output validation, trace validation, and plugin handshakes.
- MSTest coverage for conservative governance defaults, contract compatibility, JSON round-tripping, and forbidden dependencies.
- Human-readable boundary documents under `docs/`.

## What This Repository Does Not Contain

- Runtime host implementations.
- Carrier workflow code.
- Data access code.
- Engine internal computation code.
- Private parameters, weights, thresholds, ranking rules, samples, traces, secrets, or package sources.

The runtime is the governance owner. Engines may return decisions and proposals, but they must not bypass governance,
manual confirmation, promote guards, audit results, permission decisions, or runtime lifecycle rules.

## Repository Layout

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

## Projects

- `src/AirMeta.SelfWeave.Runtime/Contracts` contains the public .NET contract package, grouped by contract responsibility.
- `tests/AirMeta.SelfWeave.Runtime.Tests` verifies default governance, version negotiation, serialization, and forbidden output states.
- `docs/` contains human-readable runtime boundary documents. Start with `docs/README.md` for the document index.

## Build And Test

Requirements:

- .NET SDK targeting `net10.0`.

Commands:

```powershell
dotnet build AirMeta.SelfWeave.Runtime.slnx --no-restore
dotnet test AirMeta.SelfWeave.Runtime.slnx --no-restore
```

If dependencies have not been restored yet, run the same commands without `--no-restore`.

## Core Contracts

The initial contract set covers:

- Projection decisions: `IProjectionDecisionEngine`.
- Wave propagation decisions: `IWaveDynamicsEngine`.
- Learning plasticity proposals: `ILearningPlasticityEngine`.
- Runtime bias decisions: `ICognitiveBiasEngine`.
- Optional future extension points for resonance, abstraction, dream simulation, and prediction planning.

Engines receive immutable snapshot DTOs and return decisions or proposals. Runtime hosts remain responsible for
validation, clamping, provenance checks, persistence, trace emission, manual confirmation, and promote guards.

## Contract Defaults

All engine decisions and proposals default to conservative governance:

- `RequiresGovernanceReview = true`
- `TraceRequired = true`
- `PromotesStableNeuron = false`
- `PromotesStableSynapse = false`

Stable neuron or synapse promotion requires runtime governance and promote guard validation. Engine output must not
claim that a decision was executed, persisted, or exempted from governance.

## Commercial Engine Boundary

Commercial or private cognitive engines can implement these contracts, but they must be loaded through a runtime host
that performs capability negotiation, compatibility checks, plugin identity validation, timeout control, and fallback.
Private engines must not receive or hold:

- `DbContext`, repository, domain, or service-provider references.
- HTTP context or background-job services.
- Stable topology write services.
- Permission, audit, manual-confirmation, or promote-guard ownership.

The runtime package defines the contract surface only; it does not ship private algorithm implementations.

## Validation

The contract test suite checks:

- Conservative governance flag defaults.
- Capability and version negotiation.
- Plugin identity and governance boundaries.
- Forbidden carrier and data access dependencies.
- Public JSON serialization of contract DTOs.

Runtime guard helpers are available through `RuntimeContractGuard`.

## Documentation

Start with:

- `docs/README.md`
- `docs/engine-contract.md`
- `docs/plugin-contract.md`
- `docs/contract-validation.md`
- `docs/runtime-constraints.md`
- `docs/private-exclusion-list.md`

Chinese integration and overview documents are also available under `docs/*.zh-cn.md`.

## License

Apache-2.0. See `LICENSE`.
