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
	Node n20 = new Node(20);
	n20.Left = new Node(9);
	n20.Left.Left = new Node(5);
	n20.Left.Right = new Node(12);
	n20.Left.Right.Right = new Node(15);
	n20.Right = new Node(49);
	n20.Right.Left = new Node(23);
	n20.Right.Right = new Node(52);
	n20.Right.Right.Left = new Node(50);
	
	PrintPath(n20);
}

public class Node
{
	public Node Left {get; set;}
	public Node Right {get; set;}
	public bool IsVisited {get; set;}
	public int Value {get;set;}
	
	public Node(int value)
	{
		this.Value = value;
	}
}

public static bool IsLeaveElement(Node node)
{
	if(node == null) return false;
	if(node.Left == null && node.Right == null) return true;
	return false;
}

public static void PrintPath(Node node)
{
	Stack<Node> stack = new Stack<Node>();
	stack.Push(node);
	
	while(stack.Count != 0)
	{
		Node item = stack.Peek();
		
		if(!item.IsVisited) {
			Node tempLeft = item.Left;
			if(tempLeft != null && !tempLeft.IsVisited)
			{
				stack.Push(tempLeft);
				continue;
			}
			
			Node tempRight = item.Right;
			if(tempRight != null && !tempRight.IsVisited) {
				stack.Push(tempRight);
				continue;
			}
			
			item.IsVisited = true;
		}
		else {
			item.IsVisited = true;
			if(IsLeaveElement(item)) {
				foreach(var value in stack) {
					Console.Write(value.Value + " --> ");
				}
				Console.WriteLine();
			}
			stack.Pop();
		}
	}
}

// Define other methods and classes here
