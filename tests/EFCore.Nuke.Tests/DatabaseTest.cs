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
    [Order(1)]
    public class DatabaseTest
    {
        [Fact, Order(1)]
        public void DatabaseUpdate()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new DatabaseSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.Database.Update)
                .SetProjectFile(Path.Combine("Project", "Project.csproj"))
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }

        [Fact, Order(3)]
        public void DatabaseDrop()
        {
            var combinations = Methods.GetConnectionStrings(Path.Combine("Project", "appsettings.json")).FirstOrDefault();
            DotNetToolRestore();
            var result = DotNetEf(_ => new DatabaseSettings(global::Nuke.Common.Tools.DotNet.EF.Commands.Database.Drop)
                .SetProjectFile(Path.Combine("Project", "Project.csproj"))
                .EnableForce()
                .SetContext(combinations.Key));
            Assert.True(result.Any());
        }
    }
}
