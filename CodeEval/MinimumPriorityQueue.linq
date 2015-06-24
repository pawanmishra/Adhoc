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
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.Expressions.dll</Reference>
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
	MinPQ minPq = null;
	using (StreamReader reader = File.OpenText(@"C:\Users\mishrapa\Documents\LINQPad Queries\CodeEval\test.txt"))
	while (!reader.EndOfStream)
	{
		string line = reader.ReadLine();
		if (null == line)
			continue;
		
		if(minPq == null) {
			minPq = new MinPQ(int.Parse(line));
			continue;
		}
		
		Data data = new Data(line);
		minPq.Insert(data);
	}
	
	var items = minPq.Items.Skip(1).OrderByDescending(t => t.Length).Select(u => u.Line);
	foreach(var line in items)
	{
		Console.WriteLine(line);
	}
}

public class MinPQ
{
	private int N = 0;
	private int _capacity;
	private Data[] _data;
	
	public MinPQ(int n)
	{
		_data = new Data[n + 1];
		_capacity = n;
	}
	
	public bool IsEmpty
	{
		get {return N == 0; }
	}
	
	public bool IsFull
	{
		get { return (_data.Length - 1 == N); }
	}
	
	public Data[] Items { get { return _data; }}
	
	public int Size
	{
		get { return _data.Length; }
	}
	
	public void Insert(Data data)
	{
		if (this.IsFull)
		{
			if(data.Length > _data[1].Length)
			{
				_data[1] = data;
				Sink(1);
			}
		}
		else
		{
			_data[++N] = data;
			Swim(N);
		}
	}
	
	private void Swim(int k)
	{
		while(k > 1 && Compare(k/2, k))
		{
			Exchange(k/2, k);
			k = k/2;
		}
	}
	
	private void Sink(int k)
	{
		while(2 * k <= N)
		{
			int j = 2 * k;
			if( j < N && Compare(j, j + 1)) j++;
			if (!Compare(k, j)) break;
			Exchange(k, j);
			k = j;
		}
	}
	
	private bool Compare(int i, int j)
	{
		return _data[i].CompareTo(_data[j]) > 0;
	}
	
	private void Exchange(int i, int j)
	{
		var temp = _data[i];
		_data[i] = _data[j];
		_data[j] = temp;
	}
}

public class Data : IComparable<Data>
{
	private int _count;
	private string _line;
	
	public Data(string line)
	{
		this._count = line.Length;
		this._line = line;
	}
	
	public int Length { get { return _count; }}
	public string Line { get { return _line; }}
	
	public int CompareTo(Data other)
	{
		if(this.Length > other.Length)
			return 1;
		else if(this.Length < other.Length)
			return -1;
		else
			return 0;
	}
}
// Define other methods and classes here
