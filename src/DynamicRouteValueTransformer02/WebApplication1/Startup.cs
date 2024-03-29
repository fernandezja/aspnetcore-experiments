using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Starwars.Jedis.Business;
using WebApplication1.Code;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public static Autofac.IContainer ApplicationContainer { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            var builderAutofac = new Autofac.ContainerBuilder();

            ApplicationContainer = builderAutofac.Build();

        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new BusinessAutofacModule());

            builder.RegisterType<StarwarsDynamicRouteValueTransformer>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                //endpoints.MapDynamicControllerRoute<StarwarsDynamicRouteValueTransformer>(
                //                        pattern: "{**endpoint}");

                endpoints.MapDynamicControllerRoute<StarwarsDynamicRouteValueTransformer>(
                                        pattern: "{language}/{**endpoint}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
