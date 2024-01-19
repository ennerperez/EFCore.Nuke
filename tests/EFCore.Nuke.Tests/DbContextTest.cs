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
    [Order(3)]
    public class DbContextTest
    {
        [Fact, Order(1)]
        public void DbContextInfo()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new DbContextSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.DbContext.Info)
                .SetProjectFile(Path.Combine("Project", "Project.csproj")).EnableNoBuild()
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }
        [Fact, Order(2)]
        public void DbContextList()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new DbContextSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.DbContext.List)
                .SetProjectFile(Path.Combine("Project", "Project.csproj")).EnableNoBuild());
            Assert.True(result.Any());
        }
        [Fact, Order(3)]
        public void DbContextOptimize()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new DbContextSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.DbContext.Optimize)
                .SetProjectFile(Path.Combine("Project", "Project.csproj")).EnableNoBuild()
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }

        [Fact, Order(4)]
        public void DbContextScript()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new DbContextSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.DbContext.Script)
                .SetProjectFile(Path.Combine("Project", "Project.csproj"))
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }

        [Fact, Order(5)]
        public void DbContextScaffold()
        {
            if (Directory.Exists(Path.Combine("Project", "Scaffold"))) Directory.Delete(Path.Combine("Project", "Scaffold"), true);
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new DbContextSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.DbContext.Scaffold)
                .SetProjectFile(Path.Combine("Project", "Project.csproj")).EnableNoBuild()
                .SetConnection(combinations.Value).SetProvider("Microsoft.EntityFrameworkCore.Sqlite")
                .SetContextDir("Scaffold")
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }

    }
}
