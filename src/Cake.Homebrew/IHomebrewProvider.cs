using System;

namespace Cake.Homebrew
{
    /// <summary>
    /// An interface that defines available Homebrew methods.
    /// </summary>
    public interface IHomebrewProvider
    {
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
        void Install(HomebrewSettings settings);

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
        void Install(Action<HomebrewSettings> configurator);

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
        /// <param name="settings"></param>
        void Uninstall(HomebrewSettings settings);

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
        /// <param name="configurator"></param>
        void Uninstall(Action<HomebrewSettings> configurator);
    }
}