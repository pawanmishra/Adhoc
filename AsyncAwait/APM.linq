<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Collections.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Core.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Linq.dll</Reference>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{
	FileInfo info = new FileInfo(@"C:\Users\mishrapa\Downloads\mongodb-win32-x86_64-2008plus-2.4.8.zip");
	using(var fs = File.OpenRead(@"C:\Users\mishrapa\Downloads\mongodb-win32-x86_64-2008plus-2.4.8.zip"))
	{
		System.Threading.Thread.CurrentThread.IsThreadPoolThread.Dump();
		var buffer = new byte[info.Length]; // 1 MB buffer
		IAsyncResult iar = fs.BeginRead(buffer, 0, buffer.Length, result =>
		{
			// This code will be called upon completion.
			System.Threading.Thread.CurrentThread.IsThreadPoolThread.Dump();
			int count = fs.EndRead(result);
			Console.WriteLine("{0} bytes read", count);
		}, null);
	
		Console.Write("Read operation started");
		while (!iar.IsCompleted)
		{
			Console.Write(".");  // Here we could be doing other useful work.
		}
	
		Console.ReadLine();
	}
}

// Define other methods and classes here
