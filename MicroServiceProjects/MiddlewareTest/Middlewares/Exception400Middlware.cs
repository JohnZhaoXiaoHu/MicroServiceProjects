using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareTest.Middlewares
{
    [Middleware]
    public class Exception400Middlware: Middleware
    {
        public override void Invoke(HttpContext httpContext)
        {
            Console.WriteLine("Exception400 middleware");

            if (middleware != null)
            {
                middleware.Invoke(httpContext);
            }
        }
    }
}
