using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet.EF.Commands;
using Nuke.Common.Tools.DotNet.EF.Tooling;

// ReSharper disable PossibleNullReferenceException

namespace Nuke.Common.Tools.DotNet.EF
{
    /// <summary>
    ///
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    public static class Extensions
    {
        #region Json

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="json"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetJson<T>(this T toolSettings, bool? json) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = json;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetJson<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableJson<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableJson<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleJson<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Json = !toolSettings.Json;
            return toolSettings;
        }

        #endregion

        #region Context

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetContext<T>(this T toolSettings, string context) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = context;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetContext<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Context = "Default";
            return toolSettings;
        }

        #endregion

        #region ProjectFile

        /// <summary>
        ///   <p><em>Sets <see cref="Settings.ProjectFile"/></em></p>
        ///   <p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p>
        /// </summary>
        [Pure]
        public static T SetProjectFile<T>(this T toolSettings, string projectFile) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = projectFile;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <see cref="Settings.ProjectFile"/></em></p>
        ///   <p>The project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p>
        /// </summary>
        [Pure]
        public static T ResetProjectFile<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ProjectFile = null;
            return toolSettings;
        }

        #endregion

        #region StartupProjectFile

        /// <summary>
        ///   <p><em>Sets <see cref="Settings.StartupProjectFile"/></em></p>
        ///   <p>The startup project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p>
        /// </summary>
        [Pure]
        public static T SetStartupProjectFile<T>(this T toolSettings, string startupProjectFile) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProjectFile = startupProjectFile;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <see cref="Settings.StartupProjectFile"/></em></p>
        ///   <p>The startup project file to build. If a project file is not specified, MSBuild searches the current working directory for a file that has a file extension that ends in proj and uses that file.</p>
        /// </summary>
        [Pure]
        public static T SetStartupProjectFile<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.StartupProjectFile = null;
            return toolSettings;
        }

        #endregion

        #region Framework

        /// <summary>
        ///   <p><em>Sets <see cref="Settings.Framework"/></em></p>
        ///   <p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p>
        /// </summary>
        [Pure]
        public static T SetFramework<T>(this T toolSettings, string framework) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = framework;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <see cref="Settings.Framework"/></em></p>
        ///   <p>Compiles for a specific <a href="https://docs.microsoft.com/en-us/dotnet/standard/frameworks">framework</a>. The framework must be defined in the <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/csproj">project file</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetFramework<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Framework = null;
            return toolSettings;
        }

        #endregion

        #region Configuration

        /// <summary>
        ///   <p><em>Sets <see cref="Settings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p>
        /// </summary>
        [Pure]
        public static T SetConfiguration<T>(this T toolSettings, string configuration) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = configuration;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <see cref="Settings.Configuration"/></em></p>
        ///   <p>Defines the build configuration. If omitted, the build configuration defaults to <c>Debug</c>. Use <c>Release</c> build a Release configuration.</p>
        /// </summary>
        [Pure]
        public static T ResetConfiguration<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Configuration = null;
            return toolSettings;
        }

        #endregion

        #region Runtime

        /// <summary>
        ///   <p><em>Sets <see cref="Settings.Runtime"/></em></p>
        ///   <p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static T SetRuntime<T>(this T toolSettings, string runtime) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = runtime;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <see cref="Settings.Runtime"/></em></p>
        ///   <p>Specifies the target runtime. For a list of Runtime Identifiers (RIDs), see the <a href="https://docs.microsoft.com/en-us/dotnet/core/rid-catalog">RID catalog</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetRuntime<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Runtime = null;
            return toolSettings;
        }

        #endregion

        #region NoBuild

        /// <summary>
        ///   <p><em>Sets <see cref="Settings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T SetNoBuild<T>(this T toolSettings, bool? noBuild) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = noBuild;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <see cref="Settings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T ResetNoBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = null;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <see cref="Settings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T EnableNoBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <see cref="Settings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T DisableNoBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <see cref="Settings.NoBuild"/></em></p>
        ///   <p>Doesn't build the project before publishing. It also implicitly sets the <c>--no-restore</c> flag.</p>
        /// </summary>
        [Pure]
        public static T ToggleNoBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoBuild = !toolSettings.NoBuild;
            return toolSettings;
        }

        #endregion

        #region Verbose

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="verbose"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetVerbose<T>(this T toolSettings, bool? verbose) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = verbose;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetVerbose<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableVerbose<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableVerbose<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleVerbose<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Verbose = !toolSettings.Verbose;
            return toolSettings;
        }

        #endregion

        #region NoColor

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="noColor"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetNoColor<T>(this T toolSettings, bool? noColor) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = noColor;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetNoColor<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableNoColor<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableNoColor<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleNoColor<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoColor = !toolSettings.NoColor;
            return toolSettings;
        }

        #endregion

        #region PrefixOutput

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="prefixOutput"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetPrefixOutput<T>(this T toolSettings, string prefixOutput) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrefixOutput = prefixOutput;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetPrefixOutput<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PrefixOutput = null;
            return toolSettings;
        }

        #endregion

        #region Connection

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="connection"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T SetConnection<T>(this T toolSettings, string connection) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DatabaseSettings).Connection = connection;
            else if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).Connection = connection;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Connection = connection;
            else
                throw new InvalidCastException(typeof(T).Namespace);

            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T ResetConnection<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DatabaseSettings).Connection = null;
            else if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DbContextSettings).Connection = null;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Connection = null;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        #endregion

        #region Force

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="force"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T SetForce<T>(this T toolSettings, bool? force) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DatabaseSettings).Force = force;
            else if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).Force = force;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Force = force;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T ResetForce<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DatabaseSettings).Force = null;
            else if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).Force = null;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Force = null;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T EnableForce<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DatabaseSettings).Force = true;
            else if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DbContextSettings).Force = true;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Force = true;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T DisableForce<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DatabaseSettings).Force = false;
            else if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DbContextSettings).Force = false;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Force = false;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T ToggleForce<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DatabaseSettings).Force = !(toolSettings as DatabaseSettings).Force;
            else if (typeof(T) == typeof(DatabaseSettings))
                (toolSettings as DbContextSettings).Force = !(toolSettings as DbContextSettings).Force;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Force = !(toolSettings as MigrationsSettings).Force;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        #endregion

        #region Namespace

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="namespace"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T SetNamespace<T>(this T toolSettings, string @namespace) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).Namespace = @namespace;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Namespace = @namespace;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T ResetNamespace<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).Namespace = null;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Namespace = null;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        #endregion

        #region OutputDir

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="outputDir"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T SetOutputDir<T>(this T toolSettings, string outputDir) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).OutputDir = outputDir;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).OutputDir = outputDir;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T ResetOutputDir<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).OutputDir = null;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).OutputDir = null;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        #endregion

        #region Output

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="output"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T SetOutput<T>(this T toolSettings, string output) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).Output = output;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Output = output;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        [Pure]
        public static T ResetOutput<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            if (typeof(T) == typeof(DbContextSettings))
                (toolSettings as DbContextSettings).Output = null;
            else if (typeof(T) == typeof(MigrationsSettings))
                (toolSettings as MigrationsSettings).Output = null;
            else
                throw new InvalidCastException(typeof(T).Namespace);
            return toolSettings;
        }

        #endregion

        #region Command

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="command"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, Database command) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }

        #endregion

        #region DryRun

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="dryRun"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetDryRun<T>(this T toolSettings, bool? dryRun) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = dryRun;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetDryRun<T>(this T toolSettings) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableDryRun<T>(this T toolSettings) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableDryRun<T>(this T toolSettings) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleDryRun<T>(this T toolSettings) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DryRun = !toolSettings.DryRun;
            return toolSettings;
        }

        #endregion

        #region Migration

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="migration"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetMigration<T>(this T toolSettings, string migration) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Migration = migration;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetMigration<T>(this T toolSettings) where T : DatabaseSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Migration = null;
            return toolSettings;
        }

        #endregion

        #region Command

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="command"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, DbContext command) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }

        #endregion

        #region Provider

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="provider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetProvider<T>(this T toolSettings, string provider) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Provider = provider;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetProvider<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Provider = null;
            return toolSettings;
        }

        #endregion

        #region NoPluralize

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="noPluralize"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetNoPluralize<T>(this T toolSettings, bool? noPluralize) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPluralize = noPluralize;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetNoPluralize<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPluralize = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableNoPluralize<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPluralize = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableNoPluralize<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPluralize = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleNoPluralize<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoPluralize = !toolSettings.NoPluralize;
            return toolSettings;
        }

        #endregion

        #region NoOnConfiguring

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="noOnConfiguring"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetNoOnConfiguring<T>(this T toolSettings, bool? noOnConfiguring) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOnConfiguring = noOnConfiguring;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetNoOnConfiguring<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOnConfiguring = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableNoOnConfiguring<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOnConfiguring = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableNoOnConfiguring<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOnConfiguring = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleNoOnConfiguring<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoOnConfiguring = !toolSettings.NoOnConfiguring;
            return toolSettings;
        }

        #endregion

        #region UseDatabaseNames

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="useDatabaseNames"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetUseDatabaseNames<T>(this T toolSettings, bool? useDatabaseNames) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = useDatabaseNames;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetUseDatabaseNames<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableUseDatabaseNames<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableUseDatabaseNames<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleUseDatabaseNames<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.UseDatabaseNames = !toolSettings.UseDatabaseNames;
            return toolSettings;
        }

        #endregion

        #region Table

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="table"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetTable<T>(this T toolSettings, string table) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Table = table;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetTable<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Table = null;
            return toolSettings;
        }

        #endregion

        #region Schema

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="schema"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetSchema<T>(this T toolSettings, string schema) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Schema = schema;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetSchema<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Schema = null;
            return toolSettings;
        }

        #endregion

        #region ContextNamespace

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="contextNamespace"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetContextNamespace<T>(this T toolSettings, string contextNamespace) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContextNamespace = contextNamespace;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetContextNamespace<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContextNamespace = null;
            return toolSettings;
        }

        #endregion

        #region ContextDir

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="contextDir"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetContextDir<T>(this T toolSettings, string contextDir) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContextDir = contextDir;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetContextDir<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.ContextDir = null;
            return toolSettings;
        }

        #endregion

        #region DataAnnotations

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="dataAnnotations"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetDataAnnotations<T>(this T toolSettings, bool? dataAnnotations) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = dataAnnotations;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetDataAnnotations<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableDataAnnotations<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableDataAnnotations<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleDataAnnotations<T>(this T toolSettings) where T : DbContextSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.DataAnnotations = !toolSettings.DataAnnotations;
            return toolSettings;
        }

        #endregion

        #region Command

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="command"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetCommand<T>(this T toolSettings, Migrations command) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Command = command;
            return toolSettings;
        }

        #endregion

        #region Name

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="name"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetName<T>(this T toolSettings, string name) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = name;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetName<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Name = null;
            return toolSettings;
        }

        #endregion

        #region TargetRuntime

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="targetRuntime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetTargetRuntime<T>(this T toolSettings, string targetRuntime) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetRuntime = targetRuntime;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetTargetRuntime<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.TargetRuntime = null;
            return toolSettings;
        }

        #endregion

        #region SelfContained

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="selfContained"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetSelfContained<T>(this T toolSettings, bool? selfContained) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = selfContained;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetSelfContained<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableSelfContained<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableSelfContained<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleSelfContained<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.SelfContained = !toolSettings.SelfContained;
            return toolSettings;
        }

        #endregion

        #region NoConnect

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="noConnect"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetNoConnect<T>(this T toolSettings, bool? noConnect) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConnect = noConnect;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetNoConnect<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConnect = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableNoConnect<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConnect = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableNoConnect<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConnect = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleNoConnect<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoConnect = !toolSettings.NoConnect;
            return toolSettings;
        }

        #endregion

        #region NoTransactions

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="noTransactions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetNoTransactions<T>(this T toolSettings, bool? noTransactions) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTransactions = noTransactions;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetNoTransactions<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTransactions = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableNoTransactions<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTransactions = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableNoTransactions<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTransactions = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleNoTransactions<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.NoTransactions = !toolSettings.NoTransactions;
            return toolSettings;
        }

        #endregion

        #region Idempotent

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="idempotent"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetIdempotent<T>(this T toolSettings, bool? idempotent) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = idempotent;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetIdempotent<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = null;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T EnableIdempotent<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = true;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T DisableIdempotent<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = false;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ToggleIdempotent<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.Idempotent = !toolSettings.Idempotent;
            return toolSettings;
        }

        #endregion

        #region To

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="to"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetTo<T>(this T toolSettings, string to) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.To = to;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetTo<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.To = null;
            return toolSettings;
        }

        #endregion

        #region From

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <param name="from"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T SetFrom<T>(this T toolSettings, string from) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.From = from;
            return toolSettings;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="toolSettings"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        [Pure]
        public static T ResetFrom<T>(this T toolSettings) where T : MigrationsSettings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.From = null;
            return toolSettings;
        }

        #endregion

        #region Properties

        /// <summary>
        ///   <p><em>Sets <see cref="Settings.Properties"/> to a new dictionary</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperties<T>(this T toolSettings, IDictionary<string, object> properties) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal = properties.ToDictionary(x => x.Key, x => x.Value, StringComparer.OrdinalIgnoreCase);
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Clears <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearProperties<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Clear();
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds a new key-value-pair <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Add(propertyKey, propertyValue);
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes a key-value-pair from <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveProperty<T>(this T toolSettings, string propertyKey) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove(propertyKey);
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Sets a key-value-pair in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetProperty<T>(this T toolSettings, string propertyKey, object propertyValue) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal[propertyKey] = propertyValue;
            return toolSettings;
        }

        #region RunCodeAnalysis

        /// <summary>
        ///   <p><em>Sets <c>RunCodeAnalysis</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRunCodeAnalysis<T>(this T toolSettings, bool? runCodeAnalysis) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = runCodeAnalysis;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>RunCodeAnalysis</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRunCodeAnalysis<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RunCodeAnalysis");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>RunCodeAnalysis</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableRunCodeAnalysis<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>RunCodeAnalysis</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableRunCodeAnalysis<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RunCodeAnalysis"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>RunCodeAnalysis</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleRunCodeAnalysis<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "RunCodeAnalysis");
            return toolSettings;
        }

        #endregion

        #region NoWarn

        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, params int[] noWarn) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Sets <c>NoWarn</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, params int[] noWarn) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>NoWarn</c> in existing <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Clears <c>NoWarn</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearNoWarns<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("NoWarn");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, params int[] noWarn) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>NoWarn</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveNoWarns<T>(this T toolSettings, IEnumerable<int> noWarn) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "NoWarn", noWarn, ';');
            return toolSettings;
        }

        #endregion

        #region WarningsAsErrors

        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Sets <c>WarningsAsErrors</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>WarningsAsErrors</c> in existing <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Clears <c>WarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearWarningsAsErrors<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningsAsErrors");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, params int[] warningsAsErrors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>WarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveWarningsAsErrors<T>(this T toolSettings, IEnumerable<int> warningsAsErrors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "WarningsAsErrors", warningsAsErrors, ';');
            return toolSettings;
        }

        #endregion

        #region WarningLevel

        /// <summary>
        ///   <p><em>Sets <c>WarningLevel</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetWarningLevel<T>(this T toolSettings, int? warningLevel) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["WarningLevel"] = warningLevel;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>WarningLevel</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetWarningLevel<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("WarningLevel");
            return toolSettings;
        }

        #endregion

        #region TreatWarningsAsErrors

        /// <summary>
        ///   <p><em>Sets <c>TreatWarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTreatWarningsAsErrors<T>(this T toolSettings, bool? treatWarningsAsErrors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = treatWarningsAsErrors;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>TreatWarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTreatWarningsAsErrors<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("TreatWarningsAsErrors");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>TreatWarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableTreatWarningsAsErrors<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>TreatWarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableTreatWarningsAsErrors<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["TreatWarningsAsErrors"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>TreatWarningsAsErrors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleTreatWarningsAsErrors<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "TreatWarningsAsErrors");
            return toolSettings;
        }

        #endregion

        #region AssemblyVersion

        /// <summary>
        ///   <p><em>Sets <c>AssemblyVersion</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAssemblyVersion<T>(this T toolSettings, string assemblyVersion) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["AssemblyVersion"] = assemblyVersion;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>AssemblyVersion</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetAssemblyVersion<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("AssemblyVersion");
            return toolSettings;
        }

        #endregion

        #region FileVersion

        /// <summary>
        ///   <p><em>Sets <c>FileVersion</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetFileVersion<T>(this T toolSettings, string fileVersion) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["FileVersion"] = fileVersion;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>FileVersion</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetFileVersion<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("FileVersion");
            return toolSettings;
        }

        #endregion

        #region InformationalVersion

        /// <summary>
        ///   <p><em>Sets <c>InformationalVersion</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetInformationalVersion<T>(this T toolSettings, string informationalVersion) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["InformationalVersion"] = informationalVersion;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>InformationalVersion</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetInformationalVersion<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("InformationalVersion");
            return toolSettings;
        }

        #endregion

        #region PackageId

        /// <summary>
        ///   <p><em>Sets <c>PackageId</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageId<T>(this T toolSettings, string packageId) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageId"] = packageId;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PackageId</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageId<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageId");
            return toolSettings;
        }

        #endregion

        #region Version

        /// <summary>
        ///   <p><em>Sets <c>Version</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersion<T>(this T toolSettings, string version) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Version"] = version;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>Version</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersion<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Version");
            return toolSettings;
        }

        #endregion

        #region VersionPrefix

        /// <summary>
        ///   <p><em>Sets <c>VersionPrefix</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetVersionPrefix<T>(this T toolSettings, string versionPrefix) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["VersionPrefix"] = versionPrefix;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>VersionPrefix</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetVersionPrefix<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("VersionPrefix");
            return toolSettings;
        }

        #endregion

        #region Authors

        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, params string[] authors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Sets <c>Authors</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, params string[] authors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>Authors</c> in existing <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Clears <c>Authors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearAuthors<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Authors");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, params string[] authors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>Authors</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemoveAuthors<T>(this T toolSettings, IEnumerable<string> authors) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "Authors", authors, ',');
            return toolSettings;
        }

        #endregion

        #region Title

        /// <summary>
        ///   <p><em>Sets <c>Title</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetTitle<T>(this T toolSettings, string title) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Title"] = title;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>Title</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetTitle<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Title");
            return toolSettings;
        }

        #endregion

        #region Description

        /// <summary>
        ///   <p><em>Sets <c>Description</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDescription<T>(this T toolSettings, string description) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Description"] = description;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>Description</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDescription<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Description");
            return toolSettings;
        }

        #endregion

        #region Copyright

        /// <summary>
        ///   <p><em>Sets <c>Copyright</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetCopyright<T>(this T toolSettings, string copyright) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Copyright"] = copyright;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>Copyright</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetCopyright<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Copyright");
            return toolSettings;
        }

        #endregion

        #region PackageRequireLicenseAcceptance

        /// <summary>
        ///   <p><em>Sets <c>PackageRequireLicenseAcceptance</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageRequireLicenseAcceptance<T>(this T toolSettings, bool? packageRequireLicenseAcceptance) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = packageRequireLicenseAcceptance;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PackageRequireLicenseAcceptance</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageRequireLicenseAcceptance<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageRequireLicenseAcceptance");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>PackageRequireLicenseAcceptance</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>PackageRequireLicenseAcceptance</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageRequireLicenseAcceptance"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>PackageRequireLicenseAcceptance</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePackageRequireLicenseAcceptance<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PackageRequireLicenseAcceptance");
            return toolSettings;
        }

        #endregion

        #region PackageLicenseUrl

        /// <summary>
        ///   <p><em>Sets <c>PackageLicenseUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageLicenseUrl<T>(this T toolSettings, string packageLicenseUrl) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageLicenseUrl"] = packageLicenseUrl;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PackageLicenseUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageLicenseUrl<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageLicenseUrl");
            return toolSettings;
        }

        #endregion

        #region PackageProjectUrl

        /// <summary>
        ///   <p><em>Sets <c>PackageProjectUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageProjectUrl<T>(this T toolSettings, string packageProjectUrl) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageProjectUrl"] = packageProjectUrl;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PackageProjectUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageProjectUrl<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageProjectUrl");
            return toolSettings;
        }

        #endregion

        #region PackageIconUrl

        /// <summary>
        ///   <p><em>Sets <c>PackageIconUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageIconUrl<T>(this T toolSettings, string packageIconUrl) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageIconUrl"] = packageIconUrl;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PackageIconUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageIconUrl<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageIconUrl");
            return toolSettings;
        }

        #endregion

        #region PackageTags

        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, params string[] packageTags) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Sets <c>PackageTags</c> in <see cref="Settings.Properties"/> to a new collection</em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.SetCollection(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, params string[] packageTags) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Adds values to <c>PackageTags</c> in existing <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T AddPackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.AddItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Clears <c>PackageTags</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ClearPackageTags<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageTags");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, params string[] packageTags) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Removes values from <c>PackageTags</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T RemovePackageTags<T>(this T toolSettings, IEnumerable<string> packageTags) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.RemoveItems(toolSettings.PropertiesInternal, "PackageTags", packageTags, ' ');
            return toolSettings;
        }

        #endregion

        #region PackageReleaseNotes

        /// <summary>
        ///   <p><em>Sets <c>PackageReleaseNotes</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPackageReleaseNotes<T>(this T toolSettings, string packageReleaseNotes) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PackageReleaseNotes"] = packageReleaseNotes;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PackageReleaseNotes</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPackageReleaseNotes<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PackageReleaseNotes");
            return toolSettings;
        }

        #endregion

        #region RepositoryUrl

        /// <summary>
        ///   <p><em>Sets <c>RepositoryUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryUrl<T>(this T toolSettings, string repositoryUrl) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryUrl"] = repositoryUrl;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>RepositoryUrl</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryUrl<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryUrl");
            return toolSettings;
        }

        #endregion

        #region RepositoryType

        /// <summary>
        ///   <p><em>Sets <c>RepositoryType</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetRepositoryType<T>(this T toolSettings, string repositoryType) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["RepositoryType"] = repositoryType;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>RepositoryType</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetRepositoryType<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("RepositoryType");
            return toolSettings;
        }

        #endregion

        #region SymbolPackageFormat

        /// <summary>
        ///   <p><em>Sets <c>SymbolPackageFormat</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T SetSymbolPackageFormat<T>(this T toolSettings, DotNetSymbolPackageFormat symbolPackageFormat) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["SymbolPackageFormat"] = symbolPackageFormat;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>SymbolPackageFormat</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Format for packaging symbols.</p>
        /// </summary>
        [Pure]
        public static T ResetSymbolPackageFormat<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("SymbolPackageFormat");
            return toolSettings;
        }

        #endregion

        #region PublishReadyToRun

        /// <summary>
        ///   <p><em>Sets <c>PublishReadyToRun</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Compiles application assemblies as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/ready-to-run">ReadyToRun images</a>. Available since .NET Core 3.0 SDK.<para/>We recommend that you specify this option in a publish profile rather than on the command line. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#msbuild">MSBuild</a>.</p>
        /// </summary>
        [Pure]
        public static T SetPublishReadyToRun<T>(this T toolSettings, bool? publishReadyToRun) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishReadyToRun"] = publishReadyToRun;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PublishReadyToRun</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Compiles application assemblies as ReadyToRun (R2R) format. R2R is a form of ahead-of-time (AOT) compilation. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/ready-to-run">ReadyToRun images</a>. Available since .NET Core 3.0 SDK.<para/>We recommend that you specify this option in a publish profile rather than on the command line. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#msbuild">MSBuild</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetPublishReadyToRun<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PublishReadyToRun");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>PublishReadyToRun</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePublishReadyToRun<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishReadyToRun"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>PublishReadyToRun</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePublishReadyToRun<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishReadyToRun"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>PublishReadyToRun</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePublishReadyToRun<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PublishReadyToRun");
            return toolSettings;
        }

        #endregion

        #region PublishSingleFile

        /// <summary>
        ///   <p><em>Sets <c>PublishSingleFile</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Packages the app into a platform-specific single-file executable. The executable is self-extracting and contains all dependencies (including native) that are required to run the app. When the app is first run, the application is extracted to a directory based on the app name and build identifier. Startup is faster when the application is run again. The application doesn't need to extract itself a second time unless a new version is used. Available since .NET Core 3.0 SDK.<para/> For more information about single-file publishing, see the <a href="https://github.com/dotnet/designs/blob/master/accepted/2020/single-file/design.md">single-file bundler design document</a>.<para/>We recommend that you specify this option in a publish profile rather than on the command line. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#msbuild">MSBuild</a>.</p>
        /// </summary>
        [Pure]
        public static T SetPublishSingleFile<T>(this T toolSettings, bool? publishSingleFile) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishSingleFile"] = publishSingleFile;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PublishSingleFile</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Packages the app into a platform-specific single-file executable. The executable is self-extracting and contains all dependencies (including native) that are required to run the app. When the app is first run, the application is extracted to a directory based on the app name and build identifier. Startup is faster when the application is run again. The application doesn't need to extract itself a second time unless a new version is used. Available since .NET Core 3.0 SDK.<para/> For more information about single-file publishing, see the <a href="https://github.com/dotnet/designs/blob/master/accepted/2020/single-file/design.md">single-file bundler design document</a>.<para/>We recommend that you specify this option in a publish profile rather than on the command line. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#msbuild">MSBuild</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetPublishSingleFile<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PublishSingleFile");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>PublishSingleFile</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePublishSingleFile<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishSingleFile"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>PublishSingleFile</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePublishSingleFile<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishSingleFile"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>PublishSingleFile</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePublishSingleFile<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PublishSingleFile");
            return toolSettings;
        }

        #endregion

        #region PublishTrimmed

        /// <summary>
        ///   <p><em>Sets <c>PublishTrimmed</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Trims unused libraries to reduce the deployment size of an app when publishing a self-contained executable. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/trim-self-contained">Trim self-contained deployments and executables</a>. Available since .NET Core 3.0 SDK as a preview feature.<para/>We recommend that you specify this option in a publish profile rather than on the command line. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#msbuild">MSBuild</a>.</p>
        /// </summary>
        [Pure]
        public static T SetPublishTrimmed<T>(this T toolSettings, bool? publishTrimmed) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishTrimmed"] = publishTrimmed;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PublishTrimmed</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Trims unused libraries to reduce the deployment size of an app when publishing a self-contained executable. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/deploying/trim-self-contained">Trim self-contained deployments and executables</a>. Available since .NET Core 3.0 SDK as a preview feature.<para/>We recommend that you specify this option in a publish profile rather than on the command line. For more information, see <a href="https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish#msbuild">MSBuild</a>.</p>
        /// </summary>
        [Pure]
        public static T ResetPublishTrimmed<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PublishTrimmed");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>PublishTrimmed</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnablePublishTrimmed<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishTrimmed"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>PublishTrimmed</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisablePublishTrimmed<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishTrimmed"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>PublishTrimmed</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T TogglePublishTrimmed<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "PublishTrimmed");
            return toolSettings;
        }

        #endregion

        #region PublishProfile

        /// <summary>
        ///   <p><em>Sets <c>PublishProfile</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPublishProfile<T>(this T toolSettings, string publishProfile) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["PublishProfile"] = publishProfile;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>PublishProfile</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPublishProfile<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("PublishProfile");
            return toolSettings;
        }

        #endregion

        #region Platform

        /// <summary>
        ///   <p><em>Sets <c>Platform</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetPlatform<T>(this T toolSettings, string platform) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Platform"] = platform;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>Platform</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetPlatform<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Platform");
            return toolSettings;
        }

        #endregion

        #region ContinuousIntegrationBuild

        /// <summary>
        ///   <p><em>Sets <c>ContinuousIntegrationBuild</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetContinuousIntegrationBuild<T>(this T toolSettings, bool? continuousIntegrationBuild) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["ContinuousIntegrationBuild"] = continuousIntegrationBuild;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>ContinuousIntegrationBuild</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetContinuousIntegrationBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("ContinuousIntegrationBuild");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>ContinuousIntegrationBuild</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableContinuousIntegrationBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["ContinuousIntegrationBuild"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>ContinuousIntegrationBuild</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableContinuousIntegrationBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["ContinuousIntegrationBuild"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>ContinuousIntegrationBuild</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleContinuousIntegrationBuild<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "ContinuousIntegrationBuild");
            return toolSettings;
        }

        #endregion

        #region DeterministicSourcePaths

        /// <summary>
        ///   <p><em>Sets <c>DeterministicSourcePaths</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDeterministicSourcePaths<T>(this T toolSettings, bool? deterministicSourcePaths) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["DeterministicSourcePaths"] = deterministicSourcePaths;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>DeterministicSourcePaths</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDeterministicSourcePaths<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("DeterministicSourcePaths");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>DeterministicSourcePaths</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableDeterministicSourcePaths<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["DeterministicSourcePaths"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>DeterministicSourcePaths</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableDeterministicSourcePaths<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["DeterministicSourcePaths"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>DeterministicSourcePaths</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleDeterministicSourcePaths<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "DeterministicSourcePaths");
            return toolSettings;
        }

        #endregion

        #region Deterministic

        /// <summary>
        ///   <p><em>Sets <c>Deterministic</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T SetDeterministic<T>(this T toolSettings, bool? deterministic) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Deterministic"] = deterministic;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Resets <c>Deterministic</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ResetDeterministic<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal.Remove("Deterministic");
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Enables <c>Deterministic</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T EnableDeterministic<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Deterministic"] = true;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Disables <c>Deterministic</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T DisableDeterministic<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            toolSettings.PropertiesInternal["Deterministic"] = false;
            return toolSettings;
        }

        /// <summary>
        ///   <p><em>Toggles <c>Deterministic</c> in <see cref="Settings.Properties"/></em></p>
        ///   <p>Set or override the specified project-level properties, where name is the property name and value is the property value. Specify each property separately, or use a semicolon or comma to separate multiple properties, as the following example shows:</p><p><c>/property:WarningLevel=2;OutDir=bin\Debug</c></p>
        /// </summary>
        [Pure]
        public static T ToggleDeterministic<T>(this T toolSettings) where T : Settings
        {
            toolSettings = toolSettings.NewInstance();
            ExtensionHelper.ToggleBoolean(toolSettings.PropertiesInternal, "Deterministic");
            return toolSettings;
        }

        #endregion

        #endregion
    }
}
