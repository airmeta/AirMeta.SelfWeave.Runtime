# Runtime Constraints

The Runtime is the governance owner. It is not a pass-through wrapper around an Engine.

The Runtime is responsible for:

- Building immutable Snapshots.
- Calling stable Engine Contracts.
- Validating Engine output.
- Applying governance decisions.
- Generating public Trace records.
- Recording Engine identity.
- Handling unavailable, timed out, or incompatible Engines.

Engines are not allowed to:

- Bypass Governance.
- Bypass manual confirmation.
- Bypass promote guards.
- Declare that governance actions are complete.
- Declare that stable graph mutations are complete.
- Replace audit results.
- Replace permission decisions.
- Replace Runtime lifecycle state.

The Runtime repository must stay independent from carrier code, data access code, Engine internals, and private tuning data.
