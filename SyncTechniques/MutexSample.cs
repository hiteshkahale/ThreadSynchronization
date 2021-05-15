using System;
using System.Threading;

namespace ThreadingSynchronization.SyncTechniques
{
	public class MutexSample : ISyncTechnique
	{
		private Mutex _mutex = new Mutex();

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
			_mutex.WaitOne();
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing...");
			Thread.Sleep(2000);
			Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} writing completed.");
			_mutex.ReleaseMutex();
		}
	}
}
