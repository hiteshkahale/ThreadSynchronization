using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadingSynchronization.SyncTechniques
{
    public class MonitorSample : ISyncTechnique
    {
        private object _locker = new object();
        private Queue<int> _intQueue = new Queue<int>();
        private Random random = new Random(125);

		public MonitorSample()
		{
            _intQueue.Enqueue(102);
            _intQueue.Enqueue(548);
            _intQueue.Enqueue(209);
		}
        
        public void Execute()
        {
            new Thread(Read).Start();
            new Thread(Write).Start();
        }

        private void Write()
        {
            while(true)
			{
                lock (_locker)
                {
                    var num = random.Next(0, 999);
                    _intQueue.Enqueue(num);
                    Thread.Sleep(3000);
                    Monitor.Pulse(_locker);
                }
			}
        }

        private void Read()
        {
            while(true)
			{
                lock (_locker)
                {
                    if (_intQueue.Count == 0)
                        Monitor.Wait(_locker);
                    var item = _intQueue.Dequeue();
                    Console.WriteLine(item);
                }
			}
        }
    }
}
