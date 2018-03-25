using System;
using Cake.Core;
using Cake.Testing;
using Xunit;
using Cake.Homebrew.Tests.Install;

namespace Cake.Homebrew.Tests.Runner
{
    public sealed class HomebrewInstallRunnerTests
    {
        public sealed class TheRunMethod
        {
            [Theory]
            [InlineData("/bin/tools/Homebrew/Homebrew.exe", "/bin/tools/Homebrew/Homebrew.exe")]
            [InlineData("./tools/Homebrew/Homebrew.exe", "/Working/tools/Homebrew/Homebrew.exe")]
            public void Should_Use_Homebrew_Runner_From_Tool_Path_If_Provided(string toolPath, string expected)
            {
                // Given
                var fixture = new HomebrewInstallRunnerFixture();
                fixture.Settings.ToolPath = toolPath;
                fixture.GivenSettingsToolPathExist();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Path.FullPath);
            }

            [Fact]
            public void Should_Find_Homebrew_Runner_If_Tool_Path_Not_Provided()
            {
                // Given
                var fixture = new HomebrewInstallRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working/tools/brew", result.Path.FullPath);
            }

            [Fact]
            public void Should_Set_Working_Directory()
            {
                // Given
                var fixture = new HomebrewInstallRunnerFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("/Working", result.Process.WorkingDirectory.FullPath);
            }

            [Fact]
            public void Should_Throw_If_Homebrew_Runner_Was_Not_Found()
            {
                // Given
                var fixture = new HomebrewInstallRunnerFixture();
                fixture.GivenDefaultToolDoNotExist();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("brew: Could not locate executable.", result?.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
            {
                // Given
                var fixture = new HomebrewInstallRunnerFixture();
                fixture.GivenProcessExitsWithCode(1);

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("brew: Process returned an error (exit code 1).", result?.Message);
            }

            [Fact]
            public void Should_Throw_If_Process_Was_Not_Started()
            {
                // Given
                var fixture = new HomebrewInstallRunnerFixture();
                fixture.GivenProcessCannotStart();

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<CakeException>(result);
                Assert.Equal("brew: Process was not started.", result?.Message);
            }

            [Fact]
            public void Should_Throw_If_Settings_Is_Null()
            {
                // Given
                var fixture = new HomebrewInstallRunnerFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                Assert.IsType<ArgumentNullException>(result);
            }

            [Fact]
            public void Should_Add_Formula_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake", result.Args);
            }

            [Fact]
            public void Should_Add_Debug_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.Debug = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --debug", result.Args);
            }

            [Theory]
            [InlineData("std")]
            [InlineData("super")]
            public void Should_Add_Standard_If_Environment_Provided(string environment)
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.Environment = environment;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal($"install cake --env={environment}", result.Args);
            }

            [Fact]
            public void Should_Add_Ignore_Dependencies_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.IgnoreDependencies = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --ignore-dependencies", result.Args);
            }

            [Fact]
            public void Should_Add_Only_Dependencies_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.OnlyDependencies = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --only-dependencies", result.Args);
            }

            [Theory]
            [InlineData("node")]
            [InlineData("mac-c-752")]
            [InlineData("roslyn")]
            [InlineData("jre")]
            public void Should_Add_Compiler_If_Provided(string compiler)
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.Compiler = compiler;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal($"install cake --cc={compiler}", result.Args);
            }

            [Fact]
            public void Should_Add_Build_From_Source_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.BuildFromSource = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --build-from-source", result.Args);
            }

            [Fact]
            public void Should_Add_Build_From_Source_If_Environment_Variable_Set()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Environment.SetEnvironmentVariable("HOMEBREW_BUILD_FROM_SOURCE", "true");

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --build-from-source", result.Args);
            }

            [Fact]
            public void Should_Add_Force_Bottle_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.ForceBottle = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --force-bottle", result.Args);
            }

            [Fact]
            public void Should_Add_Devel_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.Development = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --devel", result.Args);
            }

            [Fact]
            public void Should_Add_Head_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.Head = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --HEAD", result.Args);
            }

            [Fact]
            public void Should_Add_Keep_Temp_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.KeepTemp = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --keep-tmp", result.Args);
            }

            [Fact]
            public void Should_Add_Build_Bottle_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.BuildBottle = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --build-bottle", result.Args);
            }

            [Fact]
            public void Should_Add_Force_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.Force = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --force", result.Args);
            }

            [Fact]
            public void Should_Add_Verbose_If_Provided()
            {
                // Given
                var fixure = new HomebrewInstallRunnerFixture();
                fixure.Settings.Verbose = true;

                // When
                var result = fixure.Run();

                // Then
                Assert.Equal("install cake --verbose", result.Args);
            }
        }
    }
}