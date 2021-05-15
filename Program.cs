using System;
using ThreadingSynchronization.SyncTechniques;

namespace ThreadingSynchronization
{
    enum ThreadSync
    {
        Lock = 1,
        Monitor
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter sample test to execute.\n1. Lock\n2. Monitor");
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
                default: return null;
            } 
        }
    }
}
