using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace xSolution
{
    public class Startup
    {
        // This method gets called by the runtime to add services to the container.
        private IHostingEnvironment _env; // Securing my enviroment
        
        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime to configure the HTTP(s) request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles(); // I want this software to use wwwwroot files to serve users.
            app.UseCookiePolicy(); // This will add GDPR policy.

            app.UseMvc(route => // webapp pagination and structure 
            {
                route.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller}/{action}/{id?}",
                    defaults: new 
                    // this will check an index page under Area Controllers
                    {
                        controller = "Home",
                        action = "Index"
                    });

                route.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new // this will chek an index page under root Controllers
                    {
                        controller = "Home",
                        action = "Index"
                    });
            });
        }
    }
}
