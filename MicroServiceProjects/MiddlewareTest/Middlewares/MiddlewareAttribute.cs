using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareTest.Middlewares
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MiddlewareAttribute: Attribute
    {
    }
}
