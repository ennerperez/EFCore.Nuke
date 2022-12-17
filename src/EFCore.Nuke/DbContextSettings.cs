using System;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet.EF.Commands;
using Nuke.Common.Tools.DotNet.EF.Tooling;

namespace Nuke.Common.Tools.DotNet.EF
{
    /// <summary>
    ///
    /// </summary>
    [PublicAPI]
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class DbContextSettings : Settings
    {
        /// <summary>
        ///
        /// </summary>
        public DbContextSettings()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        public DbContextSettings(DbContext command) : this()
        {
            Command = command;
        }

        /// <summary>
        ///
        /// </summary>
        public DbContext Command { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public string OutputDir { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Namespace { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public string Provider { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Connection { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public bool? NoPluralize { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? NoOnConfiguring { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? UseDatabaseNames { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Table { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Schema { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? Force { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string ContextNamespace { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string ContextDir { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? DataAnnotations { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public string Output { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        protected override Arguments ConfigureProcessArguments(Arguments arguments)
        {
            switch (Command)
            {
                case DbContext.Info:
                    arguments
                        .Add("ef dbcontext info");
                    break;
                case DbContext.List:
                    arguments
                        .Add("ef dbcontext list");
                    break;
                case DbContext.Optimize:
                    arguments
                        .Add("ef dbcontext optimize")
                        .Add("--output-dir {value}", OutputDir)
                        .Add("--namespace {value}", Namespace);
                    break;
                case DbContext.Scaffold:
                    arguments
                        .Add("ef dbcontext scaffold")
                        .Add("{value}", Connection)
                        .Add("{value}", Provider)
                        .Add("--data-annotations", DataAnnotations)
                        .Add("--context-dir {value}", ContextDir)
                        .Add("--context-namespace  {value}", ContextNamespace)
                        .Add("--force", Force)
                        .Add("--output-dir {value}", OutputDir)
                        .Add("--namespace {value}", Namespace)
                        .Add("--schema {value}", Schema)
                        .Add("--table  {value}", Table)
                        .Add("--use-database-names", UseDatabaseNames)
                        .Add("--no-onconfiguring", NoOnConfiguring)
                        .Add("---no-pluralize", NoPluralize);
                    break;
                case DbContext.Script:
                    arguments
                        .Add("ef dbcontext script")
                        .Add("--output {value}", Output);
                    break;
                default:
                    throw new InvalidOperationException(Command.ToString());
            }

            return base.ConfigureProcessArguments(arguments);
        }
    }
}
