using System;
using System.Runtime.CompilerServices;
using Cake.Core;
using Cake.Core.Annotations;

[assembly: InternalsVisibleTo("Cake.Homebrew.Tests")]

namespace Cake.Homebrew
{
    /// <summary>
    /// An instance of <see cref="IHomebrewProvider"/> that allows access to Homebrew methods.
    /// </summary>
    /// <seealso cref="IHomebrewProvider" />
    [CakeAliasCategory("Homebrew")]
    public sealed class HomebrewProvider : IHomebrewProvider
    {
        private readonly HomebrewRunner _homewbrewRunner;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomebrewProvider"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public HomebrewProvider(ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _homewbrewRunner = new HomebrewRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
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
        /// 
        ///     Homebrew.Install(config);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public void Install(HomebrewSettings settings)
        {
            _homewbrewRunner.Run("install", settings ?? new HomebrewSettings());
        }

        /// <inheritdoc />
        /// <summary>
        /// Installs the brew with the specified action to generate settings.
        /// <example>
        /// <code>
        ///     Homebrew.Install(config =>
        ///     {
        ///         config.Formula = "cake";
        ///     });
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="configurator">The configurator.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
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

        /// <inheritdoc />
        /// <summary>
        /// Uninstalls the brew with the specified settings.
        /// <example>
        /// <code>
        ///     var config = new HomebrewSettings
        ///     {
        ///         Formula = "cake"
        ///     };
        /// 
        ///     Homebrew.Uninstall(config);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="settings">The settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Uninstall")]
        public void Uninstall(HomebrewSettings settings)
        {
            _homewbrewRunner.Run("uninstall", settings ?? new HomebrewSettings());
        }

        /// <inheritdoc />
        /// <summary>
        /// Uninstalls the brew with the specified action to generate settings.
        /// <example>
        /// <code>
        ///     Homebrew.Uninstall(config =>
        ///     {
        ///         config.Formula = "cake";
        ///     });
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="configurator">The configurator.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("Uninstall")]
        public void Uninstall(Action<HomebrewSettings> configurator)
        {
            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new HomebrewSettings();

            configurator(settings);

            Uninstall(settings);
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        public void Update(HomebrewSettings settings)
        {
            _homewbrewRunner.Run("update", settings ?? new HomebrewSettings());
        }

        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        public void Update(Action<HomebrewSettings> configurator)
        {
            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new HomebrewSettings();

            configurator(settings);

            Update(settings);
        }
    }
}