using MyFirstApp;

var builder = WebApplication.CreateBuilder(args);

//register custom middleware
builder.Services.AddTransient<MyCustomMiddleware>();

var app = builder.Build();




app.Use(async (HttpContext context, RequestDelegate next) => {
    await context.Response.WriteAsync("| Hello From Use request delegate |\n");
    await next(context);
});

//custom middle ware by calling app.usemiddleware
//app.UseMiddleware<MyCustomMiddleware>();

//custome middleware by creating extension method
app.UseMyCustomMiddleware();

app.UseConvenstionalMiddlware();

app.Run(async (HttpContext context) =>{
    await context.Response.WriteAsync("| Hello From Run request delegate |\n");
});




app.Run();
