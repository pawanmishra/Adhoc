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
	
}

// Slow. Performance is n(2)
public class QuickFindUF
{
	private readonly int[] _elements;
	
	public QuickFindUF(int n)
	{
		_elements = new int[n];
		for(int i = 0; i < n; i++)
			_elements[i] = i;
	}
	
	public bool IsConnected(int p, int q)
	{
		return (_elements[p] == _elements[q]);
	}
	
	public void Union(int p, int q)
	{
		int pValue = _elements[p];
		int qValue = _elements[q];
		
		for(int i = 0; i < _elements.Length; i++)
		{	
			if(_elements[i] == pValue) _elements[i] = qValue;
		}
	}
}

// Fast
public class QuickUnionUF
{
	private readonly int[] _elements;
	
	public QuickUnionUF(int n)
	{
		_elements = new int[n];
		for(int i = 0; i < n; i++)
			_elements[i] = i;
	}
	
	private int Root(int i)
	{
		while(i != _elements[i])
		{
			i = _elements[i];
		}
		
		return i;
	}
	
	public bool IsConnected(int p, int q)
	{
		return (Root(p) == Root(q));
	}
	
	public void Union(int p, int q)
	{
		var pRoot = Root(p);
		var qRoot = Root(q);
		_elements[pRoot] = qRoot;
	}
}

public class WeightedQuickUnionUF
{
	private readonly int[] _elements;
	private readonly int[] _size;
	
	public WeightedQuickUnionUF(int n)
	{
		_elements = new int[n];
		_size = new int[n];
		for(int i = 0; i < n; i++) {
			_elements[i] = i;
			_size[i] = 1;
		}
	}
	
	private int Root(int i)
	{
		while(i != _elements[i])
		{
			i = _elements[i];
		}
		
		return i;
	}
	
	public bool IsConnected(int p, int q)
	{
		return (Root(p) == Root(q));
	}
	
	public void Union(int p, int q)
	{
		var pRoot = Root(p);
		var qRoot = Root(q);
		if(pRoot == qRoot) return;
		if(_size[p] < _size[q]) 
		{
			_elements[p] = q;
			_size[q] += _size[p];
		}
		else
		{
			_elements[q] = p;
			_size[p] += _size[q];
		}
	}
}
// Define other methods and classes here
