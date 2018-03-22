// Utilities
#load "./utilities/settings.cake"
#load "./utilities/xunit.cake"

// Tests
#load "./Homebrew/install.cake"
#load "./Homebrew/uninstall.cake"
#load "./Homebrew/HomebrewAliases.cake"

//////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////

var target = Argument<string>("target", "Run-All-Tests");

//////////////////////////////////////////////////
// SETUP / TEARDOWN
//////////////////////////////////////////////////

Setup(ctx =>
{
});

Teardown(ctx =>
{
});

//////////////////////////////////////////////////
// TARGETS
//////////////////////////////////////////////////
Task("Cake.Homebrew")
    .IsDependentOn("Homebrew-Settings")
    .IsDependentOn("Homebrew-Action");

Task("Run-All-Tests")
    .IsDependentOn("Cake.Homebrew");

RunTarget(target);