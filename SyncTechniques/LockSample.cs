using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingSynchronization.SyncTechniques
{
    public class LockSample : ISyncTechnique
    {
        private object _locker = new object();

        public void Execute()
        {
            for (int i = 0; i < 5; i++)
            {
                new Thread(DoWork).Start();
            }
        }

        private void DoWork()
        {
            lock (_locker)
            {
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting.");
                Thread.Sleep(2000);
                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finishes.");
            }
        }
    }

}
