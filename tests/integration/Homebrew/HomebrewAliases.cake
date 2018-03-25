Task("Homebrew-Settings")
    .IsDependentOn("Homebrew-Install")
    .IsDependentOn("Homebrew-Uninstall");

Task("Homebrew-Action")
    .IsDependentOn("Homebrew-Install-Action")
    .IsDependentOn("Homebrew-Uninstall-Action");