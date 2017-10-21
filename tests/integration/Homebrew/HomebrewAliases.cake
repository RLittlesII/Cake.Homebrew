Task("Homebrew-Install")
    .Does(() =>
    {
        Homebrew.Install(config => 
        {
            config.Formula = "cake";
        });
    });