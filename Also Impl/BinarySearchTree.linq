<Query Kind="Program">
  <Reference>C:\FSharp\PM_DataGen\DataGenerator\packages\Fare.1.0.0\lib\net35\Fare.dll</Reference>
  <Reference>C:\Personal\FileTransferService.dll</Reference>
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
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.Services.dll</Reference>
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

public class BST<TKey, TValue> where T : IComparable
{
	public Node root;
	
	private class Node
	{
		public TKey key;
		public TValue value;
		public int size;
		public Node left, right;
		
		public Node(TKey key, TValue value, int n)
		{
			this.key = key;
			this.value = value;
			this.size = n;
		}
	}
	
	public int Size()
	{
		return size(root);
	}
	
	private int Size(Node node)
	{
		if(node == null) return 0;
		else return node.size;
	}
	
	public TValue get(TKey key)
	{
		if(root == null) return null;
		return get(root, key);
	}
	
	private TValue get(Node node, TKey key)
	{
		if(node.key == key) return node.value;
		else if(node.key > key) return get(node.left, key);
		else return get(node.right, key);
	}
	
	public void put(TKey key, TValue value)
	{
		root = put(root, key, vaue);
	}
	
	private Node put(Node node, TKey key, TValue value)
	{
		if(node == null) return new Node(key, value, 1);
		if(node.key > key) node.left = put(node.left, key, value);
		else if(node.key < key) node.right = put(node.right, key, value);
		else node.value = value;
		node.size = Size(node.left) + Size(node.right) + 1;
		return node;
	}
	
	public TKey min()
	{
		return min(root).key;
	}
	
	private Node min(Node x)
	{
		if(x.left == null) return x;
		return min(x.left);
	}
	
	public TKey floor(TKey key)
	{
		Node x = floor(root, key);
		if(x == null) return null;
		return x.key;
	}
	
	private Node floor(Node root, TKey key)
	{
		if(root == null) return null;
		if(root.key > key) return floor(root.left, key);
		Node t = floor(root.right, key);
		if(t != null) return t;
		else return root;
	}
	
	public key select(int k)
	{
		return select(root, k).key;
	}
	
	private Node select(Node x, int k)
	{
		if(x == null) return null;
		int t = Size(x.left);
		if(t > k) return select(x.left, k);
		else if (t < k) return select(x.right, k - t - 1);
		else return x;
	}
	
	public int rank(TKey key)
	{
		return rank(root, key);
	}
	
	private int rank(Node node, TKey key)
	{
		if(node == null) return 0;
		if(node.key == key) return Size(node.left);
		else if(node.key > key) return rank(node.left , key);
		else return 1 + Size(node.left) + rank(node.right, key);
	}
}