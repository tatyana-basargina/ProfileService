using AutoMapper;
using ProfileService.API.Models.ProfileInfoModels;
using ProfileService.Application.Contracts.ProfileInfoContracts;

namespace ProfileService.API.Mapping;

public class ProfileInfoMappingsProfile : Profile
{
    public ProfileInfoMappingsProfile()
    {
        CreateMap<ProfileInfoModel, ProfileInfoDto>();
        CreateMap<ProfileInfoDto, ProfileInfoModel>();
        CreateMap<CreatingProfileInfoModel, CreatingProfileInfoDto>();
        CreateMap<UpdatingProfileInfoModel, UpdatingProfileInfoDto>();
        //CreateMap<ProfileInfoFilterModel, ProfileFilterInfoDto>();
    }
}
