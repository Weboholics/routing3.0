using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Routing_30.Infrastructure;

namespace Routing_30
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
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "crawler-robot",
                    pattern: "robots.txt",
                    defaults: new { Controller = "Crawler", Action = "Robots" });

                //Error and statuscode route
                endpoints.MapControllerRoute(
                    name: "Error",
                    pattern: "{culture}/error/{action}/{statuscode?}",
                    defaults: new { Controller = "Error" });

                //url:"","sv-se"
                //Actions on home controller
                endpoints.MapControllerRoute(
                   name: "domain_actions",
                   pattern: "{culture?}/",
                   defaults: new { controller = "Home", Action = "index" },
                   constraints: new {});

                //Note that home is not a valid controller...
                //url:"sv-se/admin/login","sv-se/admin/"
                endpoints.MapControllerRoute(
                   name: "culture",
                   pattern: "{culture}/{controller=home}/{action=index}/{id?}",
                   constraints: new {controller = new IsValidController() });


                //url:"sv-se/content/127-article"
                endpoints.MapControllerRoute(
                   name: "home_actions",
                   pattern: "{culture}/{action}/{id?}",
                   defaults: new { controller = "Home" },
                   constraints: new {});

            });
        }
    }
}
