using AutoMapper;
using ProfileService.Application.Contracts;
using ProfileService.Models.Profile;

namespace WebApi.Mapping;

public class ProfileInfoMappingsProfile: Profile
{
    public ProfileInfoMappingsProfile()
    {
        CreateMap<ProfileModel, ProfileDto>();
        CreateMap<ProfileDto, ProfileModel>();
        CreateMap<CreatingProfileModel, CreatingProfileDto>();
        CreateMap<UpdatingProfileModel, UpdatingProfileDto>();
        //CreateMap<ProfileFilterModel, ProfileFilterDto>();
    }
}
