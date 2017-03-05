using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GLab.Questions
{
    public class Observerables
    {
        public Observerables()
        { }

        public void Do()
        {
            var ooo = Observable.Create<int>(async o =>
            {
                while (true)
                {
                    var val = new Random().Next(3);
                    await Task.Run(() => Console.WriteLine("Do... " + val));
                    await Task.Delay(500);
                    o.OnNext(val);
                }
            })
            //.Delay(TimeSpan.FromMilliseconds(2000))
            .DistinctUntilChanged()
            
            .Publish();

            ooo.Connect();

            ooo.Subscribe(u => Console.WriteLine("OnNext " + u));

            Thread.Sleep(2000);

            ooo.Subscribe(u => { Console.WriteLine("=== OnNext " + u); Thread.Sleep(5000); });

            //StartAsync()
            //    .ToObservable()
            //    .Subscribe(u => Console.WriteLine("OnNext"));
        }

        public async Task StartAsync()
        {
            await Task.Run(() => Console.Write("Do..."));
            await Task.Delay(1000);

            //while (true)
            //{
            //    await Task.Run(() => Console.Write("Do..."));
            //    await Task.Delay(1000);
            //}
        }
    }
}
