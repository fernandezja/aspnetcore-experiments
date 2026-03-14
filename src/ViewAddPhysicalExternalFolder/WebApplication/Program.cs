using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.FileProviders;
using AppBuilder = Microsoft.AspNetCore.Builder.WebApplication;

var builder = AppBuilder.CreateBuilder(args);

//'MvcRazorRuntimeCompilationOptions' is obsolete:
//'Razor runtime compilation is obsolete and is not recommended for production scenarios.
//For production scenarios, use the default build time compilation.
//For development scenarios, use Hot Reload instead. For more information, visit https://aka.ms/aspnet/deprecate/003.'
builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
{
    options.FileProviders.Clear();
    options.FileProviders.Add(new PhysicalFileProvider(GetPathViewExternalFolder("ViewExternalFolder1")));
    options.FileProviders.Add(new PhysicalFileProvider(GetPathViewExternalFolder("ViewExternalFolder2")));
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static string GetPathViewExternalFolder(string directoryName)
{
    var path = AppContext.BaseDirectory;
    for (int i = 0; i < 5; i++)
        path = Directory.GetParent(path)?.FullName
            ?? throw new InvalidOperationException(
                $"Could not navigate up 5 directory levels from '{AppContext.BaseDirectory}'.");
    return Path.Combine(path, directoryName);
}
