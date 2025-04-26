using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ThreadTest
{
    internal class Program
    {
        private static int[] inputs;
        private static int[] outputs;
        static void Main(string[] args)
        {
            Console.WriteLine("Begin");
            Console.WriteLine();

            //inputs = Enumerable.Range(1, 50).ToArray();
            //outputs = new int[inputs.Length];

            //TestThread();


            TestQueue testQueue = new TestQueue();  


            Console.WriteLine();
            Console.WriteLine("Finish");
            Console.WriteLine();

            Console.ReadKey(); ;
        }


        public static void TestThread()
        {
            var th = new Thread((data) =>
            {
                try
                {
                    Console.WriteLine($"data: {data}");
                    for (int i = 0; i < 20; i++)
                    {
                        Thread.Sleep(200);
                        Console.WriteLine("Thread is still running...");
                    }
                }
                catch (ThreadInterruptedException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Thread is finished");
                }
            })
            { IsBackground = true, Priority = ThreadPriority.Normal };

            th.Start(10086);
            Console.WriteLine("In main thread, waiting for thread to finish...");

            //th.Abort();

            Thread.Sleep(1000);
            th.Interrupt();

            th.Join();
            Console.WriteLine("Done.");
        }

        public static void Test1()
        {
            var sw = Stopwatch.StartNew();

            for (int i = 0; i < inputs.Length; i++)
            {
                outputs[i] = HeavyJob(inputs[i]);
            }

            Console.WriteLine($"Times: {sw.ElapsedMilliseconds}");
        }

        //Use Parallel
        public static void TestParallel()
        {
            var sw = Stopwatch.StartNew();

            Parallel.For(0, inputs.Length, (i) => outputs[i] = HeavyJob(inputs[i]));

            Console.WriteLine($"Times: {sw.ElapsedMilliseconds}");
        }

        //Use PLINQ
        public static void TestPLINQ()
        {
            var sw = Stopwatch.StartNew();

            //AsOrdered() use to be order by
            outputs = inputs.AsParallel().AsOrdered().Select(x => HeavyJob(x)).ToArray();

            Console.WriteLine($"Times: {sw.ElapsedMilliseconds}");
        }

        private static int HeavyJob(int input)
        {
            Thread.Sleep(100);

            return input * input;
        }
    }
}