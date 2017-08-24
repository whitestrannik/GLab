using GLab.Base.Threads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Glab.Test.ConsoleExecutable
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskQueueAsyncLauncherTest();
            //TaskQueueLauncherTest();

            Console.ReadLine();
        }

        private static void TaskQueueAsyncLauncherTest()
        {
            ITaskQueueLauncher launcher = new TaskQueueAsyncLauncher();

            Enumerable.Range(1, 10).Select(i => Task.Run(() => SendToLauncher(launcher, i))).ToArray();
        }

        private static void TaskQueueLauncherTest()
        {
            ITaskQueueLauncher launcher = new TaskQueueContinuationLauncher();

            Enumerable.Range(1, 10).Select(i => Task.Run(() => SendToLauncher(launcher, i))).ToArray();
        }

        private static void SendToLauncher(ITaskQueueLauncher launcher, int number)
        {
            for (var i = 0; i < 1000; i++)
            {
                var temp = i;

                Thread.Sleep(new Random().Next(100));

                launcher.Run(token =>
                {
                    Console.WriteLine($"{number}{temp}| Start");
                    Thread.Sleep(new Random().Next(40));
                    token.ThrowIfCancellationRequested();
                    Thread.Sleep(new Random().Next(40));
                },
                task =>
                {
                    if (task.Exception != null)
                    {
                        Console.WriteLine($"{number}{temp}| Exception");
                    }

                    if (task.IsCanceled)
                    {
                        Console.WriteLine($"{number}{temp}| Cancelled");
                    }
                    else
                    {
                        Console.WriteLine($"{number}{temp}| Finished");
                    }


                });
            }
        }
    }

    public class BaseClass : IDisposable
    {
        public void Dispose() { } // sealed
    }

    public class DeriveClass : BaseClass, IDisposable
    {
        new public void Dispose() { } // new implementation
    }

    {
        BaseClass b = new DeriveClass();
        b.Dispose(); // base implementation
        ((IDisposable)b).Dispose(); // derive implementation

        DeriveClass d = new DeriveClass();
        d.Dispose(); // derive implementation
        ((IDisposable)b).Dispose(); // derive implementation
    }
}
