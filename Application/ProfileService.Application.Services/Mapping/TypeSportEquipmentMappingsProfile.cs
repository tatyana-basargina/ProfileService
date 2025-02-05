using AutoMapper;
using ProfileService.Application.Contracts.TypeSportEquipmentContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services.Mapping;
/// <summary>
/// Профиль автомаппера для сущности типа спортивного оборудования.
/// </summary>
public class TypeSportEquipmentMappingsProfile: Profile
{
    public TypeSportEquipmentMappingsProfile()
    {
        CreateMap<TypeSportEquipment, TypeSportEquipmentDto>();
        CreateMap<TypeSportEquipmentDto, TypeSportEquipment>();
        CreateMap<CreatingTypeSportEquipmentDto, TypeSportEquipment>();
        CreateMap<UpdatingTypeSportEquipmentDto, TypeSportEquipment>();
    }
}