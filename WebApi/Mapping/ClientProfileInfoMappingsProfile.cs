using AutoMapper;
using ProfileService.Application.Contracts.ClientProfileInfoContracts;
using WebApi.Models.ClientProfileInfoModels;

namespace WebApi.Mapping;

public class ClientProfileInfoMappingsProfile : Profile
{
    public ClientProfileInfoMappingsProfile()
    {
        CreateMap<ClientProfileInfoModel, ClientProfileInfoDto>();
        CreateMap<ClientProfileInfoDto, ClientProfileInfoModel>();
        CreateMap<CreatingClientProfileInfoModel, CreatingClientProfileInfoDto>();
        CreateMap<UpdatingClientProfileInfoModel, UpdatingClientProfileInfoDto>();
    }
}