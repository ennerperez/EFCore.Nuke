using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
namespace EFCore.Nuke.Tests
{
    internal static class Methods
    {

        internal static string GetSolutionDir()
        {
            return Path.Combine("..", "..", "..", "..", "..");
        }
        internal static Dictionary<string, string> GetConnectionStrings(string path = "appsettings.json")
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(path, false, true)
                .Build();

            var connectionStrings = new Dictionary<string, string>();
            config.Bind("ConnectionStrings", connectionStrings);

            return connectionStrings;
        }
    }
}
