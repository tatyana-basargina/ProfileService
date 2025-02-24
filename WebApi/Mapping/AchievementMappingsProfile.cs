using AutoMapper;
using ProfileService.Application.Contracts.AchievementContracts;
using WebApi.Models.AchievementModels;

namespace WebApi.Mapping;

public class AchievementMappingsProfile : Profile
{
    public AchievementMappingsProfile()
    {
        CreateMap<AchievementModel, AchievementDto>();
        CreateMap<AchievementDto, AchievementModel>();
        CreateMap<CreatingAchievementModel, CreatingAchievementWithFilesDto>();
        CreateMap<UpdatingAchievementModel, UpdatingAchievementDto>();
    }
}
