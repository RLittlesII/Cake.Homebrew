using Cake.Homebrew;

Task("Homebrew-Update")
    .Does(() =>
    {
        var config = new HomebrewSettings 
        {
            Formula = "cake"
        };

        Homebrew.Install(config);

        Homebrew.Update(config);

        Homebrew.Uninstall(config);
    });

Task("Homebrew-Update-Action")
    .Does(() =>
    {
        Homebrew.Install(config => 
        {
            config.Formula = "cake";
        });

        Homebrew.Update(config => 
        {
            config.Formula = "cake";
            config.Force = true;
        });

        Homebrew.Uninstall(config => 
        {
            config.Formula = "cake";
        });
    });