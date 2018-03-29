using System;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Homebrew
{
    public static class HomebrewAliases
    {
        private static IHomebrewProvider _homebrewProvider;

        /// <summary>
        /// Returns a <see cref="HomebrewProvider" /> from the specified <see cref="ICakeContext"/>.
        /// <example>
        /// <code>
        ///     Homebrew.Install(config =>
        ///     {
        ///         config.Formula = "cake";
        ///     });
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">context</exception>
        [CakePropertyAlias(Cache = true)]
        public static IHomebrewProvider Homebrew(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return _homebrewProvider = _homebrewProvider ?? new HomebrewProvider(context);
        }
    }
}