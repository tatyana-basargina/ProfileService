using AutoMapper;
using ProfileService.Application.Contracts.LevelTrainingContracts;
using WebApi.Models.LevelTrainingModels;

namespace WebApi.Mapping;

public class LevelTrainingMappingsProfile: Profile
{
    public LevelTrainingMappingsProfile()
    {
        CreateMap<LevelTrainingModel, LevelTrainingDto>();
        CreateMap<LevelTrainingDto, LevelTrainingModel>();
        CreateMap<CreatingLevelTrainingModel, CreatingLevelTrainingDto>();
        CreateMap<UpdatingLevelTrainingModel, UpdatingLevelTrainingDto>();
    }
}
