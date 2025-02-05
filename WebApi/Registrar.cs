using AutoMapper;
using ProfileService.Application.Abstractions;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Application.Services;
using ProfileService.Infrastructure.EntityFramework;
using ProfileService.Infrastructure.Repositories.Implementations;
using WebApi.Mapping;
using WebApi.Settings;
using ServicesMapping = ProfileService.Application.Services.Mapping;

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
            .AddTransient<IClientProfileInfoServiceApp, ClientProfileInfoServiceApp>()
            .AddTransient<IAchievementServiceApp, AchievementServiceApp>()
            .AddTransient<IFileAchievementServiceApp, FileAchievementServiceApp>();
        return serviceCollection;
    }

    private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IProfileInfoRepository, ProfileInfoRepository>()
            .AddTransient<IClientProfileInfoRepository, ClientProfileInfoRepository>()
            .AddTransient<IAchievementRepository, AchievementRepository>()
            .AddTransient<IFileAchievementRepository, FileAchievementRepository>();
        //.AddTransient<IInstructorProfileInfoRepository, InstructorProfileInfo>();
        //.AddTransient<IClientProfileInfoRepository, ClientProfileInfoRepository>();
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
            cfg.AddProfile<ProfileInfoMappingsProfile>();
            cfg.AddProfile<ServicesMapping.ProfileInfoMappingsProfile>();

            cfg.AddProfile<ClientProfileInfoMappingsProfile>();
            cfg.AddProfile<ServicesMapping.ClientProfileInfoMappingsProfile>();

            cfg.AddProfile<AchievementMappingsProfile>();
            cfg.AddProfile<ServicesMapping.AchievementMappingsProfile>();

            cfg.AddProfile<FileAchievementMappingsProfile>();
            cfg.AddProfile<ServicesMapping.FileAchievementMappingsProfile>();

            //cfg.AddProfile<TypeSportEquipmentProfileInfoMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.TypeSportEquipmentProfileInfoMappingsProfile>();
        });
        configuration.AssertConfigurationIsValid();
        return configuration;
    }
}
