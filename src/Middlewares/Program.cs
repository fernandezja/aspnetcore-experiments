var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 1.Start");
    await next(context);
    Console.WriteLine("Middleware 1.End");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Middleware 2.Start");
    await next(context);
    Console.WriteLine("Middleware 2.End");
});

app.Map("/maptest1", HandleMapTest1);

app.MapWhen(
    context => context.Request.Query.ContainsKey("demo1"),
    HandleDemo1Request);

app.UseWhen(
    context => context.Request.Query.ContainsKey("demo2"),
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
        var demoValue = context.Request.Query["demo1"].ToString();
        await context.Response.WriteAsync($"Demo1 value = {demoValue}");
    });
}

void HandleDemo2Request(IApplicationBuilder app)
{
    var logger = app.ApplicationServices.GetRequiredService<ILogger<Program>>();

    app.Use(async (context, next) =>
    {
        var demoValue = context.Request.Query["demo2"].ToString();
        logger.LogInformation("Demo2 value = {Demo2}", demoValue);

        await next(context);
    });
}