using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllersWithViews();

/*
builder.Services.Add(new ServiceDescriptor(
        typeof(ICitiesService),
        typeof(CitiesService),
        ServiceLifetime.Scoped
    ));
*/

//builder.Services.AddScoped<ICitiesService, CitiesService>();

builder.Host.ConfigureContainer<ContainerBuilder>(containerbuilder =>
{
    //containerbuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency();// add transient

    containerbuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope();// add scopped

    //containerbuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance();// add singleton
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
