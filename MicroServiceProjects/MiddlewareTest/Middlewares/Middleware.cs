using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareTest.Middlewares
{
    public abstract class Middleware
    {
        public Middleware middleware { get; set; }

        public abstract void Invoke(HttpContext httpContext);
    }
}
