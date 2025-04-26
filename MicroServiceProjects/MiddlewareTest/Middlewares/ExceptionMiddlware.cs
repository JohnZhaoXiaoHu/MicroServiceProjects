using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareTest.Middlewares
{
    [Middleware]
    public class ExceptionMiddlware: Middleware
    {
        public override void Invoke(HttpContext httpContext)
        {
            Console.WriteLine("Exception middleware");

            if (middleware != null)
            {
                middleware.Invoke(httpContext);
            }
        }
    }
}
