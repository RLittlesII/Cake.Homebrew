using Cake.Homebrew;

Task("Homebrew-Install")
    .Does(() =>
    {
        var config = new HomebrewSettings 
        {
            Formula = "cake"
        };

        Homebrew.Install(config);
    });

Task("Homebrew-Install-Action")
    .Does(() =>
    {
        Homebrew.Install(config => 
        {
            config.Formula = "cake";
        });
    });