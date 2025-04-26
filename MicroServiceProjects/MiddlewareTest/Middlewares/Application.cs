using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareTest.Middlewares
{
  
    public class Application
    {
        List<Middleware> middlewares = new List<Middleware>();
        public Application()
        {
            #region MyRegion
            {
                //SwaggerMiddleware swagger = new SwaggerMiddleware();
                //AuthorizationMiddleware authorization = new AuthorizationMiddleware();
                //ControllersMiddleware controllers = new ControllersMiddleware();
                //ExceptionMiddlware exception = new ExceptionMiddlware();
                //Exception400Middlware exception400 = new Exception400Middlware();

                //swagger.middleware = authorization;
                //authorization.middleware = controllers;
                //controllers.middleware = exception;
                //exception.middleware = exception400;

                //middlewares.Add(swagger);
                //middlewares.Add(authorization);
                //middlewares.Add(controllers);
                //middlewares.Add(exception);
            }
            #endregion


            #region MyRegion
            {
                Assembly assembly = Assembly.Load("MiddlewareTest");
                Type[] types = assembly.GetTypes();
                foreach (Type t in types) 
                {
                    MiddlewareAttribute middlewareAttribute = t.GetCustomAttribute<MiddlewareAttribute>();
                    if (middlewareAttribute != null)
                    {
                       object middleware =  Activator.CreateInstance(t);
                        middlewares.Add(middleware as Middleware);
                    }
                }
            } 
            #endregion
        }

        public Middleware Build()
        {
            Middleware currntMiddleware = null;
            foreach (Middleware middleware in middlewares)
            {
                if (currntMiddleware != null)
                {
                    middleware.middleware = currntMiddleware;

                    currntMiddleware = middleware;
                }
                else
                {
                    currntMiddleware = middleware;
                }
            }

            return currntMiddleware;
        }
    }
}
