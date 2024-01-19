using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet.EF.Tooling;

namespace Nuke.Common.Tools.DotNet.EF
{
    /// <summary>
    ///
    /// </summary>
    [PublicAPI]
    public static class Tasks
    {
        /// <summary>
        ///
        /// </summary>
        [ExcludeFromCodeCoverage]
        public static string DotNetPath => ToolPathResolver.TryGetEnvironmentExecutable("DOTNET_EXE") ?? ToolPathResolver.GetPathExecutable("dotnet");

        /// <summary>
        ///
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(Configure<Settings> configurator)
        {
            return DotNetEf(configurator(new Settings()));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(Configure<DatabaseSettings> configurator)
        {
            return DotNetEf(configurator(new DatabaseSettings()));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(Configure<DbContextSettings> configurator)
        {
            return DotNetEf(configurator(new DbContextSettings()));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(Configure<MigrationsSettings> configurator)
        {
            return DotNetEf(configurator(new MigrationsSettings()));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(Settings toolSettings = null)
        {
            toolSettings = toolSettings ?? new Settings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            try
            {
                process.AssertZeroExitCode();
            }
            catch (Exception e)
            {
                throw new Exception(process.Output.LastOrDefault().Text, e);
            }
            return process.Output;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(DatabaseSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DatabaseSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            try
            {
                process.AssertZeroExitCode();
            }
            catch (Exception e)
            {
                throw new Exception(process.Output.LastOrDefault().Text, e);
            }
            return process.Output;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(DbContextSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new DbContextSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            try
            {
                process.AssertZeroExitCode();
            }
            catch (Exception e)
            {
                throw new Exception(process.Output.LastOrDefault().Text, e);
            }
            return process.Output;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <returns></returns>
        public static IReadOnlyCollection<Output> DotNetEf(MigrationsSettings toolSettings = null)
        {
            toolSettings = toolSettings ?? new MigrationsSettings();
            using var process = ProcessTasks.StartProcess(toolSettings);
            try
            {
                process.AssertZeroExitCode();
            }
            catch (Exception e)
            {
                throw new Exception(process.Output.LastOrDefault().Text, e);
            }
            return process.Output;
        }
    }
}
