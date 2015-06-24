<Query Kind="Program">
  <Reference>C:\FSharp\PM_DataGen\DataGenerator\packages\Fare.1.0.0\lib\net35\Fare.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\Microsoft.Reactive.Testing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Core.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Interfaces.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Linq.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.PlatformServices.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Providers.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Runtime.Remoting.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Windows.Forms.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\System.Reactive.Windows.Threading.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETCore\v4.5\System.Reactive.WindowsRuntime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Http.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Http.SelfHost.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\System.Web.Http.WebHost.dll</Reference>
  <GACReference>Microsoft.Web.Administration, Version=7.9.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35</GACReference>
  <Namespace>Microsoft.Win32</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Drawing.Printing</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>Microsoft.Web.Administration</Namespace>
</Query>

void Main()
{
	string siteName = "TestSite";
	string applicationName = "TestApp";
	string virtualDirectoryName = "TestVirtualDirectory";
	string applicationPoolName = "TestAppPool";
	string physicalPath = @"C:\inetpub\mynewsite";
	
	IISHelper.CreateApplicationPool(applicationPoolName);
//	IISHelper.CreateSite(siteName, physicalPath);
//	IISHelper.CreateApplication(siteName, applicationName, physicalPath);
//	IISHelper.CreateVirtualDirectory(siteName, applicationName, virtualDirectoryName, physicalPath);
//	IISHelper.SetApplicationApplicationPool(siteName, applicationPoolName); 
}

public class IISHelper
{
	public static void CreateApplicationPool(string applicationPoolName)
{
    using (ServerManager serverManager = new ServerManager())
    {
        if (serverManager.ApplicationPools[applicationPoolName] != null)
            return;
        ApplicationPool newPool = serverManager.ApplicationPools.Add(applicationPoolName);
        newPool.ManagedRuntimeVersion = "v4.0";
        serverManager.CommitChanges();
    }
}

public static void CreateSite(string siteName, string path)
{
    using (ServerManager serverManager = new ServerManager())
    {
        var sites = serverManager.Sites;
        if (sites[siteName] == null)
        {
            sites.Add(siteName, "http", "*:62000:", path);
            serverManager.CommitChanges();
        }
    }
}

public static void CreateApplication(string siteName, string applicationName, string path)
{
    using (ServerManager serverManager = new ServerManager())
    {
        var site = serverManager.Sites[siteName];//GetSite(serverManager, siteName);
        var applications = site.Applications;
        if (applications["/" + applicationName] == null)
        {
            applications.Add("/" + applicationName, path);
            serverManager.CommitChanges();
        }
    }
}

public static void CreateVirtualDirectory(string siteName, string applicationName, string virtualDirectoryName, string path)
{
    using (ServerManager serverManager = new ServerManager())
    {
        var application = serverManager.Sites[siteName].Applications["/" + applicationName];//GetApplication(serverManager, siteName, applicationName);
        application.VirtualDirectories.Add("/" + virtualDirectoryName, path);
        serverManager.CommitChanges();
    }
}

public static void SetApplicationApplicationPool(string siteName, string applicationPoolName)
{
    using (ServerManager serverManager = new ServerManager())
    {
        var site = serverManager.Sites[siteName];//GetSite(serverManager, siteName);
        if (site != null)
        {
            foreach (Application app in site.Applications)
            {
                app.ApplicationPoolName = applicationPoolName;
            }
        }                
        serverManager.CommitChanges();
    }
}
}

// Define other methods and classes here
