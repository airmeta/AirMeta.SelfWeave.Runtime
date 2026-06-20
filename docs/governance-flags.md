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

Stable graph promotion requires:

- Runtime governance review.
- Promote guard validation.
- Public Trace generation.
- Actual Engine identity in Trace.

Engine output may propose stable promotion only as a proposal. It must not claim that a stable neuron, stable synapse, audit result, permission decision, or lifecycle transition has already been applied.

Manual confirmation is required when a proposal affects long-term state, high-risk actions, stable graph promotion, or any Runtime policy marked as human-reviewable by a carrier.
