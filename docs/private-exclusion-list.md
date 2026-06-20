# Private Exclusion List

The Runtime Contract repository is intended to be publicly reviewable. It must not include private runtime, carrier, data, or Engine implementation material.

Excluded content:

- Runtime host implementations.
- Carrier workflow code.
- Data access code.
- Engine internal computation code.
- Private parameters.
- Private weights.
- Private thresholds.
- Private ranking rules.
- Internal test vectors.
- Private samples.
- Private Trace records.
- Secrets.
- Connection strings.
- Authorization files.
- Private package sources.
- Reproducible details for private effects.

Allowed content:

- Runtime terminology.
- Runtime lifecycle constraints.
- Runtime capability boundaries.
- Engine contract interfaces.
- Snapshot DTOs.
- Decision DTOs.
- Proposal DTOs.
- Capability declarations.
- Version negotiation descriptions.
- Compatibility result descriptions.
- Governance flag constraints.
- Trace contract constraints.
- Plugin contract constraints.
- Dependency boundary check rules.
- Contract serialization check rules.

When a source-repository issue is discovered during migration, it must be represented here as a target-repository contract, boundary, document, or test constraint. The source repository must not be modified as part of this migration.
