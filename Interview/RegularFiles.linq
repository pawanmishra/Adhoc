<Query Kind="Program">
  <Reference>C:\FSharp\PM_DataGen\DataGenerator\packages\Fare.1.0.0\lib\net35\Fare.dll</Reference>
  <Reference>C:\Personal\FileTransferService.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SDKs\Reactive Extensions\v2.0\Binaries\.NETFramework\v4.5\Microsoft.Reactive.Testing.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.ConnectionInfo.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Management.Sdk.Sfc.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft SQL Server\110\SDK\Assemblies\Microsoft.SqlServer.Smo.dll</Reference>
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
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
  <Namespace>Microsoft.SqlServer.Management.Smo</Namespace>
  <Namespace>Microsoft.Win32</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Drawing.Printing</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <IncludePredicateBuilder>true</IncludePredicateBuilder>
</Query>

void Main()
{
	RegularFiles files = new RegularFiles();
	using (StreamReader reader = File.OpenText(Console.ReadLine()))
   	while (!reader.EndOfStream)
   	{
       	string line = reader.ReadLine();
       	if (null == line)
           continue;
		files.ParseInput(line);
   	}
	files.GetCount();
}

public class RegularFiles
{
	private Dictionary<string, Content> _contentMap;

	public RegularFiles()
	{
		_contentMap = new Dictionary<string, Content>();
	}
	
	public void ParseInput(string line)
	{
		string[] data = line.Split(',').Select(x => x.Trim()).ToArray();
		var input = new {
			FileName = data[0],
			IsDirectory = data[1].Equals("directory") ? true : false,
			RootDirectory = data[4]
		};
		
		if(_contentMap.ContainsKey(input.RootDirectory)) 
			_contentMap[input.RootDirectory].AddContent(input.IsDirectory, input.FileName);
		else
			_contentMap.Add(input.RootDirectory, new Content(input.IsDirectory, input.FileName));
		
		if(input.IsDirectory && !_contentMap.ContainsKey(input.FileName)) {
			_contentMap.Add(input.FileName, new Content());
		}
	}
	
	public void GetCount()
	{
		using(FileStream fs = File.OpenWrite(@"C:\Users\mishrapa\Documents\LINQPad Queries\Interview\output.txt")) 
		using(StreamWriter writer = new StreamWriter(fs))
		{
			foreach (var key in _contentMap.Keys)
			{
				if(key == "NONE") continue;
				int count = _contentMap[key].Files.Count + GetFileCount(_contentMap[key].Directories);
				writer.WriteLine(string.Format("{0}: {1}\n", key, count));
			}
		}
	}
	
	private int GetFileCount(List<string> directories)
	{
		if(directories == null || directories.Count == 0) return 0;
		int totaFiles = 0;
		foreach(var directory in directories)
		{
			totaFiles = totaFiles + _contentMap[directory].Files.Count + GetFileCount(_contentMap[directory].Directories);
		}
		return totaFiles;
	}
	
	public void PrintContent()
	{
		_contentMap.Dump();
	}
}

public class Content
{
	private List<string> _directory = new List<string>(); 
	private List<string> _files = new List<string>();
	
	public Content() {}
	
	public Content(bool isDirectory, string name)
	{
		AddContent(isDirectory, name);
	}
	
	public void AddContent(bool isDirectory, string name)
	{
		if(isDirectory)
			_directory.Add(name);
		else
			_files.Add(name);
	}
	
	public List<string> Directories { get { return _directory; }}
	public List<string> Files { get { return _files; }}
}