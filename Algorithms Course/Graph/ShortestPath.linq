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
	String filePath = @"C:\Users\mishrapa\Documents\LINQPad Queries\Algorithms Course\Graph\tinyEWD.txt";
	EdgeWeightedDirectedGraph graph = new EdgeWeightedDirectedGraph(filePath);
	graph.Edges().Dump();
}

///
/// Class for representing graph node
///
public class DirectedEdge
{
	private readonly int _from, _to;
	private readonly double _weight;
	
	public DirectedEdge(int frm, int to, double weight)
	{
		_from = frm;
		_to = to;
		_weight = weight;
	}
	
	public int From { get { return _from; }}
	public int To { get { return _to; }}
	public double Weight { get { return _weight; }}
}

///
/// Class representing edge weighted directed graph implementation
///
public class EdgeWeightedDirectedGraph
{
	private readonly DirectedEdge[] _edgeTo;
	private readonly double[] _distTo;
	private readonly List<DirectedEdge>[] _adjList;
	private int _edges, _vertices;
	
	public EdgeWeightedDirectedGraph(int vertexCount)
	{
		_vertices = vertexCount;
		_edgeTo = new DirectedEdge[vertexCount];
		_distTo = new double[vertexCount];
		_adjList = new List<DirectedEdge>[vertexCount];
		
		for(int i = 0; i < vertexCount; i++)
		{
			_adjList[i] = new List<DirectedEdge>();
		}
	}
	
	public EdgeWeightedDirectedGraph(string filePath)
	{
		using(TextReader reader = new StreamReader(filePath))
		{
			_vertices = int.Parse(reader.ReadLine());
			int numEdges = int.Parse(reader.ReadLine());
			_edgeTo = new DirectedEdge[_vertices];
			_distTo = new double[_vertices];
			_adjList = new List<DirectedEdge>[_vertices];
			
			for(int i = 0; i < _vertices; i++)
			{
				_adjList[i] = new List<DirectedEdge>();
			}
			
			while(true) {
				String line = reader.ReadLine();
				if(line == null) break;
				string[] items = line.Split(' ');
				DirectedEdge edge = new DirectedEdge(int.Parse(items[0]), int.Parse(items[1]), double.Parse(items[2]));
				AddEdge(edge);
			}
		}
	}
	
	public int E { get { return _edges; }}
	public int V { get { return _vertices; }}
	
	public IEnumerable<DirectedEdge> AdjNodes(int vertex) {
		return _adjList[vertex];
	}
	
	public void AddEdge(DirectedEdge edge)
	{
		_adjList[edge.From].Add(edge);
		_edges++;
	}
	
	public IEnumerable<DirectedEdge> Edges()
	{
		List<DirectedEdge> edges = new List<DirectedEdge>();
		for(int i = 0 ; i < _vertices; i++)
		{
			foreach(var edge in AdjNodes(i))
			{
				edges.Add(edge);
			}
		}
		
		return edges;
	}
}

///
/// Class for finding shortest path in graph
///
public class ShortestPath
{
}

///
/// Class for implementing key index minimum priority queue
///
public class IndexMinPQ<T>
{
}