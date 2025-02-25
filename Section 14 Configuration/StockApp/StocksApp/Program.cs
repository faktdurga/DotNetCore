using StocksApp;
using StocksApp.Services;

var builder = WebApplication.CreateBuilder(args);


//Services

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddScoped<MyService>();

var app = builder.Build();


app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
