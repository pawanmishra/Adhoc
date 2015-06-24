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
	Graph g = new Graph(7);
	g.AddEdge(0, 5);
	g.AddEdge(0, 6);
	g.AddEdge(0, 1);
	g.AddEdge(0, 2);
	g.AddEdge(5, 3);
	g.AddEdge(5, 4);
	g.AddEdge(3, 4);
	g.AddEdge(6, 4);
	g.Bfs(0);
	g.Previous.Dump();
	g.Path(0, 4).Dump();
	g.GetDistance(4).Dump();
}

public class Graph
{
	private bool[] _visited;
	private int[] _previous;
	private int[] _dist;
	private List<int>[] _adjacencyList;
	
	public Graph(int vertexCount)
	{
		_visited = new bool[vertexCount];
		_previous = new int[vertexCount];
		_dist = new int[vertexCount];
		_adjacencyList = new List<int>[vertexCount];
		for(int i = 0; i < vertexCount; i++)
		{
			_adjacencyList[i] = new List<int>();
		}
	}
	
	public void AddEdge(int source, int target)
	{
		_adjacencyList[source].Add(target);
		_adjacencyList[target].Add(source);
	}
	
	public IEnumerable<int> GetAdjacentNodes(int vertex)
	{
		return _adjacencyList[vertex];
	}
	
	public void Bfs(int source)
	{
		Queue<int> queue = new Queue<int>();
		queue.Enqueue(source);
		_dist[source] = 0;
		while(queue.Count != 0)
		{
			var tmpNode = queue.Dequeue();
			foreach(var item in this.GetAdjacentNodes(tmpNode))
			{
				if(!_visited[item])
				{
					queue.Enqueue(item);
					_visited[item] = true;
					_previous[item] = tmpNode;
					_dist[item] = _dist[tmpNode] + 1;
				}
			}
		}
		
	}
	
	public int GetDistance(int node) {
		return _dist[node];
	}
	
	private bool HasPath(int vertex)
	{
		return _visited[vertex];
	}
	
	public Stack<int> Path(int source, int target)
	{
		if(!HasPath(target)) return null;
		Stack<int> stk = new Stack<int>();
		stk.Push(target);
		while(target != source)
		{
			target = _previous[target];
			stk.Push(target);
		}
		
		return stk;
	}
	
	public List<int>[] AdjList {get {return _adjacencyList; }}
	public int[] Previous {get {return _previous; }}
}

// Define other methods and classes here