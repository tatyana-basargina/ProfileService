using AutoMapper;
using ProfileService.Application.Contracts.TypeSportEquipmentProfileInfoContracts;
using WebApi.Models.TypeSportEquipmentProfileInfoModels;

namespace WebApi.Mapping;

public class TypeSportEquipmentProfileInfoMappingsProfile : Profile
{
    public TypeSportEquipmentProfileInfoMappingsProfile()
    {
        CreateMap<TypeSportEquipmentProfileInfoModel, TypeSportEquipmentProfileInfoDto>();
        CreateMap<TypeSportEquipmentProfileInfoDto, TypeSportEquipmentProfileInfoModel>();
        //CreateMap<CreatingTypeSportEquipmentModel, CreatingTypeSportEquipmentDto>();
        //CreateMap<UpdatingTypeSportEquipmentModel, UpdatingTypeSportEquipmentDto>();
    }
}