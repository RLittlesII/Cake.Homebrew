using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;
using Cake.Homebrew.Extensions;

namespace Cake.Homebrew
{
    internal class HomebrewRunner : Tool<HomebrewSettings>
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomebrewRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="toolLocator">The tool locator.</param>
        public HomebrewRunner(IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator toolLocator) : base(fileSystem, environment, processRunner, toolLocator)
        {
            _environment = environment;
        }

        /// <summary>
        /// Runs the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">settings</exception>
        public void Run(string command, HomebrewSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            Run(settings, BuildArguments(command, settings));
        }

        private ProcessArgumentBuilder BuildArguments(string command, HomebrewSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            builder.Append(command);

            if (!string.IsNullOrWhiteSpace(settings.Formula))
            {
                builder.Append(settings.Formula);
            }

            if (settings.Debug)
            {
                builder.Append("--debug");
            }

            if (!string.IsNullOrEmpty(settings.Environment))
            {
                builder.AppendSwitch("--env", "=", settings.Environment);
            }

            if (settings.IgnoreDependencies)
            {
                builder.Append("--ignore-dependencies");
            }

            if (settings.OnlyDependencies)
            {
                builder.Append("--only-dependencies");
            }

            if (!string.IsNullOrWhiteSpace(settings.Compiler))
            {
                builder.AppendSwitch("--cc", "=", settings.Compiler);
            }

            if (settings.BuildFromSource)
            {
                builder.Append("--build-from-source");
            }

            if(_environment.VariableEquals("HOMEBREW_BUILD_FROM_SOURCE", "true"))
            {
                builder.Append("--build-from-source");
            }

            if (settings.ForceBottle)
            {
                builder.Append("--force-bottle");
            }

            if (settings.Development)
            {
                builder.Append("--devel");
            }

            if (settings.Head)
            {
                builder.Append("--HEAD");
            }

            if (settings.KeepTemp)
            {
                builder.Append("--keep-tmp");
            }

            if (settings.BuildBottle)
            {
                builder.Append("--build-bottle");
            }

            if (settings.Force)
            {
                builder.Append("--force");
            }

            if (settings.Verbose)
            {
                builder.Append("--verbose");
            }

            return builder;
        }

        protected override string GetToolName() => "brew";

        protected override IEnumerable<string> GetToolExecutableNames() => new[] {"brew"};
    }
}