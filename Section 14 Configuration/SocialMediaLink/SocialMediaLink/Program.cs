using SocialMediaLink;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<SocialMediaLinkOptions>(builder.Configuration.GetSection("SocialMediaLinks"));

var enviornment = builder.Environment;

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
