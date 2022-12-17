using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
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
    public class MigrationsSettings : Settings
    {

        /// <summary>
        ///
        /// </summary>
        public MigrationsSettings()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        public MigrationsSettings(Migrations command) : this()
        {
            Command = command;
        }

        /// <summary>
        ///
        /// </summary>
        public Migrations Command { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public string Namespace { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string OutputDir { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public string TargetRuntime { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? SelfContained { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? Force { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Output { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public bool? NoConnect { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Connection { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public bool? NoTransactions { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? Idempotent { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string To { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string From { get; internal set; }

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
                case Migrations.Add:
                    arguments
                        .Add("ef migrations add")
                        .Add("{value}", Name)
                        .Add("--output-dir {value}", OutputDir)
                        .Add("--namespace {value}", Namespace);
                    break;
                case Migrations.Bundle:
                    arguments
                        .Add("ef migrations bundle")
                        .Add("--output {value}", Output)
                        .Add("--force", Force)
                        .Add("--self-contained", SelfContained)
                        .Add("--target-runtime {value}", TargetRuntime);
                    break;
                case Migrations.List:
                    arguments
                        .Add("ef migrations bundle")
                        .Add("--connection {value}", Connection)
                        .Add("--no-connect", NoConnect);
                    break;
                case Migrations.Remove:
                    arguments
                        .Add("ef migrations remove")
                        .Add("--force", Force);
                    break;
                case Migrations.Script:
                    arguments
                        .Add("ef migrations script")
                        .Add("{value}", From)
                        .Add("{value}", To)
                        .Add("--output {value}", Output)
                        .Add("--idempotent", Idempotent)
                        .Add("--no-transactions", NoTransactions);
                    break;
                default:
                    throw new InvalidOperationException(Command.ToString());
            }

            return base.ConfigureProcessArguments(arguments);
        }
    }
}
