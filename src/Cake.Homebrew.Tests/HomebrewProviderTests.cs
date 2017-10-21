using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Testing;
using NSubstitute;
using Xunit;

namespace Cake.Homebrew.Tests
{
    public sealed class HomebrewProviderTests
    {
        private static ICakeContext Context => Substitute.For<ICakeContext>();

        public sealed class TheInstallMethod
        {
            [OSXFact]
            public void Should_Throw_If_Context_Null()
            {
                // Given
                var provider = new HomebrewProvider(null);

                // When
                var result = Record.Exception(() => provider.Install(new HomebrewSettings()));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\nParameter name: _context", result.Message);
            }
        }

        public sealed class TheInstallActionMethod
        {
            [OSXFact]
            public void Should_Throw_If_Context_Null()
            {
                // Given
                var provider = new HomebrewProvider(null);

                // When
                var result = Record.Exception(() => provider.Install(new HomebrewSettings()));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\nParameter name: _context", result.Message);
            }

            [OSXFact]
            public void Should_Throw_If_Configurator_Null()
            {
                // Given
                var provider = new HomebrewProvider(Context);

                // When
                var result = Record.Exception(() => provider.Install((Action<HomebrewSettings>)null));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\nParameter name: configurator", result.Message);
            }
        }
    }
}
