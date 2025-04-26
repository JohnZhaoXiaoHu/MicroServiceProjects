using MiddlewareTest.Middlewares;

namespace MiddlewareTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HttpContext httpContext = new HttpContext();

            Application app = new Application();

            var http = app.Build();
            http.Invoke(httpContext);


            Console.ReadKey();
        }
    }
}