using BookSearchly.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BookSearchly.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplictionServices(this IServiceCollection services)
    {
        services.AddTransient<BookMapper>();

        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


        return services;
    }
}
