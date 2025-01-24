using AutoMapper;
using ProfileService.Application.Contracts.ProfileInfoContracts;
using WebApi.Models.ProfileInfoModels;

namespace WebApi.Mapping;

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
