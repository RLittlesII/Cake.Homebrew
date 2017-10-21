using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Xunit;

namespace Cake.Homebrew.Tests
{
    public sealed class OSXFact : FactAttribute
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
}
