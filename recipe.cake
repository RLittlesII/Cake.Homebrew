#load nuget:https://www.myget.org/F/cake-contrib/api/v2?package=Cake.Recipe&prerelease

Environment.SetVariableNames();

BuildParameters.SetParameters(context: Context,
                            title: "Cake.Homebrew",
                            buildSystem: BuildSystem,
                            sourceDirectoryPath: "./src",
                            repositoryOwner: "RLittlesII",
                            repositoryName: "Cake.Homebrew",
                            appVeyorAccountName: "RLittlesII",
                            shouldRunInspectCode: false,
                            shouldRunDotNetCorePack: true,
                            shouldRunCodecov: false,
                            integrationTestScriptPath: "./tests/integration/test.cake");

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context,
                            dupFinderExcludePattern: new string[] { BuildParameters.RootDirectoryPath + "/src/Cake.Homebrew.Tests/*.cs", BuildParameters.RootDirectoryPath + "/src/**/Cake.Homebrew.AssemblyInfo.cs" },
                            testCoverageFilter: "+[*]* -[xunit.*]* -[Cake.Core]* -[Cake.Testing]* -[*.Tests]* -[FakeItEasy]*",
                            testCoverageExcludeByAttribute: "*.ExcludeFromCodeCoverage*",
                            testCoverageExcludeByFile: "*/*Designer.cs;*/*.g.cs;*/*.g.i.cs");

Build.RunDotNetCore();