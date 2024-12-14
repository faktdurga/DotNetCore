using RoutingAssignment.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    CountriesClass countries= new CountriesClass();
    endpoints.MapGet("/countries", async context =>
    {
        var res = countries.GetCountries();        
        foreach(var item in res)
        {
            string countryid = item.Key.ToString();
            string countryname = item.Value.ToString();
            await context.Response.WriteAsync($"{countryid} . {countryname} \n");
        }        
    });

    endpoints.MapGet("/countries/{countryId:int:range(1,100)}", async context =>
    {
        var res = countries.GetCountries();
        string country = "";
        int countryid = Convert.ToInt32(context.Request.RouteValues["countryId"]);
        foreach (var item in res)
        {
            if(item.Key == countryid)
            {
                country = item.Value.ToString();
                break;
            }
        }

        if(!string.IsNullOrEmpty(country))
        { 
            await context.Response.WriteAsync($"{country}");
        }
        else
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("Country not found");
        }
    });
});


app.Run();
