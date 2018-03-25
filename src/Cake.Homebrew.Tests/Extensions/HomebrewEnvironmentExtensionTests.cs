using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Homebrew.Extensions;
using Cake.Testing;
using Xunit;

namespace Cake.Homebrew.Tests.Extensions
{
    public sealed class HomebrewEnvironmentExtensionTests
    {
        private static readonly FakeEnvironment Environment = new FakeEnvironment(PlatformFamily.OSX);

        public sealed class TheVariableEqualsMethod
        {
            [Theory]
            [InlineData("CAKE_VARIABLE", "true")]
            [InlineData("CAKE_VARIABLE", "false")]
            [InlineData("CAKE_VARIABLE", "15")]
            public void Should_Return_True(string variable, string value)
            {
                // Given
                Environment.SetEnvironmentVariable(variable, value);

                // When
                var result = Environment.VariableEquals(variable, value);

                // Then
                Assert.True(result);
            }

            [Theory]
            [InlineData("CAKE_VARIABLE", "true")]
            [InlineData("CAKE_VARIABLE", "false")]
            [InlineData("CAKE_VARIABLE", "15")]
            public void Should_Return_True_If_Case_Different(string variable, string value)
            {
                // Given
                Environment.SetEnvironmentVariable(variable, value.ToLower());

                // When
                var result = Environment.VariableEquals(variable, value.ToUpper());

                // Then
                Assert.True(result);
            }

            [Theory]
            [InlineData("", "")]
            [InlineData("CAKE_VARIABLE", "")]
            [InlineData("CAKE_VARIABLE", "true")]
            [InlineData("CAKE_VARIABLE", "false")]
            public void Should_Return_False(string variable, string value)
            {
                // Given
                Environment.SetEnvironmentVariable(variable, value);

                // When
                var result = Environment.VariableEquals(variable, "dummy-value");

                // Then
                Assert.False(result);
            }
        }
    }
}
