# Capability Boundary

Runtime public capabilities are grouped into five areas:

- `Contract`: stable Runtime-to-Engine interfaces.
- `Snapshot`: read-only Runtime input passed to an Engine.
- `Decision`: Engine judgment output.
- `Governance`: Runtime adjudication over Decisions and Proposals.
- `Trace`: public explanation records for a cognitive run.

## Contract

Input:

- Runtime-built Snapshots.
- Engine Capability declarations.
- Contract version requirements.

Output:

- Decisions.
- Proposals.
- Compatibility results.

Forbidden:

- Carrier workflow instances.
- Data access handles.
- Runtime lifecycle mutation.
- Engine internal parameters.

## Snapshot

Input:

- Runtime-owned context summaries.
- Runtime-owned provenance.
- Public references and summaries required by the runtime contract.

Output:

- Immutable, serializable, hashable DTOs.

Forbidden:

- Mutable runtime objects.
- Carrier instances.
- Executable handles.
- Private samples.

## Decision And Proposal

Input:

- Snapshot hashes.
- Engine identity.
- Contract version.

Output:

- Policy-approved explanation metadata.
- Governance flags.
- Bounded candidate outputs.

Forbidden:

- Executed state.
- Persisted state.
- Governance bypass flags.
- Manual confirmation bypass flags.
- Stable state mutation claims.

## Governance

Input:

- Decisions and Proposals.
- Governance flags.
- Runtime policy and manual confirmation state.

Output:

- Governance result.
- Guard outcome.
- Fallback decision.

Forbidden:

- Engine-owned audit replacement.
- Engine-owned permission decisions.
- Engine-owned lifecycle transitions.

## Trace

Input:

- Runtime cycle identity.
- Engine identity.
- Snapshot hash.
- Decision or proposal identity.
- Policy-approved explanation metadata.
- Governance result.

Output:

- Public audit record for the cognitive run.

Forbidden:

- Private parameters.
- Internal test vectors.
- Private samples.
- Secrets or connection material.

## Plugin

Input:

- Fixed entry point.
- Capability manifest.
- Compatibility result.
- Actual Engine identity.

Output:

- Plugin handshake accepted or rejected by Runtime.

Forbidden:

- Replacing Runtime Governance.
- Hiding actual Engine identity.
- Mutating stable Runtime state.
- Bypassing timeout, fallback, manual confirmation, or promote guard rules.

Engine capability declarations must include public metadata for:

- identity
- versions
- supported contract groups
- execution boundaries
- fallback behavior
- disclosure level

Runtime compatibility checks control whether the Runtime may call the Engine, must use fallback, must limit disclosure, or must reject the Engine for the current cycle.
