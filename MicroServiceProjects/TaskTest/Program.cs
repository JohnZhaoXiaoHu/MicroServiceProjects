namespace TaskTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
         
            Console.WriteLine("Hello, World!");
        }

        public  async Task<int> TaskTest()
        { 
           await Task.Delay(1000).ConfigureAwait(true);
           return 100;
        }
    }
}