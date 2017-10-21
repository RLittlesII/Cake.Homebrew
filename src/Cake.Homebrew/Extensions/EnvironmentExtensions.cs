using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;

namespace Cake.Homebrew.Extensions
{
    public static class EnvironmentExtensions
    {
        /// <summary>
        /// Returns a value determining if the environment variables exists and is equal to the provided value.
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <param name="variable">The variable.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool VariableEquals(this ICakeEnvironment environment, string variable, string value) =>
            !string.IsNullOrWhiteSpace(environment.GetEnvironmentVariable(variable)) &&
            string.Equals(environment.GetEnvironmentVariable(variable), value, StringComparison.CurrentCultureIgnoreCase);
    }
}
