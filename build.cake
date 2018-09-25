var target = Argument("target", "Default");

using System;
using System.Diagnostics;

// Variables
var configuration = "Release";
var fullFrameworkTarget = "net45";
var netCoreTarget20 = "netcoreapp2.0";
var netCoreTarget21 = "netcoreapp2.1";
var netCoreTarget11 = "netcoreapp1.1";

Task("Default")
    .IsDependentOn("Test");

Task("Compile")
    .Description("Builds all the projects in the solution")
    .Does(() =>
    {
        StartProcess("dotnet", new ProcessSettings {
            Arguments = "--info"
        });

        DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings();
        settings.NoRestore = true;
        settings.Configuration = configuration;

        var projects = GetFiles("**/*.csproj");

        Information($"Restoring projects");
        foreach(var project in projects)
        {
            DotNetCoreRestore(project.ToString());
        }

        Information($"Building projects");
        foreach(var project in projects)
        {
            DotNetCoreBuild(project.ToString(), settings);
        } 
    });

Task("Test")
    .Description("Run Tests")
    .IsDependentOn("Compile")
    .Does(() =>
    {
        string appveyor = EnvironmentVariable("APPVEYOR");
        bool isRunningOnUnix = IsRunningOnUnix();
        string testProjectPath = "./Iyzipay.Tests/Armut.Iyzipay.Tests.csproj";

        DotNetCoreTestSettings settings = new DotNetCoreTestSettings();
        settings.Configuration = configuration;

        if(!string.IsNullOrEmpty(appveyor) && appveyor == "True")
        {
            settings.ArgumentCustomization  = args => args.Append(" --test-adapter-path:. --logger:Appveyor");
        }

        Information($"Running {netCoreTarget11.ToUpper()} Tests");
        settings.Framework = netCoreTarget11;
        DotNetCoreTest(testProjectPath, settings);

        Information($"Running {netCoreTarget20.ToUpper()} Tests");
        settings.Framework = netCoreTarget20;
        DotNetCoreTest(testProjectPath, settings);

        Information($"Running {netCoreTarget21.ToUpper()} Tests");
        settings.Framework = netCoreTarget21;
        DotNetCoreTest(testProjectPath, settings);

        if(!isRunningOnUnix) // Windows
        {
            settings.Framework = fullFrameworkTarget;
            DotNetCoreTest(testProjectPath, settings);
        }
        else // Travis
        {
            NuGetInstallSettings nugetInstallSettings = new NuGetInstallSettings();
            nugetInstallSettings.OutputDirectory = "testrunner";
            nugetInstallSettings.WorkingDirectory = ".";

            NuGetInstall("NUnit.ConsoleRunner", nugetInstallSettings);

            StartProcess("mono", new ProcessSettings {
                Arguments = $"./testrunner/NUnit.ConsoleRunner.*/tools/nunit3-console.exe/ ./Iyzipay.Tests/bin/Release/{fullFrameworkTarget}/Armut.Iyzipay.Tests.dll"
            });
        }
    });

Task("Nuget-Pack")
    .Description("Publish to nuget")
    .Does(() =>
    {
        // var settings = new DotNetCorePackSettings();
        // settings.Configuration = configuration;

        // settings.OutputDirectory = royaleNugetOutput;
        // settings.WorkingDirectory = royaleApiPath;
        // DotNetCorePack(royaleApiProj, settings);

        // settings.OutputDirectory = clashRoyaleNugetOutput;
        // settings.WorkingDirectory = clashRoyaleApiPath;
        // DotNetCorePack(clashRoyaleApiProj, settings);
    });

RunTarget(target);