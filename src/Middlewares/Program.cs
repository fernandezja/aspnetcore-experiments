var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

//app.UseResponseCaching();
//app.UseResponseCompression();
app.UseStaticFiles();

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
    Console.WriteLine("Middleware 2.End");
});

app.Map("/maptest1", HandleMapTest1);

app.MapWhen(context => context.Request.Query.ContainsKey("demo1"), 
                      HandleDemo1Request);

app.UseWhen(context => context.Request.Query.ContainsKey("demo2"),
            appBuilder => HandleDemo2Request(appBuilder));



app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Run();



static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}


static void HandleDemo1Request(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        var demoValue = context.Request.Query["demo1"];
        await context.Response.WriteAsync($"Demo1 value = {demoValue}");
    });
}

void HandleDemo2Request(IApplicationBuilder app)
{
    var logger = app.ApplicationServices.GetRequiredService<ILogger<Program>>();

    app.Use(async (context, next) =>
    {
        var demoValue = context.Request.Query["demo2"];
        logger.LogInformation("Demo2 value = {demo2}", demoValue);

        // Do work that doesn't write to the Response.
        await next();
        // Do other work that doesn't write to the Response.
    });
}