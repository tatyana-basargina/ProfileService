using AutoMapper;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;
using ProfileService.Application.Contracts.ProfileInfoContracts;
using WebApi.Models.ClientProfileInfoModels;
using WebApi.Models.ProfileInfoModels;

namespace WebApi.Mapping;

public class ClientProfileInfoMappingsProfile : Profile
{
    public ClientProfileInfoMappingsProfile()
    {
        CreateMap<ClientProfileInfoModel, ClientProfileInfoDto>();
        CreateMap<ClientProfileInfoDto, ClientProfileInfoModel>();
        CreateMap<CreatingClientProfileInfoModel, CreatingClientProfileInfoDto>();
        //CreateMap<UpdatingProfileModel, UpdatingProfileDto>();
        //CreateMap<ProfileFilterModel, ProfileFilterDto>();
    }
}
