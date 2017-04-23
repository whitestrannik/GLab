using GLab.Base.Threads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace Glab.Test.Base
{
    //[TestClass]
    //public class TaskQueueLauncherTest
    //{
    //    [TestMethod]
    //    public void TestMethod1()
    //    {
    //        ITaskQueueLauncher launcher = new TaskQueueLauncher();

    //        Enumerable.Range(1, 20).Select(i => Task.Run(() => SendToLauncher(launcher, i)));
    //    }

    //    private void SendToLauncher(ITaskQueueLauncher launcher, int number)
    //    {
    //        for (var i = 0; i < 200; i++)
    //        {
    //            launcher.Run(token =>
    //            {
                    
    //                Thread.Sleep(70);
    //                token.ThrowIfCancellationRequested();
    //                Thread.Sleep(70);
    //            },
    //            task =>
    //            { });
    //        }
    //    }
    //}
}
