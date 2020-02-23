using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using WebApplication.Controllers;

namespace WebApplication
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
        
            //Add custom directory file provider: Step 1 Configuration
            services.Configure<MvcRazorRuntimeCompilationOptions>(options => {
                options.FileProviders.Clear();


                var viewExternalFolderPath1 = GetPathViewExternalFolder("ViewExternalFolder1");
                var viewExternalFolderPath2 = GetPathViewExternalFolder("ViewExternalFolder2");

                options.FileProviders.Add(new PhysicalFileProvider(viewExternalFolderPath1));
                options.FileProviders.Add(new PhysicalFileProvider(viewExternalFolderPath2));

            });

            //Add custom directory file provider: Step 2 .AddRazorRuntimeCompilation
            services.AddRazorPages().AddRazorRuntimeCompilation();


            services.AddControllersWithViews();
        }

        private string GetPathViewExternalFolder(string directoryName)
        {
            //Add folder 
            var baseDirectoryPath = AppContext.BaseDirectory;
            //var assemblyCodeBasePath = Assembly.GetExecutingAssembly().CodeBase;
            //string assemblyLocationPath = System.Reflection.Assembly.GetAssembly(typeof(HomeController)).Location; Directory.GetParent(str_directory).FullName;

            //REVISION/TODO: Search external directory
            var parentDirectory = Directory.GetParent(
                                      Directory.GetParent(
                                            Directory.GetParent(
                                                    Directory.GetParent(
                                                        Directory.GetParent(baseDirectoryPath).ToString()
                                                    ).ToString()
                                            ).ToString()
                                       ).ToString()
                                  ).ToString();


            return Path.Combine(parentDirectory, directoryName);

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
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
