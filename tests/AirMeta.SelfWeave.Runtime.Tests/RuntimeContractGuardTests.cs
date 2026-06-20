using AirMeta.SelfWeave.Runtime.Contracts;
using System.Text.Json;

namespace AirMeta.SelfWeave.Runtime.Tests;

[TestClass]
public sealed class RuntimeContractGuardTests
{
    [TestMethod]
    public void DecisionDefaultsRequireGovernanceAndTrace()
    {
        var decision = new RuntimeDecision(
            RuntimeContractIdentity.Unspecified,
            "decision-1",
            "hash-1",
            ["explanation-ref-1"],
            new RuntimeGovernanceFlags(),
            ["output-ref-1"],
            new Dictionary<string, string> { ["scope"] = "public" });

        var violations = RuntimeContractGuard.ValidateDecision(decision);

        Assert.IsEmpty(violations);
        Assert.IsTrue(decision.GovernanceFlags.RequiresGovernanceReview);
        Assert.IsTrue(decision.GovernanceFlags.TraceRequired);
        Assert.IsFalse(decision.GovernanceFlags.AffectsStableState);
    }

    [TestMethod]
    public void StableStateProposalRequiresStateGuard()
    {
        var proposal = new RuntimeProposal(
            RuntimeContractIdentity.Unspecified,
            "proposal-1",
            "hash-1",
            ["explanation-ref-1"],
            new RuntimeGovernanceFlags(AffectsStableState: true),
            ["proposal-ref-1"],
            new Dictionary<string, string> { ["scope"] = "public" });

        var violations = RuntimeContractGuard.ValidateProposal(proposal);

        CollectionAssert.Contains(violations.ToList(), "stable_state_requires_governance_and_state_guard");
    }

    [TestMethod]
    public void CompatibleCapabilityPassesVersionNegotiation()
    {
        var capability = CreateCapability();

        var result = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.RuntimeDecision,
            RuntimeContractVersions.Initial,
            RuntimeContractVersions.Initial,
            TimeSpan.FromSeconds(5));

        Assert.IsTrue(result.Compatible);
        Assert.AreEqual(CompatibilityStatus.Compatible, result.Status);
    }

    [TestMethod]
    public void DecisionSerializationDoesNotExposeExecutionState()
    {
        var decision = new RuntimeDecision(
            RuntimeContractIdentity.Unspecified,
            "decision-1",
            "hash-1",
            ["explanation-ref-1"],
            new RuntimeGovernanceFlags(),
            ["output-ref-1"],
            new Dictionary<string, string> { ["scope"] = "public" });

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
            "Runtime Plugin",
            "1.0.0",
            "RuntimePlugin.Create",
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
        var snapshot = new RuntimeContextSnapshot(
            "snapshot-1",
            RuntimeContractVersions.Initial,
            "hash-1",
            "runtime",
            DateTimeOffset.UnixEpoch,
            "context-1",
            ["ref-1"],
            new Dictionary<string, string> { ["scope"] = "public" });

        var json = RuntimeContractGuard.SerializeContract(snapshot);
        var roundTripped = RuntimeContractGuard.DeserializeContract<RuntimeContextSnapshot>(json);

        Assert.IsNotNull(roundTripped);
        Assert.AreEqual(snapshot.SnapshotHash, roundTripped.SnapshotHash);
        Assert.AreEqual(snapshot.Metadata["scope"], roundTripped.Metadata["scope"]);
        using var document = JsonDocument.Parse(json);
        Assert.AreEqual(JsonValueKind.Object, document.RootElement.ValueKind);
    }

    [TestMethod]
    public void InitialSnapshotsAreSerializable()
    {
        RuntimeSnapshot[] snapshots =
        [
            new RuntimeContextSnapshot("context-1", RuntimeContractVersions.Initial, "hash-context", "runtime", DateTimeOffset.UnixEpoch, "context-1", ["ref-1"], new Dictionary<string, string> { ["scope"] = "public" }),
            new RuntimeInputSnapshot("input-1", RuntimeContractVersions.Initial, "hash-input", "runtime", DateTimeOffset.UnixEpoch, "digest", ["ref-1"], new Dictionary<string, string> { ["source"] = "runtime" })
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
            new RuntimeDecision(RuntimeContractIdentity.Unspecified, "decision-1", "hash-1", ["explanation-ref-1"], new RuntimeGovernanceFlags(), ["output-ref-1"], new Dictionary<string, string> { ["scope"] = "public" })
        ];

        EngineProposal[] proposals =
        [
            new RuntimeProposal(RuntimeContractIdentity.Unspecified, "proposal-1", "hash-1", ["explanation-ref-1"], new RuntimeGovernanceFlags(), ["proposal-ref-1"], new Dictionary<string, string> { ["scope"] = "public" })
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
            new EngineCapability(
                capability.EngineId,
                capability.EngineName,
                capability.EngineVersion,
                capability.ContractVersion,
                [],
                capability.SupportedSnapshotVersions,
                capability.SupportedDecisionVersions,
                capability.MaxExecutionTime,
                capability.FallbackRequired,
                capability.DeterminismLevel,
                capability.TraceDisclosureLevel),
            RuntimeContractKind.RuntimeDecision,
            RuntimeContractVersions.Initial,
            RuntimeContractVersions.Initial,
            TimeSpan.FromSeconds(5));

        var unsupportedSnapshot = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.RuntimeDecision,
            "snapshot/2.0",
            RuntimeContractVersions.Initial,
            TimeSpan.FromSeconds(5));

        var unsupportedDecision = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.RuntimeDecision,
            RuntimeContractVersions.Initial,
            "decision/2.0",
            TimeSpan.FromSeconds(5));

        var timeout = RuntimeCompatibility.Evaluate(
            capability,
            RuntimeContractKind.RuntimeDecision,
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
            "Runtime Engine",
            "1.0.0",
            RuntimeContractVersions.Initial,
            [RuntimeContractKind.RuntimeDecision],
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
