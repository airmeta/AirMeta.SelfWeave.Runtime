using AirMeta.SelfWeave.Runtime.Contracts;
using System.Text.Json;

namespace AirMeta.SelfWeave.Runtime.Tests;

[TestClass]
public sealed class RuntimeContractGuardTests
{
    [TestMethod]
    public void DecisionDefaultsRequireGovernanceAndTrace()
    {
        var decision = new ProjectionDecision(
            RuntimeContractIdentity.Unspecified,
            "decision-1",
            "hash-1",
            ["reason"],
            0.80m,
            new RuntimeGovernanceFlags(),
            ["node-1"],
            ["relation-1"]);

        var violations = RuntimeContractGuard.ValidateDecision(decision);

        Assert.IsEmpty(violations);
        Assert.IsTrue(decision.GovernanceFlags.RequiresGovernanceReview);
        Assert.IsTrue(decision.GovernanceFlags.TraceRequired);
        Assert.IsFalse(decision.GovernanceFlags.PromotesStableNeuron);
        Assert.IsFalse(decision.GovernanceFlags.PromotesStableSynapse);
    }

    [TestMethod]
    public void StablePromotionProposalRequiresPromoteGuard()
    {
        var proposal = new SynapseAdjustmentProposal(
            RuntimeContractIdentity.Unspecified,
            "proposal-1",
            "hash-1",
            ["coactivation"],
            0.71m,
            new RuntimeGovernanceFlags(PromotesStableSynapse: true),
            "source-node",
            "target-node",
            0.10m);

        var violations = RuntimeContractGuard.ValidateProposal(proposal);

        CollectionAssert.Contains(violations.ToList(), "stable_promotion_requires_governance_and_promote_guard");
    }

    [TestMethod]
    public void CompatibleCapabilityPassesVersionNegotiation()
    {
        var capability = CreateCapability();

        var result = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.ProjectionDecision,
            RuntimeContractVersions.Initial,
            RuntimeContractVersions.Initial,
            TimeSpan.FromSeconds(5));

        Assert.IsTrue(result.Compatible);
        Assert.AreEqual(CompatibilityStatus.Compatible, result.Status);
    }

    [TestMethod]
    public void DecisionSerializationDoesNotExposeExecutionState()
    {
        var decision = new RuntimeBiasDecision(
            RuntimeContractIdentity.Unspecified,
            "decision-1",
            "hash-1",
            ["bias_signal"],
            0.60m,
            new RuntimeGovernanceFlags(),
            new Dictionary<string, decimal> { ["fatigue"] = 0.1m });

        var json = RuntimeContractGuard.SerializeContract(decision);

        Assert.IsFalse(json.Contains("executed", StringComparison.OrdinalIgnoreCase));
        Assert.IsFalse(json.Contains("persisted", StringComparison.OrdinalIgnoreCase));
        Assert.IsFalse(json.Contains("governance_bypassed", StringComparison.OrdinalIgnoreCase));
        Assert.IsFalse(json.Contains("stable_state_mutated", StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void PluginHandshakeCannotReplaceRuntimeGovernance()
    {
        var capability = CreateCapability();
        var manifest = new EnginePluginManifest(
            "plugin-1",
            "Projection Plugin",
            "1.0.0",
            "ProjectionPlugin.Create",
            PluginIsolationLevel.OutOfProcessAdapter,
            TimeSpan.FromSeconds(3),
            capability);

        var handshake = new EnginePluginHandshake(
            manifest,
            new CompatibilityResult(CompatibilityStatus.Compatible, "compatible", true, false, false),
            new RuntimeContractIdentity(capability.EngineId, capability.EngineVersion, capability.ContractVersion),
            MayReplaceRuntimeGovernance: true);

        var violations = RuntimeContractGuard.ValidatePluginHandshake(handshake);

        CollectionAssert.Contains(violations.ToList(), "plugin_must_not_replace_runtime_governance");
    }

    [TestMethod]
    public void DependencyBoundaryRejectsCarrierAndDataAccessDependencies()
    {
        var violations = RuntimeContractGuard.ValidateDependencyBoundary(
            ["System.Runtime", "Air.Cloud.Core", "Npgsql"],
            ["AirMeta.SelfWeave.Runtime", "AirMeta.SelfWeave.Repository.DbContexts"]);

        CollectionAssert.Contains(violations.ToList(), "forbidden_assembly_dependency:Air.Cloud.Core");
        CollectionAssert.Contains(violations.ToList(), "forbidden_assembly_dependency:Npgsql");
        CollectionAssert.Contains(violations.ToList(), "forbidden_namespace_dependency:AirMeta.SelfWeave.Repository.DbContexts");
    }

    [TestMethod]
    public void ContractProjectDoesNotReferenceRuntimeCarrierOrDataAccessPackages()
    {
        var projectFile = FindRepositoryRoot()
            .GetFiles("AirMeta.SelfWeave.Runtime.csproj", SearchOption.AllDirectories)
            .Single(file => file.FullName.Contains(@"\src\", StringComparison.OrdinalIgnoreCase));

        var projectXml = File.ReadAllText(projectFile.FullName);

        Assert.IsFalse(projectXml.Contains("ProjectReference", StringComparison.OrdinalIgnoreCase));
        Assert.IsFalse(projectXml.Contains("PackageReference Include=\"Npgsql", StringComparison.OrdinalIgnoreCase));
        Assert.IsFalse(projectXml.Contains("PackageReference Include=\"Microsoft.EntityFrameworkCore", StringComparison.OrdinalIgnoreCase));
        Assert.IsFalse(projectXml.Contains("Air.Cloud", StringComparison.OrdinalIgnoreCase));
    }

    [TestMethod]
    public void PublicContractsRoundTripThroughJson()
    {
        var snapshot = new CognitiveContextSnapshot(
            "snapshot-1",
            RuntimeContractVersions.Initial,
            "hash-1",
            "runtime",
            DateTimeOffset.UnixEpoch,
            "cycle-1",
            "interaction-1",
            ["memory-1"],
            ["goal-1"],
            new Dictionary<string, decimal> { ["attention"] = 0.75m });

        var json = RuntimeContractGuard.SerializeContract(snapshot);
        var roundTripped = RuntimeContractGuard.DeserializeContract<CognitiveContextSnapshot>(json);

        Assert.IsNotNull(roundTripped);
        Assert.AreEqual(snapshot.SnapshotHash, roundTripped.SnapshotHash);
        Assert.AreEqual(snapshot.StateFactors["attention"], roundTripped.StateFactors["attention"]);
        using var document = JsonDocument.Parse(json);
        Assert.AreEqual(JsonValueKind.Object, document.RootElement.ValueKind);
    }

    [TestMethod]
    public void InitialSnapshotsAreSerializable()
    {
        RuntimeSnapshot[] snapshots =
        [
            new CognitiveContextSnapshot("context-1", RuntimeContractVersions.Initial, "hash-context", "runtime", DateTimeOffset.UnixEpoch, "cycle-1", "interaction-1", ["memory-1"], ["goal-1"], new Dictionary<string, decimal> { ["attention"] = 0.75m }),
            new ProjectionInputSnapshot("projection-1", RuntimeContractVersions.Initial, "hash-projection", "runtime", DateTimeOffset.UnixEpoch, "digest", ["node-1"], ["relation-1"], new Dictionary<string, string> { ["source"] = "runtime" }),
            new TopologySubgraphSnapshot("topology-1", RuntimeContractVersions.Initial, "hash-topology", "runtime", DateTimeOffset.UnixEpoch, [new TopologyNodeRef("node-1", "object", "node", 0, false)], [new TopologyEdgeRef("edge-1", "node-1", "node-2", "association")]),
            new WaveRuntimeSnapshot("wave-1", RuntimeContractVersions.Initial, "hash-wave", "runtime", DateTimeOffset.UnixEpoch, ["node-1"], 3, 1.0m, new Dictionary<string, decimal> { ["decay"] = 0.1m }),
            new LearningEvidenceSnapshot("evidence-1", RuntimeContractVersions.Initial, "hash-evidence", "runtime", DateTimeOffset.UnixEpoch, [new LearningEvidenceRef("ev-1", "hebbian_event", "support", 0.8m, 0.9m)], 0.6m, 3),
            new RuntimeBiasSnapshot("bias-1", RuntimeContractVersions.Initial, "hash-bias", "runtime", DateTimeOffset.UnixEpoch, new Dictionary<string, decimal> { ["fatigue"] = 0.1m }, ["fatigue_bias"])
        ];

        foreach (var snapshot in snapshots)
        {
            var json = RuntimeContractGuard.SerializeContract(snapshot);

            Assert.IsTrue(json.Contains("snapshotId", StringComparison.Ordinal));
            Assert.IsTrue(json.Contains("snapshotHash", StringComparison.Ordinal));
            Assert.IsFalse(json.Contains("DbContext", StringComparison.OrdinalIgnoreCase));
        }
    }

    [TestMethod]
    public void InitialDecisionsAndProposalsKeepGovernanceFields()
    {
        EngineDecision[] decisions =
        [
            new ProjectionDecision(RuntimeContractIdentity.Unspecified, "decision-projection", "hash-1", ["projection"], 0.8m, new RuntimeGovernanceFlags(), ["node-1"], ["relation-1"]),
            new WavePropagationDecision(RuntimeContractIdentity.Unspecified, "decision-wave", "hash-1", ["wave"], 0.7m, new RuntimeGovernanceFlags(), ["node-1"], ["edge-1"], "completed"),
            new RuntimeBiasDecision(RuntimeContractIdentity.Unspecified, "decision-bias", "hash-1", ["bias"], 0.6m, new RuntimeGovernanceFlags(), new Dictionary<string, decimal> { ["fatigue"] = 0.1m })
        ];

        EngineProposal[] proposals =
        [
            new SynapseAdjustmentProposal(RuntimeContractIdentity.Unspecified, "proposal-synapse", "hash-1", ["synapse"], 0.7m, new RuntimeGovernanceFlags(), "node-1", "node-2", 0.1m),
            new LearningHypothesisProposal(RuntimeContractIdentity.Unspecified, "proposal-learning", "hash-1", ["learning"], 0.65m, new RuntimeGovernanceFlags(), "provisional_synapse", "collect_more_evidence", ["evidence-1"])
        ];

        foreach (var decision in decisions)
        {
            Assert.IsEmpty(RuntimeContractGuard.ValidateDecision(decision));
            Assert.IsTrue(RuntimeContractGuard.SerializeContract(decision).Contains("governanceFlags", StringComparison.Ordinal));
        }

        foreach (var proposal in proposals)
        {
            Assert.IsEmpty(RuntimeContractGuard.ValidateProposal(proposal));
            Assert.IsTrue(RuntimeContractGuard.SerializeContract(proposal).Contains("governanceFlags", StringComparison.Ordinal));
        }
    }

    [TestMethod]
    public void CompatibilityMatrixReportsSpecificFailureReasons()
    {
        var capability = CreateCapability();

        var unsupportedContract = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.WaveDynamics,
            RuntimeContractVersions.Initial,
            RuntimeContractVersions.Initial,
            TimeSpan.FromSeconds(5));

        var unsupportedSnapshot = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.ProjectionDecision,
            "snapshot/2.0",
            RuntimeContractVersions.Initial,
            TimeSpan.FromSeconds(5));

        var unsupportedDecision = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.ProjectionDecision,
            RuntimeContractVersions.Initial,
            "decision/2.0",
            TimeSpan.FromSeconds(5));

        var timeout = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.ProjectionDecision,
            RuntimeContractVersions.Initial,
            RuntimeContractVersions.Initial,
            TimeSpan.FromMilliseconds(1));

        Assert.AreEqual(CompatibilityStatus.IncompatibleContract, unsupportedContract.Status);
        Assert.AreEqual(CompatibilityStatus.UnsupportedSnapshot, unsupportedSnapshot.Status);
        Assert.AreEqual(CompatibilityStatus.UnsupportedDecision, unsupportedDecision.Status);
        Assert.AreEqual(CompatibilityStatus.TimeoutRequired, timeout.Status);
    }

    [TestMethod]
    public void TraceValidationRejectsPrivateDisclosure()
    {
        var trace = new RuntimeTrace(
            "trace-1",
            "cycle-1",
            RuntimeContractIdentity.Unspecified,
            "hash-1",
            "decision-1",
            ["private_parameters"],
            0.7m,
            new RuntimeGovernanceFlags(),
            new GovernanceResult(GovernanceResultKind.Pending, ["review"], false, false, DateTimeOffset.UnixEpoch),
            false,
            DateTimeOffset.UnixEpoch);

        var violations = RuntimeContractGuard.ValidateTrace(trace);

        CollectionAssert.Contains(violations.ToList(), "trace_contains_forbidden_property:private_parameters");
    }

    [TestMethod]
    public void ContractSourceFilesStayInsideContractNamespace()
    {
        var root = FindRepositoryRoot();
        var sourceFiles = Directory.GetFiles(
            Path.Combine(root.FullName, "src", "AirMeta.SelfWeave.Runtime", "Contracts"),
            "*.cs",
            SearchOption.AllDirectories)
            .Where(file =>
                !file.Contains(@"\bin\", StringComparison.OrdinalIgnoreCase) &&
                !file.Contains(@"\obj\", StringComparison.OrdinalIgnoreCase))
            .ToArray();

        foreach (var sourceFile in sourceFiles)
        {
            var content = File.ReadAllText(sourceFile);

            Assert.IsTrue(content.Contains("namespace AirMeta.SelfWeave.Runtime.Contracts;", StringComparison.Ordinal));
            Assert.IsFalse(content.Contains("namespace AirMeta.SelfWeave.Repository", StringComparison.Ordinal));
            Assert.IsFalse(content.Contains("namespace AirMeta.SelfWeave.Service", StringComparison.Ordinal));
            Assert.IsFalse(content.Contains("namespace AirMeta.SelfWeave.Domain", StringComparison.Ordinal));
        }
    }

    private static EngineCapability CreateCapability()
    {
        return new EngineCapability(
            "engine-1",
            "Projection Engine",
            "1.0.0",
            RuntimeContractVersions.Initial,
            [RuntimeContractKind.ProjectionDecision],
            [RuntimeContractVersions.Initial],
            [RuntimeContractVersions.Initial],
            TimeSpan.FromSeconds(2),
            false,
            DeterminismLevel.BoundedNondeterministic,
            TraceDisclosureLevel.PublicAudit);
    }

    private static DirectoryInfo FindRepositoryRoot()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);

        while (directory is not null)
        {
            if (File.Exists(Path.Combine(directory.FullName, "AirMeta.SelfWeave.Runtime.slnx")))
            {
                return directory;
            }

            directory = directory.Parent;
        }

        throw new InvalidOperationException("Repository root was not found.");
    }
}
