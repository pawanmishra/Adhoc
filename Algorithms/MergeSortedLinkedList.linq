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
</Query>

void Main()
{
	LinkedList<int> ll1 = new LinkedList<int>()
	var node = ll1.AddFirst(1);
	node = ll1.AddAfter(node, 4);
	node = ll1.AddAfter(node, 7);
	node = ll1.AddAfter(node, 9);
	
	//ll1.Dump();
	
	LinkedList<int> ll2 = new LinkedList<int>();
	node = ll2.AddFirst(2);
	node = ll2.AddAfter(node, 3);
	node = ll2.AddAfter(node, 6);
	node = ll2.AddAfter(node, 11);
	
	//ll2.Dump();
	
	var mergeNode = MergeList(ll1, ll2);
	while(mergeNode != null)
	{
		Console.WriteLine(mergeNode.Value);
		mergeNode = mergeNode.Next;
	}
}

public LinkedListNode<int> MergeList(LinkedList<int> list1, LinkedList<int> list2)
{
	LinkedListNode<int> newHead = list1.First.Value < list2.First.Value ? list1.First : list2.First;
	MergeListRec(list1.First, list2.First);
	return newHead;
}

private void MergeListRec(LinkedListNode<int> list1, LinkedListNode<int> list2)
{
	if(list1 == null || list2 == null)
		return;
		
	if(list1.Value <= list2.Value)
	{
		var temp = list1;
		while(temp.Next != null && temp.Next.Value <= list2.Value)
			temp = temp.Next;
			
		list1 = temp.Next;
		var lst = list2.List;
		temp.Next = list2;
		MergeListRec(list1, list2);
	}
	else{
		var temp = list2;
		while(temp.Next != null && temp.Next.Value <= list1.Value)
			temp = temp.Next;
			
		list2 = temp.Next;
		temp.Next = list1;
		MergeListRec(list1, list2);
	}
}

// Define other methods and classes here
