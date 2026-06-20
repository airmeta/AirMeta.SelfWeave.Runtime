# Plugin Contract

Plugins may connect Engines to the Runtime only through fixed contracts.

Plugin boundaries require:

- Fixed entry points.
- Fixed Runtime-to-Engine contracts.
- Version negotiation.
- Capability handshake.
- Execution timeout handling.
- Fallback on compatible failures.
- Trace records containing the actual Engine identity.
- No replacement of Runtime Governance.

Plugins must not:

- Replace Runtime permission decisions.
- Replace Runtime audit results.
- Mutate stable Runtime state without Runtime governance.
- Hide the actual Engine identity from Trace.
- Bypass manual confirmation or promote guards.

Plugin failures must be visible to the Runtime so the Runtime can reject, retry, or downgrade through its own governance flow.
