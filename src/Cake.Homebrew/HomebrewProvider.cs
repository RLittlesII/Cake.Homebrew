using System;
using System.Runtime.CompilerServices;
using Cake.Core;

[assembly: InternalsVisibleTo("Cake.Homebrew.Tests")]

namespace Cake.Homebrew
{
    /// <summary>
    /// An instance of <see cref="IHomebrewProvider"/> that allows access to Homebrew methods.
    /// </summary>
    /// <seealso cref="IHomebrewProvider" />
    public class HomebrewProvider : IHomebrewProvider
    {
        private readonly ICakeContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomebrewProvider"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HomebrewProvider(ICakeContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        /// <summary>
        /// Installs the brew with the specified settings.
        /// <example>
        /// <code>
        ///     var config = new HomebrewSettings
        ///     {
        ///         Formula = "cake"
        ///     };
        ///     Homebrew.Install(config);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Install(HomebrewSettings settings)
        {
            if (_context == null)
            {
                throw new ArgumentNullException(nameof(_context));
            }

            var runner = new HomebrewRunner(_context.FileSystem, _context.Environment, _context.ProcessRunner, _context.Tools);
            runner.Run("install", settings ?? new HomebrewSettings());
        }

        /// <inheritdoc />
        /// <summary>
        /// Installs the brew with the specified action to generate settings.
        /// <example>
        /// <code>
        ///     Homebrew.Install(config =&gt;
        ///     {
        ///         config.Formula = "cake";
        ///     });
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="configurator">The configurator.</param>
        public void Install(Action<HomebrewSettings> configurator)
        {
            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new HomebrewSettings();

            configurator(settings);

            Install(settings);
        }
    }
}