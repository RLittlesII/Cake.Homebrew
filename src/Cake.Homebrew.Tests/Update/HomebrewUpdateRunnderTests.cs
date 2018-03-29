using System;
using System.Collections.Generic;
using System.Text;
using Cake.Core;
using Cake.Homebrew.Tests.Uninstall;
using Cake.Testing;
using Xunit;

namespace Cake.Homebrew.Tests.Update
{
    public sealed class HomebrewUpdateRunnderTests
    {
        [Theory]
        [InlineData("/bin/tools/Homebrew/Homebrew.exe", "/bin/tools/Homebrew/Homebrew.exe")]
        [InlineData("./tools/Homebrew/Homebrew.exe", "/Working/tools/Homebrew/Homebrew.exe")]
        public void Should_Use_Homebrew_Runner_From_Tool_Path_If_Provided(string toolPath, string expected)
        {
            // Given
            var fixture = new HomebrewUpdateRunnerFixture();
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
            var fixture = new HomebrewUpdateRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("/Working/tools/brew", result.Path.FullPath);
        }

        [Fact]
        public void Should_Set_Working_Directory()
        {
            // Given
            var fixture = new HomebrewUpdateRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("/Working", result.Process.WorkingDirectory.FullPath);
        }

        [Fact]
        public void Should_Throw_If_Homebrew_Runner_Was_Not_Found()
        {
            // Given
            var fixture = new HomebrewUpdateRunnerFixture();
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
            var fixture = new HomebrewUpdateRunnerFixture();
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
            var fixture = new HomebrewUpdateRunnerFixture();
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
            var fixture = new HomebrewUpdateRunnerFixture();
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
            var fixure = new HomebrewUpdateRunnerFixture();

            // When
            var result = fixure.Run();

            // Then
            Assert.Equal("update cake", result.Args);
        }

        [Fact]
        public void Should_Add_Force_If_Provided()
        {
            // Given
            var fixure = new HomebrewUpdateRunnerFixture();
            fixure.Settings.Force = true;

            // When
            var result = fixure.Run();

            // Then
            Assert.Equal("update cake --force", result.Args);
        }

        [Fact]
        public void Should_Add_Merge_If_Provided()
        {
            // Given
            var fixure = new HomebrewUpdateRunnerFixture();
            fixure.Settings.Merge = true;

            // When
            var result = fixure.Run();

            // Then
            Assert.Equal("update cake --merge", result.Args);
        }
    }
}
