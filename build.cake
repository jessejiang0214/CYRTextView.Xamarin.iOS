#addin "Cake.ExtendedNuGet"

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("Configuration", "Release");
var outputDir = Directory("./Output");
var iOSProjectDir = Directory("./CYRTextViewXamariniOS");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectories ("./**/bin");
	CleanDirectories ("./**/obj");
    if(DirectoryExists("./CYRTextViewXamariniOS/CYRTextViewKit.framework"))
    {
        DeleteDirectory ("./CYRTextViewXamariniOS/CYRTextViewKit.framework", recursive:true);
    }
});

// Task("Restore-NuGet-Packages")
//     .IsDependentOn("Clean")
//     .Does(() =>
// {
//     NuGetRestore(solutionFilePath);
// });

Task("Build-CYRTextView")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        IEnumerable<string> redirectedStandardOutput;
        IEnumerable<string> redirectedErrorOutput;

        var exitCodeWithArgument =
            StartProcess(
                "make",
                new ProcessSettings {
                    WorkingDirectory = iOSProjectDir,
                    RedirectStandardOutput = true
                },
                out redirectedStandardOutput,
                out redirectedErrorOutput
            );

        // Output last line of process output.
        Information("Last line of output: {0}", redirectedStandardOutput.LastOrDefault());

        // Throw exception if anything was written to the standard error.
        if (redirectedErrorOutput!=null && redirectedErrorOutput.Any())
        {
            throw new Exception(
                string.Format(
                    "Errors ocurred: {0}",
                    string.Join(", ", redirectedErrorOutput)));
        }
    });

Task("Build-XamarinBindingLibrary")
    .IsDependentOn("Build-CYRTextView")
    .Does(() =>
{
    MSBuild($"{iOSProjectDir}/CYRTextViewXamariniOS.sln", settings =>
            settings.SetConfiguration(configuration)
                .WithTarget("CYRTextViewXamariniOS")
                );
});

Task("General-NuGet-Packages")
    .IsDependentOn("Build-XamarinBindingLibrary")
    .Does(() =>
{
    NuGetPack("./CYRTextView.Xamarin.iOS.nuspec", new NuGetPackSettings());
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Build-XamarinBindingLibrary")
    .IsDependentOn("General-NuGet-Packages")
    ;

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);
