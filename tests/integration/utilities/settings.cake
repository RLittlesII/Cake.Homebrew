#addin "nuget:https://www.myget.org/F/cake-homebrew/api/v2?package=Cake.Homebrew&prerelease"

using Cake.Homebrew;

public static class BrewSettings
{
    public static HomebrewSettings Settings { get; private set; }
    
    public static HomebrewSettings Initialize(ICakeContext context)
    {
        Settings = new HomebrewSettings
        {

        };

        return Settings;
    }
}

BrewSettings.Initialize(Context);