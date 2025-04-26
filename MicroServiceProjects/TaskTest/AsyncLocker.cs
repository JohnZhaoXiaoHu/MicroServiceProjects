using Microsoft.VisualBasic;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskTest
{
    public class AsyncLocker
    {
        private AsyncLock mutex = new AsyncLock();//信号量，同步锁

        private SemaphoreSlim semaphonre = new SemaphoreSlim(1, 2); //信号量，同步锁

        private AsyncAutoResetEvent signal = new AsyncAutoResetEvent(false); //.NET自带的同步锁信号量

        private TaskCompletionSource tcs = new TaskCompletionSource(); // 只能用一次，不能重复利用

        private TaskCompletionSource<string> tcss = new TaskCompletionSource<string>(); // 只能用一次，不能重复利用
        public async void TestAsyncLocked()
        {
            var start = Stopwatch.StartNew();

            var tasks = Enumerable.Range(1, 10)
                .Select(x => ComputeAsync(x))
                .ToList();
            var task = Task.Delay(10);
            //Task.WaitAll(task);

            //Console.WriteLine(string.Join(", ", results));

            #region AsyncAutoResetEvent lock

            var setter = Task.Run(() =>
            {
                Thread.Sleep(1000);
                signal.Set();
            });


            var waitter = Task.Run(async () =>
            {
                await signal.WaitAsync();
                Console.WriteLine("Signal received");
            });

            Task.WaitAll(setter, waitter);

            #endregion

            #region TaskCompletionSource lock
            var tcsSetter = Task.Run(() =>
            {
                Thread.Sleep(1000);
                tcs.SetResult();
            });

            var tcsWaitter = Task.Run(async () =>
            {
                await tcs.Task;
                Console.WriteLine("Signal received");
            });

            Task.WaitAll(tcsSetter, tcsWaitter);

            #endregion

            #region TaskCompletionSource<string> lock
            var tcssSetter = Task.Run(() =>
            {
                Thread.Sleep(1000);
                tcss.SetResult("Hello World");
                if(tcss.TrySetResult("Hello World"))
                {
                    Console.WriteLine("Allready setResult");
                }
            });

            var tcssWaitter = Task.Run(async () =>
            {
                var res = await tcss.Task;
                Console.WriteLine(res);
                Console.WriteLine("Signal received");
            });

            Task.WaitAll(tcssSetter, tcssWaitter);

            #endregion

            Console.WriteLine($"{start.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private async Task<int> ComputeAsync(int x)
        {
            using (await mutex.LockAsync())
            {
                await Task.Delay(1000);
                return x * x;
            }
        }

        private async Task<int> SemaphonreAsync(int x)
        {
            semaphonre.Lock();
            await Task.Delay(1000);
            semaphonre.Release();
            return x * x;
        }
    }
}
