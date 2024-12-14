using RoutingExample.CustomConstraint;

var builder = WebApplication.CreateBuilder(args);

//register custom constraints

builder.Services.AddRouting(options =>{
    options.ConstraintMap.Add("months", typeof(MonthsCustomConstraints));
});


var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    //add end points

    endpoints.Map("file/{filename}.{extension}", async context =>
    {
        await context.Response.WriteAsync("In Files");
    });

    endpoints.Map("employee/profile/{employeename:minlength(3)=admin}", async context =>
    {
        string? employeename = Convert.ToString(context.Request.RouteValues["employeename"]);

        await context.Response.WriteAsync($"Employee name is {employeename}");
    });


    //datetime contraint
    endpoints.Map("daily/digestreport/{reportdate:datetime}", async context =>
    {
        DateTime dt = Convert.ToDateTime(context.Request.RouteValues["reportdate"]);
        await context.Response.WriteAsync($"Report date is {dt.ToShortDateString()}");
    });

    //regular expression

    /*
    endpoints.Map("sales-report/2023/{year:int:min(1900)}/{month:regex(^(apr|jul|oct|jan)$)}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Year {year} and month is {month}");

    });
    */

    endpoints.Map("sales-report/2023/{year:int:min(1900)}/{month:months}", async context =>
    {
        int year = Convert.ToInt32(context.Request.RouteValues["year"]);
        string? month = Convert.ToString(context.Request.RouteValues["month"]);
        await context.Response.WriteAsync($"Year {year} and month is {month}");

    });
});

app.Run();
