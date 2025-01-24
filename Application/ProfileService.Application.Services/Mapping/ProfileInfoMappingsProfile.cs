using AutoMapper;
using ProfileService.Application.Contracts.ProfileInfoContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Services.Mapping;

/// <summary>
/// Профиль автомаппера для сущности профиля.
/// </summary>
public class ProfileInfoMappingsProfile : Profile
{
    public ProfileInfoMappingsProfile()
    {
        CreateMap<ProfileInfo, ProfileInfoDto>();
        CreateMap<ProfileInfoDto, ProfileInfo>();
        CreateMap<CreatingProfileInfoDto, ProfileInfo>()
            //.ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.UpdatedDate, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore())
            .ForMember(d => d.UpdatedUserId, map => map.Ignore());
        CreateMap<UpdatingProfileInfoDto, ProfileInfo>()
                .ForMember(d => d.Id, map => map.Ignore())
                .ForMember(d => d.UserId, map => map.Ignore())
                .ForMember(d => d.CreatedDate, map => map.Ignore());
    }
}
