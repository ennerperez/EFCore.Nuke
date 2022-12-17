using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Utilities.Collections;

namespace Nuke.Common.Tools.DotNet.EF.Tooling
{
    /// <summary>
    ///
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class Settings : ToolSettings
    {
        /// <summary>
        ///
        /// </summary>
        public override string ProcessToolPath => base.ProcessToolPath ?? DotNetTasks.DotNetPath;

        /// <summary>
        ///
        /// </summary>
        public override Action<OutputType, string> ProcessCustomLogger => DotNetTasks.DotNetLogger;

        /// <summary>
        ///
        /// </summary>
        public virtual bool? Json { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual string Context { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual string ProjectFile { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual string StartupProjectFile { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual string Framework { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual string Configuration { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual string Runtime { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual bool? NoBuild { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual bool? Verbose { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual bool? NoColor { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public virtual string PrefixOutput { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public virtual IReadOnlyDictionary<string, object> Properties => PropertiesInternal.AsReadOnly();
        internal Dictionary<string, object> PropertiesInternal { get; set; } = new(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        ///
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            arguments
                //.Add("ef")
                .Add("--json", Json)
                .Add("--context {value}", Context)
                .Add("--project {value}", ProjectFile)
                .Add("--startup-project {value}", StartupProjectFile)
                .Add("--framework {value}", Framework)
                .Add("--configuration {value}", Configuration)
                .Add("--runtime {value}", Runtime)
                .Add("--no-build", NoBuild)
                .Add("--verbose", Verbose)
                .Add("--no-color", NoColor)
                .Add("--prefix-output {value}", PrefixOutput)
                .Add("/property:{value}", Properties, "{key}={value}", disallowed: ';');
            return base.ConfigureProcessArguments(arguments);
        }
    }
}
