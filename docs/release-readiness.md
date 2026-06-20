# Release Readiness

Date: 2026-06-20

This record captures the migration readiness state for the public Runtime Contract repository.

## Scope

The repository contains only:

- Runtime constraints.
- Capability boundaries.
- Engine contract interfaces.
- Snapshot, Decision, Proposal, Capability, Compatibility, Governance, Trace, and Plugin DTOs.
- Dependency boundary and contract serialization checks.
- Public documentation.

The repository does not contain:

- Carrier workflow code.
- Data access code.
- Engine internal computation code.
- Private parameters, private samples, private traces, secrets, or package source credentials.

## Verification

Commands run:

```text
dotnet test AirMeta.SelfWeave.Runtime.slnx
dotnet pack src/AirMeta.SelfWeave.Runtime/AirMeta.SelfWeave.Runtime.csproj -c Release
```

Results:

- Contract tests passed.
- Contract package creation passed.
- Build outputs are ignored by `.gitignore`.
- `迁移计划.md` remains ignored by `.gitignore`.

Known external warning:

- NuGet vulnerability index lookup for `https://nuget.cdn.azure.cn/v3/index.json` returned `NU1900` during test restore. This did not block restore, build, tests, or package creation.

## Boundary Checks

Dependency boundary:

- Contract project has no `ProjectReference`.
- Contract project has no Air.Cloud, Entity Framework, Npgsql, Dapper, SqlSugar, repository, domain, service, or entry dependency.

Sensitive term scan:

- Matches in source and tests are negative validation fixtures or forbidden-term lists.
- Matches in documentation are explicit exclusion rules.
- No secret values, connection strings, authorization material, private samples, or private traces were found.

Source repository:

- `X:\AirMeta.SelfWeave` was read as migration input only.
- No source-repository file was modified by this migration work.
