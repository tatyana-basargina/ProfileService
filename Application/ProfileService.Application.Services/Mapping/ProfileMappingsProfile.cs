using AutoMapper;
using ProfileEntity = ProfileService.Domain.Entities.Profile;
using ProfileService.Application.Contracts;
using ProfileService.Domain.Entities.Enums;

namespace ProfileService.Application.Services.Mapping;

/// <summary>
/// Профиль автомаппера для сущности профиля.
/// </summary>
public class ProfileMappingsProfile : Profile
{
    public ProfileMappingsProfile()
    {
        CreateMap<ProfileEntity, ProfileDto>();

        CreateMap<CreatingProfileDto, ProfileEntity>()
            .ForMember(d => d.Id, map => map.Ignore())
            //.ForMember(d => d.CreatedDate, map => map.Ignore())
            //.ForMember(d => d.Status, map => map.Ignore())
            //.ForMember(d => d.IsActive, map => map.Ignore())
            //.ForMember(d => d.PhotoId, map => map.Ignore())
            //.ForMember(d => d.Surname, map => map.Ignore())
            .ForMember(d => d.Name, map => map.Ignore());
        //.ForMember(d => d.Patronymic, map => map.Ignore())
        //.ForMember(d => d.BirthDate, map => map.Ignore())
        //.ForMember(d => d.Gender, map => map.Ignore())
        //.ForMember(d => d.PhoneNumber, map => map.Ignore())
        //.ForMember(d => d.TelegramName, map => map.Ignore());

        CreateMap<UpdatingProfileDto, ProfileEntity>()
            .ForMember(d => d.Id, map => map.Ignore())
            .ForMember(d => d.UpdatedDate, map => map.Ignore())
            //.ForMember(d => d.Status, map => map.Ignore())
            //.ForMember(d => d.IsActive, map => map.Ignore())
            .ForMember(d => d.IsDeleted, map => map.Ignore())
            //.ForMember(d => d.UpdatedUserId, map => map.Ignore())
            //.ForMember(d => d.PhotoId, map => map.Ignore())
            //.ForMember(d => d.Surname, map => map.Ignore())
            .ForMember(d => d.Name, map => map.Ignore());
            //.ForMember(d => d.Patronymic, map => map.Ignore())
            //.ForMember(d => d.BirthDate, map => map.Ignore())
            //.ForMember(d => d.Gender, map => map.Ignore())
            //.ForMember(d => d.PhoneNumber, map => map.Ignore())
            //.ForMember(d => d.TelegramName, map => map.Ignore());
    }
}
