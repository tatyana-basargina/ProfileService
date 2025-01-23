using AutoMapper;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;
using ProfileService.Application.Contracts.ProfileInfoContracts;
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
        //CreateMap<ClientProfileInfoDto, ClientProfileInfo>();
        CreateMap<CreatingClientProfileInfoDto, ClientProfileInfo>();
            //.ForMember(d => d.Id, map => map.Ignore())
            //.ForMember(d => d.UpdatedDate, map => map.Ignore())
            //.ForMember(d => d.UpdatedUserId, map => map.Ignore())
            //.ForMember(d => d.IsDeleted, map => map.Ignore())
            //.ForMember(d => d.OwnerProfile, map => map.Ignore());


        //CreateMap<UpdatingClientProfileInfoDto, ClientProfileInfo>()
        //        .ForMember(d => d.Id, map => map.Ignore())
        //        .ForMember(d => d.CreatedDate, map => map.Ignore())
        //        .ForMember(d => d.UserId, map => map.Ignore())
        //        .ForMember(d => d.OwnerProfile, map => map.Ignore())
        //        .ForMember(d => d.OwnerProfileId, map => map.Ignore());
    }
}

