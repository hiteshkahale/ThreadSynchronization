using System;
using System.Threading;

namespace ThreadingSynchronization.SyncTechniques
{
	public class AutoResetEventSample : ISyncTechnique
	{
		private AutoResetEvent _are = new AutoResetEvent(true);

		public void Execute()
		{
			for (int i = 0; i < 5; i++)
			{
				new Thread(Write).Start();
			}
		}

		private void Write()
		{
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} waiting...");
			_are.WaitOne();
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing...");
			Thread.Sleep(2000);
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing completed.");
			_are.Set();
		}
	}
}
