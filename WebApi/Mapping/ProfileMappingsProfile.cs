using AutoMapper;
using ProfileService.Application.Contracts;
using ProfileService.Models.Profile;

namespace WebApi.Mapping;

public class ProfileMappingsProfile: Profile
{
    public ProfileMappingsProfile()
    {
        CreateMap<ProfileDto, ProfileModel>();
        CreateMap<CreatingProfileModel, CreatingProfileDto>();
        //CreateMap<UpdatingProfileModel, UpdatingProfileDto>();
        //CreateMap<ProfileFilterModel, ProfileFilterDto>();
    }
}
