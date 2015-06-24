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

public interface IBuffer
{
	byte[] Buffer {get;}
}

public interface IBufferRegistration : IBuffer, IDisposable
{
}

public class LOHBuffer : IBuffer
{
	private readonly byte[] buffer;
	private const int MAXBufferSizeCount = 85000;
	internal bool InUse {get; set;}
	
	public LOHBuffer()
	{
		buffer = new byte[MAXBufferSizeCount];
	}
	
	public byte[] Buffer { get { return buffer; }}
}

public class BufferPool
{
	private SemaphoreSlim guard;
	private List<LOHBuffer> buffers;
	
	public BufferPool(int maxSize)
	{
		guard = new SemaphoreSlim(maxSize);
		buffers = new List<LOHBuffer>(maxSize);
	}
	
	private IBufferRegistration GetBuffers()
	{
		guard.Wait();
		
		lock(buffers)
		{
			IBufferRegistration freeBuffer = null;
			
			foreach(var buf in buffers)
			{
				if(!buf.InUse)
				{
					buf.InUse = true;
					freeBuffer = new BufferRegistration(this, buf);
				}
			}
			
			if(freeBuffer == null)
			{
				var buffer = new LOHBuffer();
				buffer.InUse = true;
				buffers.Add(buffer);
				freeBuffer = new BufferRegistration(this, buf);
			}
			
			return freeBuffer;
		}
	}

	private void Release(LOHBuffer buffer)
	{
		buffer.InUse = false;
		guard.Release();
	}

	class BufferRegistration : IBufferRegistration
	{
		private readonly BufferPool pool;
		private readonly LOHBuffer lohBuffer;
		
		public BufferRegistration(BufferPool pool, LOHBuffer buffer)
		{
			pool = pool;
			lohBuffer = buffer;
		}
		
		public byte[] Buffer
		{
			get { return lohBuffer.Buffer; }
		}
		
		public void Dispose()
		{
			
		}
	}
}