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
	BinarySearchTree tree = new BinarySearchTree();
	tree.Add(30);
	tree.Add(8);
	tree.Add(52);
	tree.Add(3);
	tree.Add(20);
	tree.Add(10);
	tree.Add(29);
	tree.Ancestor(29, 20).Dump();
}

public class BinarySearchTree
{
	private Node _root;
	private Stack<int> _stack;
	
	public void Add(int value)
	{
		_root = Insert(_root, value);
	}
	
	private Node Insert(Node node, int value)
	{
		if(node == null)
			return new Node(value);
		
		if(node.Value < value)
			node.Right = Insert(node.Right, value);
		else if(node.Value > value)
			node.Left = Insert(node.Left, value);
		else
			node.Value = value;
		return node;
	}
	
	public int Search(int value)
	{
		return Search(_root, value);
	}
	
	private int Search(Node node, int value)
	{
		if(_root == null)
			throw new InvalidOperationException("Root element is missing");
		
		if(_root.Value == value)
			return _root.Value;
		else if(_root.Value > value)
			return Search(_root.Left, value);
		else
			return Search(_root.Right, value);
	}
	
	public int Ancestor(int v1, int v2)
	{
		_stack = new Stack<int>();
		return Ancestor(_root, v1, v2);
	}
	
	private int Ancestor(Node node, int v1, int v2)
	{
		if((node.Value == v1 || node.Value == v2) && _stack.Count > 0)
			return _stack.Pop();
		
		_stack.Push(node.Value);
			
		if((v1 <= node.Value && v2 >= node.Value) || (v1 >= node.Value && v2 <= node.Value))
			return node.Value;
		
		if(v1 < node.Value && v2 < node.Value) {
			return Ancestor(node.Left, v1, v2);
		}
		
		if(v1 > node.Value && v2 > node.Value){
			return Ancestor(node.Right, v1, v2);
		}
			
		throw new InvalidOperationException("Node not found");
	}
	
	public void Print()
	{
		Print(_root);
	}
	
	private void Print(Node root)
	{
		if(root == null)
			return;
		
		Console.WriteLine(root.Value);
		Print(root.Left);
		Print(root.Right);
	}
	
	private class Node
	{
		private int _value;
		private Node _left, _right;
		
		public Node(int value)
		{
			this._value = value;
		}
		
		public int Value { get {return _value; } set { _value = value; }}
		public Node Left { get {return _left; } set { _left = value; }}
		public Node Right { get {return _right; } set { _right = value; }}
	}
}



// Define other methods and classes here