using System;
using System.IO;
using System.Linq;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet.EF;
using Nuke.Common.Tools.DotNet.EF.Commands;
using Xunit;
using Xunit.Extensions.Ordering;
using static Nuke.Common.Tools.DotNet.EF.Tasks;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
namespace EFCore.Nuke.Tests
{
    [Order(2)]
    public class MigrationsTest
    {
        [Fact, Order(1)]
        public void MigrationAdd()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new MigrationsSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.Migrations.Add)
                .SetProjectFile(Path.Combine("Project", "Project.csproj")).EnableNoBuild()
                .SetName(DateTime.Now.Ticks.ToString())
                .SetContext(combinations.Key)
                .SetOutputDir("Migrations"));
            Assert.True(result.Any());
        }

        [Fact, Order(2)]
        public void MigrationList()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new MigrationsSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.Migrations.List)
                .SetProjectFile(Path.Combine("Project", "Project.csproj")).EnableNoBuild()
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }

        [Fact, Order(3)]
        public void MigrationBundle()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new MigrationsSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.Migrations.Bundle)
                .SetProjectFile(Path.Combine("Project", "Project.csproj")).EnableNoBuild()
                .EnableForce()
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }

        [Fact, Order(4)]
        public void MigrationScript()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new MigrationsSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.Migrations.Script)
                .SetProjectFile(Path.Combine("Project", "Project.csproj"))
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }

        [Fact, Order(5)]
        public void MigrationRemove()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new MigrationsSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.Migrations.Remove)
                .SetProjectFile(Path.Combine("Project", "Project.csproj"))
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }
    }
}
