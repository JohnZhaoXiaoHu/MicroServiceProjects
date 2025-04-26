using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ThreadTest
{
    public class TestQueue
    {
        private Queue<int> threadUnsafeQueue;
        private ConcurrentQueue<int> threadSafeQueue;
        public TestQueue()
        {
            threadUnsafeQueue = new Queue<int>();//需要加锁，否则取数据会顺序会打乱
            threadSafeQueue = new ConcurrentQueue<int>();//线程安全的队列，不想要加锁，多个线程可以同步访问
            var writer = new Thread(AddNumbers);
            var reader11 = new Thread(ReadNumbers1);
            var reader12 = new Thread(ReadNumbers1);

            writer.Start();
            reader11.Start();
            reader12.Start();

            writer.Join();
            //reader1.Interrupt();
            //reader2.Interrupt();
            reader11.Join();
            reader12.Join();

            //var writer = new Thread(AddNumbers);
            //var reader21 = new Thread(ReadNumbers2);
            //var reader22 = new Thread(ReadNumbers2);
            //writer.Start();
            //reader21.Start();
            //reader22.Start();

            //writer.Join();
            //reader21.Join();
            //reader22.Join();
        }

        public void AddNumbers()
        {
            for (int i = 0; i < 20; i++)
            {
                //Thread.Sleep(20);
                threadUnsafeQueue.Enqueue(i);
                threadSafeQueue.Enqueue(i);
            }
        }


        public void ReadNumbers1()
        {
            try
            {
                while (true)
                {
                    if (threadSafeQueue.TryDequeue(out var res))
                    {
                        Console.WriteLine(res);
                    }

                    //Thread.Sleep(1);
                }
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine($"Thread Interrupted: {ex.Message}");
            }

            Console.WriteLine();
        }

        public void ReadNumbers2()
        {
            try
            {
                while (true)
                {

                    if (threadUnsafeQueue.TryDequeue(out var res))
                    {
                        Console.WriteLine(res);
                    }

                    //Thread.Sleep(1);
                }
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine($"Thread Interrupted: {ex.Message}");
            }

            Console.WriteLine();
        }

    }
}
