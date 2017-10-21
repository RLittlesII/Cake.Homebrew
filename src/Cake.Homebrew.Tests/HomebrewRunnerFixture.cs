using Cake.Testing.Fixtures;

namespace Cake.Homebrew.Tests.Runner
{
    internal class HomebrewRunnerFixture : ToolFixture<HomebrewSettings>
    {
        private readonly string _command;

        public HomebrewRunnerFixture(string command) : base("brew")
        {
            _command = command;
            Settings = new HomebrewSettings
            {
                Formula = "cake",
                WorkingDirectory = "/Working"
            };
        }

        protected override void RunTool()
        {
            var tool = new HomebrewRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(_command, Settings);
        }
    }
}