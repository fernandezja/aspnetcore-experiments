using Autofac;
using Autofac.Extensions.DependencyInjection;
using Starwars.Jedis.Business;
using WebApplication1.Code;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllersWithViews();

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new BusinessAutofacModule());
    containerBuilder.RegisterType<StarwarsDynamicRouteValueTransformer>();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapDynamicControllerRoute<StarwarsDynamicRouteValueTransformer>("jedi/{jediendpoint}");
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
