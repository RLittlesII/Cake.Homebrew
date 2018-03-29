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

        public sealed class TheConstructor
        {
            [OSXFact]
            public void Should_Throw_If_Context_Null_OSX()
            {
                // Given, When
                var result = Record.Exception(() =>
                {
                    var provider = new HomebrewProvider(null);
                });

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\nParameter name: context", result.Message);
            }

            [WindowsFact]
            public void Should_Throw_If_Context_Null_Windows()
            {
                // Given, When
                var result = Record.Exception(() =>
                {
                    var provider = new HomebrewProvider(null);
                });

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\r\nParameter name: context", result.Message);
            }
        }

        public sealed class TheInstallActionMethod
        {

            [OSXFact]
            public void Should_Throw_If_Configurator_Null_OSX()
            {
                // Given
                var provider = new HomebrewProvider(Context);

                // When
                var result = Record.Exception(() => provider.Install((Action<HomebrewSettings>)null));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\nParameter name: configurator", result.Message);
            }

            [WindowsFact]
            public void Should_Throw_If_Configurator_Null_Windows()
            {
                // Given
                var provider = new HomebrewProvider(Context);

                // When
                var result = Record.Exception(() => provider.Install((Action<HomebrewSettings>)null));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\r\nParameter name: configurator", result.Message);
            }
        }

        public sealed class TheUninstallActionMethod
        {
            [OSXFact]
            public void Should_Throw_If_Configurator_Null_OSX()
            {
                // Given
                var provider = new HomebrewProvider(Context);

                // When
                var result = Record.Exception(() => provider.Uninstall((Action<HomebrewSettings>)null));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\nParameter name: configurator", result.Message);
            }

            [WindowsFact]
            public void Should_Throw_If_Configurator_Null_Windows()
            {
                // Given
                var provider = new HomebrewProvider(Context);

                // When
                var result = Record.Exception(() => provider.Uninstall((Action<HomebrewSettings>)null));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\r\nParameter name: configurator", result.Message);
            }
        }

        public sealed class TheUpdateActionMethod
        {
            [OSXFact]
            public void Should_Throw_If_Configurator_Null_OSX()
            {
                // Given
                var provider = new HomebrewProvider(Context);

                // When
                var result = Record.Exception(() => provider.Update((Action<HomebrewSettings>)null));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\nParameter name: configurator", result.Message);
            }

            [WindowsFact]
            public void Should_Throw_If_Configurator_Null_Windows()
            {
                // Given
                var provider = new HomebrewProvider(Context);

                // When
                var result = Record.Exception(() => provider.Update((Action<HomebrewSettings>)null));

                //Then
                Assert.IsType<ArgumentNullException>(result);
                Assert.Equal("Value cannot be null.\r\nParameter name: configurator", result.Message);
            }
        }
    }
}
