using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Xunit;

namespace Cake.Homebrew.Tests
{
    internal sealed class OSXFact : FactAttribute
    {
        private static readonly PlatformFamily Family;

        static OSXFact()
        {
            Family = EnvironmentHelper.GetPlatformFamily();
        }

        public OSXFact(string reason = null)
        {
            if (Family != PlatformFamily.OSX)
            {
                Skip = reason ?? "Mac OSX test.";
            }
        }
    }

    internal sealed class WindowsFact : FactAttribute
    {
        private static readonly PlatformFamily Family;

        static WindowsFact()
        {
            Family = EnvironmentHelper.GetPlatformFamily();
        }

        public WindowsFact(string reason = null)
        {
            if (Family != PlatformFamily.Windows)
            {
                Skip = reason ?? "Windows test.";
            }
        }
    }
}
