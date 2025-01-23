using ProfileService.Application.Abstractions;
using WebApi.Settings;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Infrastructure.Repositories.Implementations;
using ProfileService.Application.Services;
using ProfileService.Infrastructure.EntityFramework;
using ProfileService.Application.Services.Mapping;
using AutoMapper;

namespace WebApi;

/// <summary>
/// Регистратор сервиса.
/// </summary>
public static class Registrar
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationSettings = configuration.Get<ApplicationSettings>();
        services.AddSingleton(applicationSettings)
                .AddSingleton((IConfigurationRoot)configuration)
                .InstallServices()
                .ConfigureContext(applicationSettings.ConnectionString)
                .InstallRepositories();
        return services;
    }

    private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IProfileInfoServiceApp, ProfileInfoServiceApp>()
            .AddTransient<IClientProfileInfoServiceApp, ClientProfileInfoServiceApp>();
        return serviceCollection;
    }

    private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IProfileInfoRepository, ProfileInfoRepository>()
            .AddTransient<IClientProfileInfoRepository, ClientProfileInfoRepository>();
            //.AddTransient<IUnitOfWork, UnitOfWork>();
        return serviceCollection;
    }

    public static IServiceCollection AddAutoMapper(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        return serviceCollection;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<Mapping.ProfileInfoMappingsProfile>();
            cfg.AddProfile<ProfileInfoMappingsProfile>();

            cfg.AddProfile<Mapping.ClientProfileInfoMappingsProfile>();
            cfg.AddProfile<ClientProfileInfoMappingsProfile>();
        });
        configuration.AssertConfigurationIsValid();
        return configuration;
    }
}
