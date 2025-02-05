using AutoMapper;
using ProfileService.Application.Contracts.TypeSportEquipmentContracts;
using WebApi.Models.TypeSportEquipmentModels;

namespace WebApi.Mapping;

public class TypeSportEquipmentMappingsProfile: Profile
{
    public TypeSportEquipmentMappingsProfile()
    {
        CreateMap<TypeSportEquipmentModel, TypeSportEquipmentDto>();
        CreateMap<TypeSportEquipmentDto, TypeSportEquipmentModel>();
        CreateMap<CreatingTypeSportEquipmentModel, CreatingTypeSportEquipmentDto>();
        CreateMap<UpdatingTypeSportEquipmentModel, UpdatingTypeSportEquipmentDto>();
    }
}
