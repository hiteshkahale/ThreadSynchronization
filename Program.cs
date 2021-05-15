using System;
using ThreadingSynchronization.SyncTechniques;

namespace ThreadingSynchronization
{
    enum ThreadSync
    {
        Lock = 1,
        Monitor,
        ManualResetEvent,
        AutoResetEvent,
        Mutex,
        Semaphore
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sample test to execute.\n1. Lock\n2. Monitor\n3. Manual Reset Event\n4. Auto Reset Event\n5. Mutex\n6. Semaphore");
            var input = Convert.ToInt32(Console.ReadLine().ToString());
            ISyncTechnique technique = ThreadSampleFactory((ThreadSync)input);
            technique.Execute();
        }

        private static ISyncTechnique ThreadSampleFactory(ThreadSync lockMethod)
        {
            switch (lockMethod) 
            {
                case ThreadSync.Lock: return new LockSample();
                case ThreadSync.Monitor: return new MonitorSample();
                case ThreadSync.ManualResetEvent: return new ManualResetEventSample();
                case ThreadSync.AutoResetEvent: return new AutoResetEventSample();
                case ThreadSync.Mutex: return new MutexSample();
                case ThreadSync.Semaphore: return new SemaphoreSample();
                default: return null;
            } 
        }
    }
}
