var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.UseResponseCaching();
//app.UseResponseCompression();
//app.UseStaticFiles();

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 1.Start");
    await next.Invoke();
    Console.WriteLine("Middleware 1.End");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 2.Start");
    await next.Invoke();
    Console.WriteLine("Middleware 2.Endt");
});


app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Run();
