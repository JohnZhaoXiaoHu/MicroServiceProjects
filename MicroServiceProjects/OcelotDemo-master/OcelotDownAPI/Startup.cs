using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OcelotDownAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //IdentityServerConfig identityServerConfig = new IdentityServerConfig();
            //Configuration.Bind("IdentityServerConfig", identityServerConfig);
            //services.AddAuthentication(identityServerConfig.IdentityScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.Authority = $"http://{identityServerConfig.IP}:{identityServerConfig.Port}";
            //        options.ApiName = identityServerConfig.ResourceName;
            //    }
            //    );
            services.AddControllers(options =>
                     {
                         options.EnableEndpointRouting = false;
                     });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseAuthentication();

            app.UseMvc();
        }
    }
}
