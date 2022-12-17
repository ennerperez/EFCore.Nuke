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
    public class DatabaseSettings : Settings
    {

        /// <summary>
        ///
        /// </summary>
        public DatabaseSettings()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        public DatabaseSettings(Database command) : this()
        {
            Command = command;
        }

        /// <summary>
        ///
        /// </summary>
        public Database Command { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? Force { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public bool? DryRun { get; internal set; }

        /// <summary>
        ///
        /// </summary>
        public string Migration { get; internal set; }
        /// <summary>
        ///
        /// </summary>
        public string Connection { get; internal set; }

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
                case Database.Drop:
                    arguments
                        .Add("ef database drop")
                        .Add("--force", Force)
                        .Add("--dry-run", DryRun);
                    break;
                case Database.Update:
                    arguments
                        .Add("ef database update")
                        .Add("{value}", Migration)
                        .Add("--connectio {value}", Connection);
                    break;
                default:
                    throw new InvalidOperationException(Command.ToString());
            }

            return base.ConfigureProcessArguments(arguments);
        }
    }
}
