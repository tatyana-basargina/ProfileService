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
        ApplicationSettings? applicationSettings = configuration.Get<ApplicationSettings>();
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
            .AddTransient<IAchievementServiceApp, AchievementServiceApp>()
            //.AddTransient<IClientProfileInfoServiceApp, ClientProfileInfoServiceApp>()
            .AddTransient<IFileAchievementServiceApp, FileAchievementServiceApp>()
            //.AddTransient<IInstructorProfileInfoServiceApp, InstructorProfileInfoServiceApp>()
            //.AddTransient<ILevelTrainingServiceApp, LevelTrainingServiceApp>()
            //.AddTransient<IPositionServiceApp, PositionServiceApp>()
            //.AddTransient<IProfileInfoServiceApp, ProfileInfoServiceApp>()
            //.AddTransient<ITypeSportEquipmentProfileServiceApp, TypeSportEquipmentProfileServiceApp>()
            //.AddTransient<ITypeSportEquipmentServiceApp, TypeSportEquipmentServiceApp>()
            .AddTransient<IUnitOfWork, UnitOfWork> ()
            ;
        return serviceCollection;
    }

    private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IAchievementRepository, AchievementRepository>()
            //.AddTransient<IClientProfileInfoRepository, ClientProfileInfoRepository>()
            .AddTransient<IFileAchievementRepository, FileAchievementRepository>()
            //.AddTransient<IInstructorProfileInfoRepository, InstructorProfileInfoRepository>()
            //.AddTransient<ILevelTrainingRepository, LevelTrainingRepository>()
            //.AddTransient<IPositionRepository, PositionRepository>()
            //.AddTransient<IProfileInfoRepository, ProfileInfoRepository>()
            //.AddTransient<ITypeSportEquipmentProfileRepository, TypeSportEquipmentProfileRepository>()
            //.AddTransient<ITypeSportEquipmentRepository, TypeSportEquipmentRepository>()
            ;
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
            cfg.AddProfile<AchievementMappingsProfile>();
            cfg.AddProfile<ServicesMapping.AchievementMappingsProfile>();

            //cfg.AddProfile<ClientProfileInfoMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.ClientProfileInfoMappingsProfile>();
            
            cfg.AddProfile<FileAchievementMappingsProfile>();
            cfg.AddProfile<ServicesMapping.FileAchievementMappingsProfile>();

            //cfg.AddProfile<InstructorProfileInfoMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.InstructorProfileInfoMappingsProfile>();

            //cfg.AddProfile<LevelTrainingMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.LevelTrainingMappingsProfile>();

            //cfg.AddProfile<PositionMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.PositionMappingsProfile>();

            //cfg.AddProfile<ProfileInfoMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.ProfileInfoMappingsProfile>();

            //cfg.AddProfile<TypeSportEquipmentProfileMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.TypeSportEquipmentProfileMappingsProfile>();

            //cfg.AddProfile<TypeSportEquipmentMappingsProfile>();
            //cfg.AddProfile<ServicesMapping.TypeSportEquipmentMappingsProfile>();
        });
        configuration.AssertConfigurationIsValid();
        return configuration;
    }
}
