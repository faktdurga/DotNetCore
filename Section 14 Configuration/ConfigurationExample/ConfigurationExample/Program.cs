using ConfigurationExample;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherAPIOption>(builder.Configuration.GetSection("weatherapi"));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

/*
app.UseEndpoints(endpoints => {
    endpoints.Map("/config", async context =>
    {
        //await context.Response.WriteAsync(app.Configuration["MyKey"]);

        await context.Response.WriteAsync(app.Configuration.GetValue<string>("MyKey"));      

        await context.Response.WriteAsync(app.Configuration.GetValue<int>("x", 10) + "\n");
    });
});
*/
app.MapControllers();

app.Run();
