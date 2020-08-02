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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
        ReleaseNotes = new string [] {
            string.Format("Huawei Maps Clustering Android v{0}", "4.0.1.300")
        },
        SolutionPath = "./Hms.sln",
        AssemblyInfoPath = "./HmsMapsClustering/Properties/AssemblyInfo.cs",
        NuspecPath = "./HmsMapsClustering/HmsMapsClustering.nuspec",
        DownloadUrl = "https://public.am.files.1drv.com/y4mabf7Uo9K-NWI98Mdh0ZRmnYiqVSYoPZi-CDCoKnai3NkmtMvb_ibkkqT8RDmB_II9k3Pm2jJJ1UfVkqtVmdAWMkd6e9M1KgvnLTO5gQ5a-DM13Ai27_5DBzjLCCoW9ho6GNYmOfDSdNNHzoK0HtOU1M739xUK-w6MGNO1eWIfc0sFa0YLqBtj--nZ6keHhbtVCN71qE78QOp46p6CddPIfZhyK_qUybN6VPDvSZyV1o?access_token=EwAYA61DBAAUzl/nWKUlBg14ZGcybuC4/OHFdfEAARBYimmsxw%2bi7FwzzRxt0hkeslag3T%2btX6Jqu%2bEnFY7YcQ9fgXeHMdh5MiY1g6gbXQPQ9kauLv3rxQQPVIOl2UWgW6T4AlQWbnxeXzQJ9FWeFIdPi7Bnst8s53Waxwc9eCitI4Z4SCseidryi1nrKLtetofPx%2bkR9hxuSvV43fatSFj0LQfLz4241eTh6SP8V3cWBSmg9AdnzEgqXVG6iutZv8H3j4inCBgzAyUl8an5YxKmIaYIkSVaesNwZ0QddFUswlxWw86GeVQ18HxMgxO%2b0AcLnS7u1JKB45MiMDdWeyf9%2b6CNaLX5RT3UVyNxO2MzfmQXVT6PiGzICrHtL1gDZgAACHXU7tc034Fx6AFBbxVFcSI6Fza2wMidph2OWz1a/3uwC/LCgbPxXSy2v34C7Wg2K3LVzgXHj3pgQBURvjc5cwVUNRgSF7fLhWof237QfGkqb8fTv8z060ByfaGwzN55BqOebq2phNNS03na8v/C/bfk0n2UsYLIMQGcI66xNa%2bBlMVNxsTRtRhE0Yy9Jq6eg4HQMJQ5yKlYPcU9X%2bJFwBgmcUfIX5gnjWlz43POdznjKGbmsQsGqakZL6PRtro8gsUubswCxFtjI5rKHMd5DFF7SJFhl9zvEqWtJW4F023X%2bT01597IeIxK2s143dfxQgmI9dsF%2bd4H0HtN%2b9CHJn%2bsJAvrROZJUz%2bwZnd0f3x4uURxsgGJarebxUaTEHfUBoGV5SKJrSBdqN/bplMjFizhDlVBvzm8S%2bMmGQSmZWrUxEWEzwgfMZ6BV2oEJZZ93Tc%2b802iMz5sja8g7teBxXnLfW%2bVOA9LUu0HPPhDXfHr/pkG9/%2bgl5ca%2bHcMXOtNtKFAAaHZ7Sn1k4T130pxbIsxNnxyItXHu%2boW5/m6ZtnqaPtK6GVyJ9N%2b8HAqYShXnryZshMtjOOR%2byEw0O609EvKpbPdXPs7cqN4JBKdUuf%2bRmzfVh13826sjN/JSHsSF0BMiMlGWASJf/oSBaLaVz/SIRgC",
        JarPath = "./HmsMapsClustering/Jars/clustering.aar",
        Dependencies = new NuSpecDependency[] {}
    },
    new Artifact {
        NativeVersion = "4.0.2.300",
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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
        NugetSuffix = "-rc1",
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