using AutoMapper;
using ProfileService.Application.Contracts.TypeSportEquipmentProfileInfoContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services.Mapping;

public class TypeSportEquipmentProfileInfoMappingsProfile : Profile
{
    public TypeSportEquipmentProfileInfoMappingsProfile()
    {
        CreateMap<TypeSportEquipmentProfile, TypeSportEquipmentProfileInfoDto>();
        CreateMap<TypeSportEquipmentProfileInfoDto, TypeSportEquipmentProfile>();
    }
}