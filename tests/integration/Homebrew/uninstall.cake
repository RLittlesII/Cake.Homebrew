using Cake.Homebrew;

Task("Homebrew-Uninstall")
    .Does(() =>
    {
        var config = new HomebrewSettings 
        {
            Formula = "cake",
            Force = true
        };

        Homebrew.Uninstall(config);
    });

Task("Homebrew-Uninstall-Action")
    .Does(() =>
    {
        Homebrew.Uninstall(config => 
        {
            config.Formula = "cake";
            config.Force = true;
        });
    });