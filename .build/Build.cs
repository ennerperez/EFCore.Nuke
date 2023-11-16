using System;
using System.Linq;
using Nuke.Common;
using Nuke.Common.CI;
using Nuke.Common.Execution;
using Nuke.Common.IO;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Utilities.Collections;
using System.IO;
using System.Text.RegularExpressions;
using static Nuke.Common.EnvironmentInfo;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    public static int Main() => Execute<Build>(x => x.Pack);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")] readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;

    string _author = "Enner Pérez";
    Version _version = new("1.0.0.0");
    string _hash = string.Empty;
    string _tags = "build automation continuous-integration tools orchestration";
    string _projectUrl = "https://github.com/ennerperez/EFCore.Nuke";

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath PublishDirectory => RootDirectory / "publish";
    AbsolutePath ArtifactsDirectory => RootDirectory / "output";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(PublishDirectory);
            EnsureCleanDirectory(ArtifactsDirectory);
        });

    Target Restore => _ => _
        .Executes(() =>
        {
            DotNetToolRestore();
            DotNetRestore(s => s
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Clean)
        .DependsOn(Restore)
        .Executes(() =>
        {
            DotNetBuild(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target Pack => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            var projectInfo = Solution.GetAllProjects("*.Nuke").FirstOrDefault();
            if (projectInfo != null)
            {
                var version = "1.0.0";
                var assemblyInfoVersionFile = Path.Combine(projectInfo.Directory, "Properties", "AssemblyInfo.cs");
                if (File.Exists(assemblyInfoVersionFile))
                {
                    var content = File.ReadAllText(assemblyInfoVersionFile);
                    var regex = Regex.Match(content, "AssemblyVersion\\(\"(.*)\"\\)", RegexOptions.Compiled);
                    if (regex.Success && regex.Groups.Count > 1) version = regex.Groups[1].Value;
                }

                DotNetPack(s => s
                    .EnableNoBuild()
                    .EnableNoRestore()
                    .SetProject(projectInfo)
                    .SetConfiguration(Configuration)
                    .AddProperty("Icon", "icon.png")
                    .SetPackageId($"{projectInfo.Name}")
                    .SetVersion(version)
                    .SetTitle($"{projectInfo.Name}")
                    .SetAuthors(_author)
                    .SetDescription($"{projectInfo.Name}")
                    .SetCopyright(_author)
                    .SetPackageProjectUrl(_projectUrl)
                    .SetPackageTags(_tags)
                    .SetOutputDirectory($"{ArtifactsDirectory}"));
            }
        });
}
