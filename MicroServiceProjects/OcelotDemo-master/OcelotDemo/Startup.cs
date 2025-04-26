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
using Ocelot.Middleware;
using Ocelot.Provider.Polly;
using Ocelot.DependencyInjection;
using IdentityServer4.AccessTokenValidation;

namespace OcelotDemo
{
    using Ocelot.Provider.Consul;
    using OcelotDemo.Aggregator;
    using OcelotDemo.Dependency;

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
            services.AddSingleton<LeaderAdvancedDependency>();
            services.AddOcelot()
                .AddPolly()
                .AddConsul().AddSingletonDefinedAggregator<LeaderAdvancedAggregator>();

            var identityBuilder = services.AddAuthentication();
            IdentityServerConfig identityServerConfig = new IdentityServerConfig();
            Configuration.Bind("IdentityServerConfig", identityServerConfig);
            if (identityServerConfig != null && identityServerConfig.Resources != null)
            {
                foreach (var resource in identityServerConfig.Resources)
                {
                    identityBuilder.AddIdentityServerAuthentication(resource.Key, options => 
                    {
                        options.Authority = $"http://{identityServerConfig.IP}:{identityServerConfig.Port}";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = resource.Name;
                        options.SupportedTokens = SupportedTokens.Both;
                    });
                }
            }
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
            app.UseOcelot().Wait();
        }
    }
}
