using AutoMapper;
using ProfileService.Application.Contracts.LevelTrainingContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services.Mapping;
/// <summary>
/// Профиль автомаппера для сущности уровня подготовки.
/// </summary>
public class LevelTrainingMappingsProfile: Profile
{
    public LevelTrainingMappingsProfile()
    {
        CreateMap<LevelTraining, LevelTrainingDto>();
        CreateMap<LevelTrainingDto, LevelTraining>();
        CreateMap<CreatingLevelTrainingDto, LevelTraining>();
        CreateMap<UpdatingLevelTrainingDto, LevelTraining>();
    }
}
