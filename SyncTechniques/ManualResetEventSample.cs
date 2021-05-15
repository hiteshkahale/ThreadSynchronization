using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSynchronization.SyncTechniques
{
	public class ManualResetEventSample : ISyncTechnique
	{
		private ManualResetEvent _mre = new ManualResetEvent(false);

		public void Execute()
		{
			new Thread(Write).Start();
			for (int i = 0; i < 5; i++)
			{
				new Thread(Read).Start();
			}
		}

		private void Read(object obj)
		{
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting...");
			_mre.WaitOne();
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} reading...");
		}

		private void Write(object obj)
		{
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing...");
			_mre.Reset();
			Thread.Sleep(2000);
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing completed.");
			_mre.Set();
		}
	}
}
