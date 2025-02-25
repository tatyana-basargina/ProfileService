using AutoMapper;
using ProfileService.Application.Contracts.InstructorProfileInfoContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services.Mapping;

public class InstructorProfileInfoMappingsProfile : Profile
{
    public InstructorProfileInfoMappingsProfile()
    {
        CreateMap<InstructorProfileInfo, InstructorProfileInfoDto>();
        CreateMap<InstructorProfileInfoDto, InstructorProfileInfo>()
            .ForMember(p => p.Achievements, map => map.Ignore())
            .ForMember(p => p.OwnerProfileInfo, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipment, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipmentProfile, map => map.Ignore());

        CreateMap<CreatingInstructorProfileInfoDto, InstructorProfileInfo>()
            .ForMember(p => p.Id, map => map.Ignore())
            .ForMember(p => p.UserId, map => map.Ignore())
            .ForMember(p => p.CreatedDate, map => map.Ignore())
            .ForMember(p => p.UpdatedDate, map => map.Ignore())
            .ForMember(p => p.Status, map => map.Ignore())
            .ForMember(p => p.IsActive, map => map.Ignore())
            .ForMember(p => p.IsDeleted, map => map.Ignore())
            .ForMember(p => p.UpdatedUserId, map => map.Ignore())
            .ForMember(p => p.Achievements, map => map.Ignore())
            .ForMember(p => p.OwnerProfileInfo, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipment, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipmentProfile, map => map.Ignore())
            .ForMember(p => p.Position, map => map.Ignore());

        CreateMap<UpdatingInstructorProfileInfoDto, InstructorProfileInfo>()
            .ForMember(p => p.Id, map => map.Ignore())
            .ForMember(p => p.UserId, map => map.Ignore())
            .ForMember(p => p.CreatedDate, map => map.Ignore())
            .ForMember(p => p.Achievements, map => map.Ignore())
            .ForMember(p => p.OwnerProfileInfo, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipment, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipmentProfile, map => map.Ignore())
            .ForMember(p => p.Position, map => map.Ignore());
    }
}