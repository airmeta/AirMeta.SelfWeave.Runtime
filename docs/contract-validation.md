# Contract Validation

Runtime contracts are validated without depending on carrier code, database access, Engine internals, or private runtime state.

## Dependency Boundary

The contract package may depend on platform assemblies needed for immutable DTOs, async contracts, and JSON serialization.

It must not reference:

- `Air.Cloud`
- Entity Framework
- `Npgsql`
- `Dapper`
- `SqlSugar`
- SelfWeave repository, domain, service, or entry assemblies

Forbidden namespaces include:

- `Microsoft.EntityFrameworkCore`
- `System.Data`
- `Air.Cloud`
- `AirMeta.SelfWeave.Repository`
- `AirMeta.SelfWeave.Domain`
- `AirMeta.SelfWeave.Service`
- `AirMeta.SelfWeave.Entry`

Dependency checks are contract checks. They do not repair the source repository and do not modify carrier code.

## Serialization Boundary

Snapshots, Decisions, Proposals, Capability declarations, Compatibility results, Governance results, Trace records, and Plugin handshakes must serialize as public contract JSON.

Serialized Engine output must not expose or imply:

- `executed`
- `persisted`
- `governance_bypassed`
- `manual_confirmation_bypassed`
- `stable_state_mutated`

Serialized Trace records must not expose:

- Private parameters.
- Internal test vectors.
- Private samples.
- Secrets, API keys, or connection strings.

The Runtime is responsible for validating serialized contracts before using Engine output in governance or public Trace records.
