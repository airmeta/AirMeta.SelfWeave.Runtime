# Governance Flags

Governance flags make Engine output reviewable by the Runtime.

Every Decision and Proposal must include:

- `requires_governance_review`
- `requires_manual_confirmation`
- `requires_promote_guard`
- `promotes_stable_neuron`
- `promotes_stable_synapse`
- `affects_long_term_state`
- `affects_high_risk_action`
- `trace_required`
- `fallback_safe`

Default rules:

- `requires_governance_review = true`
- `trace_required = true`
- `promotes_stable_neuron = false`
- `promotes_stable_synapse = false`

Stable-state changes require:

- Runtime governance review.
- Guard validation.
- Public Trace generation.
- Actual Engine identity in Trace.

Engine output may propose stable-state changes only as proposals. It must not claim that a stable-state change, audit result, permission decision, or lifecycle transition has already been applied.

Manual confirmation is required when a proposal affects long-term state, high-risk actions, stable-state changes, or any Runtime policy marked as human-reviewable by a carrier.
