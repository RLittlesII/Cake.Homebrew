using Cake.Core.Tooling;

namespace Cake.Homebrew
{
    public class HomebrewSettings : ToolSettings
    {
        /// <summary>
        /// If passed and brewing fails, open an interactive debugging session with access to IRB or a shell inside the temporary build directory.
        /// </summary>
        public bool Debug { get; set; }

        /// <summary>
        /// If passed, sets the build environment to standard or super.
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Gets or sets the formula to install.
        /// </summary>
        public string Formula { get; set; }

        /// <summary>
        /// If passed, skip installing any dependencies of any kind. If they are not already present, the formula will probably fail to install.
        /// </summary>
        public bool IgnoreDependencies { get; set; }

        /// <summary>
        /// If passed, install the dependencies with specified options but do not install the specified formula.
        /// </summary>
        public bool OnlyDependencies { get; set; }

        /// <summary>
        /// If passed, attempt to compile using compiler. compiler should be the name of the compiler’s executable.
        /// </summary>
        public string Compiler { get; set; }

        /// <summary>
        /// If passed, compile the specified formula from source even if a bottle is provided. Dependencies will still be installed from bottles if they are available.
        /// </summary>
        public bool BuildFromSource { get; set; }

        /// <summary>
        /// If passed, install from a bottle if it exists for the current or newest version of macOS, even if it would not normally be used for installation.
        /// </summary>
        public bool ForceBottle { get; set; }

        /// <summary>
        /// If passed, and formula defines it, install the development version.
        /// </summary>
        public bool Development { get; set; }

        /// <summary>
        /// If passed, and formula defines it, install the HEAD version, aka master, trunk, unstable.
        /// </summary>
        public bool Head { get; set; }

        /// <summary>
        /// If passed, the temporary files created during installation are not deleted.
        /// </summary>
        public bool KeepTemp { get; set; }

        /// <summary>
        /// If passed, prepare the formula for eventual bottling during installation.
        /// </summary>
        public bool BuildBottle { get; set; }

        /// <summary>
        /// If passed, install without checking for previously installed keg-only or non-migrated versions.
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// If passed, print the verification and postinstall steps.
        /// </summary>
        public bool Verbose { get; set; }

        /// <summary>
        /// If passed then git merge is used to include updates.
        /// </summary>
        public bool Merge { get; set; }
    }
}