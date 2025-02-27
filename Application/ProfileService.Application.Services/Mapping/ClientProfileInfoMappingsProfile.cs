using AutoMapper;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services.Mapping;
/// <summary>
/// Профиль автомаппера для сущности профиля пользователя.
/// </summary>
public class ClientProfileInfoMappingsProfile : Profile
{
    public ClientProfileInfoMappingsProfile()
    {
        CreateMap<ClientProfileInfo, ClientProfileInfoDto>();
        CreateMap<ClientProfileInfoDto, ClientProfileInfo>()
            .ForMember(p => p.Achievements, map => map.Ignore())
            .ForMember(p => p.ProfileInfo, map => map.Ignore())
            .ForMember(p => p.OwnerProfileInfo, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipment, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipmentProfile, map => map.Ignore())
            .ForMember(p => p.VersionNumber, map => map.Ignore())
            .ForMember(p => p.IsCurrentVersion, map => map.Ignore())
            .ForMember(p => p.ProfileType, map => map.Ignore());

        CreateMap<CreatingClientProfileInfoDto, ClientProfileInfo>()
            .ForMember(p => p.Id, map => map.Ignore())
            .ForMember(p => p.UserId, map => map.Ignore())
            .ForMember(p => p.CreatedDate, map => map.Ignore())
            .ForMember(p => p.UpdatedDate, map => map.Ignore())
            .ForMember(p => p.Status, map => map.Ignore())
            .ForMember(p => p.IsActive, map => map.Ignore())
            .ForMember(p => p.IsDeleted, map => map.Ignore())
            .ForMember(p => p.UpdatedUserId, map => map.Ignore())
            .ForMember(p => p.Achievements, map => map.Ignore())
            .ForMember(p => p.ProfileInfo, map => map.Ignore())
            .ForMember(p => p.OwnerProfileInfo, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipment, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipmentProfile, map => map.Ignore())
            .ForMember(p => p.VersionNumber, map => map.Ignore())
            .ForMember(p => p.IsCurrentVersion, map => map.Ignore())
            .ForMember(p => p.ProfileType, map => map.Ignore());

        CreateMap<UpdatingClientProfileInfoDto, ClientProfileInfo>()
            .ForMember(p => p.Id, map => map.Ignore())
            .ForMember(p => p.UserId, map => map.Ignore())
            .ForMember(p => p.CreatedDate, map => map.Ignore())
            .ForMember(p => p.Achievements, map => map.Ignore())
            .ForMember(p => p.ProfileInfo, map => map.Ignore())
            .ForMember(p => p.OwnerProfileInfo, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipment, map => map.Ignore())
            .ForMember(p => p.TypeSportEquipmentProfile, map => map.Ignore())
            .ForMember(p => p.VersionNumber, map => map.Ignore())
            .ForMember(p => p.IsCurrentVersion, map => map.Ignore())
            .ForMember(p => p.ProfileType, map => map.Ignore());
    }
}

