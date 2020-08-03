#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0

// Cake Addins
#addin nuget:?package=Cake.FileHelpers&version=3.3.0

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

var artifacts = new [] {
    new Artifact {
        NativeVersion = "4.0.2.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Push Android v{0}", "4.0.2.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsPush/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsPush/HmsPush.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/push/{0}/push-{0}.aar",
        JarPath = "./HmsPush/Jars/push-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.1.301",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei OpenDevice Android v{0}", "4.0.1.301")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsOpenDevice/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsOpenDevice/HmsOpenDevice.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/opendevice/{0}/opendevice-{0}.aar",
        JarPath = "./HmsOpenDevice/Jars/opendevice-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.1.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Maps Android v{0}", "4.0.1.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsMaps/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsMaps/HmsMaps.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/maps/{0}/maps-{0}.aar",
        JarPath = "./HmsMaps/Jars/maps-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.1.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Maps Base Android v{0}", "4.0.1.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsMapsBase/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsMapsBase/HmsMapsBase.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/maps-base/{0}/maps-base-{0}.aar",
        JarPath = "./HmsMapsBase/Jars/maps-base-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.1.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Maps Clustering Android v{0}", "4.0.1.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsMapsClustering/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsMapsClustering/HmsMapsClustering.nuspec",
        DownloadUrl = "https://githubstore.blob.core.windows.net/huawei-aar/clustering-release.aar?sp=r&st=2020-08-03T15:33:43Z&se=2022-08-03T23:33:43Z&spr=https&sv=2019-12-12&sr=b&sig=mLCbWNm1MiTMbsqH2i5vidO61BXaydpUnI420TfhW2c%3D",
        JarPath = "./HmsMapsClustering/Jars/clustering.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.2.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Location Android v{0}", "4.0.2.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsLocation/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsLocation/HmsLocation.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/location/{0}/location-{0}.aar",
        JarPath = "./HmsLocation/Jars/location-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "1.0.13.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Dynamic Api Android v{0}", "1.0.13.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsDynamicApi/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsDynamicApi/HmsDynamicApi.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/dynamic-api/{0}/dynamic-api-{0}.aar",
        JarPath = "./HmsDynamicApi/Jars/dynamic-api-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "1.0.0.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Agconnect Core Android v{0}", "1.0.0.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsAgconnectCore/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsAgconnectCore/HmsAgconnectCore.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/agconnect/agconnect-core/{0}/agconnect-core-{0}.aar",
        JarPath = "./HmsAgconnectCore/Jars/agconnect-core-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.0.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Hms Base Android v{0}", "4.0.0.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsBase/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsBase/HmsBase.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/base/{0}/base-{0}.aar",
        JarPath = "./HmsBase/Jars/base-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.2.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Hms Network Common Android v{0}", "4.0.2.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsNetworkCommon/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsNetworkCommon/HmsNetworkCommon.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/network-common/{0}/network-common-{0}.aar",
        JarPath = "./HmsNetworkCommon/Jars/network-common-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.2.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Hms Network Grs Android v{0}", "4.0.2.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsNetworkGrs/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsNetworkGrs/HmsNetworkGrs.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/network-grs/{0}/network-grs-{0}.aar",
        JarPath = "./HmsNetworkGrs/Jars/network-grs-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },

     new Artifact {
        NativeVersion = "2.0.6.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Hms Update Android v{0}", "2.0.6.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsUpdate/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsUpdate/HmsUpdate.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hms/update/{0}/update-{0}.aar",
        JarPath = "./HmsUpdate/Jars/update-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    },

    new Artifact {
        NativeVersion = "1.3.3.300",
        NugetSuffix = "-rc2",
        ReleaseNotes = new string [] {
            string.Format("Huawei Hms Android v{0}", "1.3.3.300")
        },
        SolutionPath = "./HmsTasks/HmsTasks.csproj",
        AssemblyInfoPath = "./HmsTasks/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsTasks/HmsTasks.nuspec",
        DownloadUrl = "https://developer.huawei.com/repo/com/huawei/hmf/tasks/{0}/tasks-{0}.aar",
        JarPath = "./HmsTasks/Jars/tasks-{0}.aar",
        Dependencies = new NuSpecDependency[] {}
    }
};

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Downloads")
    .Does(() =>
{
    foreach(var artifact in artifacts) {
        var downloadUrl = string.Format(artifact.DownloadUrl, artifact.NativeVersion);
        var jarPath = string.Format(artifact.JarPath, artifact.NativeVersion);

        DownloadFile(downloadUrl, jarPath);
    }
});

Task("Clean")
    .Does(() =>
{
    CleanDirectory("**/*/packages");

    CleanDirectory("./nugets/*");

    var nugetPackages = GetFiles("./nugets/*.nupkg");

    foreach (var package in nugetPackages)
    {
        DeleteFile(package);
    }
});

Task("UpdateVersion")
    .Does(() => 
{
    foreach(var artifact in artifacts) {
        ReplaceRegexInFiles(artifact.AssemblyInfoPath, "\\[assembly\\: AssemblyVersion([^\\]]+)\\]", string.Format("[assembly: AssemblyVersion(\"{0}\")]", artifact.NativeVersion));
    }
});

Task("Build")
    .Does(() =>
{
    foreach(var artifact in artifacts) {
        NuGetRestore(artifact.SolutionPath);
        MSBuild(artifact.SolutionPath, settings => {
            settings.ToolVersion = MSBuildToolVersion.VS2019;
            settings.SetConfiguration(configuration);
            settings.WithTarget("Rebuild");
        });

        break;
    }
});

Task("Pack")
    .Does(() =>
{
    foreach(var artifact in artifacts) {
        NuGetPack(artifact.Csproj, new NuGetPackSettings {
            Version = artifact.Version,
            Dependencies = artifact.Dependencies,
            ReleaseNotes = artifact.ReleaseNotes,
            IncludeReferencedProjects = true,
            Properties = new Dictionary<string, string>
            {
                { "Configuration", "Release" }
            },
            OutputDirectory = "./nugets"
        });
    }
});

//////////////////////////////////////////////////////////////////////
// TASK TARGETS
//////////////////////////////////////////////////////////////////////

Task("Default")
    .IsDependentOn("Downloads")
    .IsDependentOn("UpdateVersion")
    .IsDependentOn("Build")
    .IsDependentOn("Pack")
   ;

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);

class Artifact {

    public string Version
    {
        get { return NativeVersion + NugetSuffix; }
    }

    public string NugetSuffix { get; set; }

    public string NativeVersion { get; set; }

    public string AssemblyInfoPath { get; set; }

    public string SolutionPath { get; set; }

    public string DownloadUrl  { get; set; }

    public string JarPath { get; set; }

    public string NuspecPath { get; set; }

    public string Csproj
    {
        get
        {
            return NuspecPath.Replace("nuspec", "csproj");
        }
    }

    public string[] ReleaseNotes { get; set; }

    public NuSpecDependency[] Dependencies { get; set; }
}