var target = Argument("target", "Default");

using System;
using System.Diagnostics;

// Variables
var configuration = "Release";
var fullFrameworkTarget = "net45";
var netCoreTarget20 = "netcoreapp2.0";
var netCoreTarget21 = "netcoreapp2.1";
var netCoreTarget22 = "netcoreapp2.2";

var projects = GetFiles("**/*.csproj");
string testProjectPath = "../tests/Iyzipay.Tests/Armut.Iyzipay.Tests.csproj";

Task("Default")
    .IsDependentOn("Test");

Task("Clean")
    .Does(() =>
    {
        foreach(var project in projects)
        {
            DotNetCoreClean(project.ToString());
        }
    });

Task("Restore")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        foreach(var project in projects)
        {
            DotNetCoreRestore(project.ToString());
        }
    });

Task("Build")
    .IsDependentOn("Restore")
    .Description("Builds all the projects in the solution")
    .Does(() =>
    {
        DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings
        {
            NoRestore = true,
            Configuration = configuration
        };

        foreach(var project in projects)
        {
            DotNetCoreBuild(project.ToString(), settings);
        } 
    });

Task("NetCore2.0Tests")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTestSettings settings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            Framework = netCoreTarget20
        };
        DotNetCoreTest(testProjectPath, settings);
    });

Task("NetCore2.1Tests")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTestSettings settings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            Framework = netCoreTarget21
        };
        DotNetCoreTest(testProjectPath, settings);
    });

Task("NetCore2.2Tests")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetCoreTestSettings settings = new DotNetCoreTestSettings
        {
            Configuration = configuration,
            Framework = netCoreTarget22
        };

        DotNetCoreTest(testProjectPath, settings);
    });

Task("NetFramework4.5Tests")
    .IsDependentOn("Build")
    .Does(() => {
        bool isRunningOnUnix = IsRunningOnUnix();

        if(!isRunningOnUnix) // Windows
        {
            DotNetCoreTestSettings settings = new DotNetCoreTestSettings
            {
                Configuration = configuration,
                Framework = fullFrameworkTarget
            };

            DotNetCoreTest(testProjectPath, settings);
        }
        else
        {
            var nugetInstallSettings = new NuGetInstallSettings
            {
                OutputDirectory = "testrunner",
                WorkingDirectory = "."
            };

            NuGetInstall("NUnit.ConsoleRunner", nugetInstallSettings);

            StartProcess("mono", new ProcessSettings {
                Arguments = $"./testrunner/NUnit.ConsoleRunner.*/tools/nunit3-console.exe/ ./tests/Iyzipay.Tests/bin/Release/{fullFrameworkTarget}/Armut.Iyzipay.Tests.dll"
            });
        }
    });

Task("Test")
    .IsDependentOn("NetCore2.0Tests")
    .IsDependentOn("NetCore2.1Tests")
    .IsDependentOn("NetCore2.2Tests")
    .IsDependentOn("NetFramework4.5Tests");

Task("Nuget-Pack")
    .Description("Publish to nuget")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings
        {
            Configuration = "Release",
            WorkingDirectory = "../src/Iyzipay",
            OutputDirectory = "../artifacts"
        };

        DotNetCorePack("Armut.Iyzipay.csproj", settings);
    });

RunTarget(target);