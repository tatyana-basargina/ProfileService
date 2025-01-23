using AutoMapper;
using ProfileService.Domain.Entities;
using ProfileService.Application.Contracts;
using ProfileService.Domain.Entities.Enums;

namespace ProfileService.Application.Services.Mapping;

/// <summary>
/// Профиль автомаппера для сущности профиля.
/// </summary>
public class ProfileInfoMappingsProfile : Profile
{
    public ProfileInfoMappingsProfile()
    {
        CreateMap<ProfileInfo, ProfileDto>();
        CreateMap<ProfileDto, ProfileInfo>();
        CreateMap<CreatingProfileDto, ProfileInfo>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.UpdatedDate, map => map.Ignore())
            .ForMember(d => d.UpdatedUserId, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore());


        //.ForMember(d => d.CreatedDate, map => map.Ignore())
        //.ForMember(d => d.Status, map => map.Ignore())
        //.ForMember(d => d.IsActive, map => map.Ignore())
        //.ForMember(d => d.PhotoId, map => map.Ignore())
        //.ForMember(d => d.Surname, map => map.Ignore())
        //.ForMember(d => d.IsDeleted, map => map.Ignore());
        //.ForMember(d => d.Name, map => map.Ignore());
        //.ForMember(d => d.Patronymic, map => map.Ignore())
        //.ForMember(d => d.BirthDate, map => map.Ignore())
        //.ForMember(d => d.Gender, map => map.Ignore())
        //.ForMember(d => d.PhoneNumber, map => map.Ignore())
        //.ForMember(d => d.TelegramName, map => map.Ignore());

        CreateMap<UpdatingProfileDto, ProfileInfo>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.CreatedDate, map => map.Ignore())
            .ForMember(d => d.UserId, map => map.Ignore());


        //.ForMember(d => d.Status, map => map.Ignore())
        //.ForMember(d => d.IsActive, map => map.Ignore())
        //.ForMember(d => d.IsDeleted, map => map.Ignore());
        //.ForMember(d => d.UpdatedUserId, map => map.Ignore())
        //.ForMember(d => d.PhotoId, map => map.Ignore())
        //.ForMember(d => d.Surname, map => map.Ignore())
        //.ForMember(d => d.Name, map => map.Ignore());
        //.ForMember(d => d.Patronymic, map => map.Ignore())
        //.ForMember(d => d.BirthDate, map => map.Ignore())
        //.ForMember(d => d.Gender, map => map.Ignore())
        //.ForMember(d => d.PhoneNumber, map => map.Ignore())
        //.ForMember(d => d.TelegramName, map => map.Ignore());
    }
}
