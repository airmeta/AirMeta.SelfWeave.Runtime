# Engine Contract

The public API is grouped into runtime-to-engine abstractions, immutable input DTOs, bounded output DTOs, governance
types, trace-safe audit DTOs, capability metadata, compatibility results, and plugin handshake types. Exact type names
and signatures are defined by source and generated XML documentation.

Snapshots must be immutable, serializable, hashable, and provenance-bearing. They must not carry mutable runtime objects, carrier instances, or executable handles.

Decisions and Proposals must carry the minimum identity, version, input reference, explanation, and governance metadata
required by runtime policy.

Decisions and Proposals must not carry or imply:

- `executed = true`
- `persisted = true`
- `governance_bypassed = true`
- `manual_confirmation_bypassed = true`
- `stable_state_mutated = true`
