using AutoMapper;
using ProfileService.Application.Contracts.FileAchievementContracts;
using WebApi.Models.FileAchievementModels;

namespace WebApi.Mapping;

public class FileAchievementMappingsProfile : Profile
{
    public FileAchievementMappingsProfile()
    {
        CreateMap<FileAchievementModel, FileAchievementDto>();
        CreateMap<FileAchievementDto, FileAchievementModel>();
        CreateMap<CreatingFileAchievementModel, CreatingFileAchievementDto>();
    }    
}
