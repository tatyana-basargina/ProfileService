using AutoMapper;
using ProfileService.Application.Contracts.PositionContracts;
using WebApi.Models.PositionModels;

namespace WebApi.Mapping;

public class PositionMappingsProfile: Profile
{
    public PositionMappingsProfile()
    {
        CreateMap<PositionModel, PositionDto>();
        CreateMap<PositionDto, PositionModel>();
        CreateMap<CreatingPositionModel, CreatingPositionDto>();
        CreateMap<UpdatingPositionModel, UpdatingPositionDto>();
    }
}
