using AutoMapper;
using ProfileService.Application.Contracts.InstructorProfileInfoContracts;
using WebApi.Models.InstructorProfileInfoModels;

namespace WebApi.Mapping;

public class InstructorProfileInfoMappingsProfile : Profile
{
    public InstructorProfileInfoMappingsProfile()
    {
        CreateMap<InstructorProfileInfoModel, InstructorProfileInfoDto>();
        CreateMap<InstructorProfileInfoDto, InstructorProfileInfoModel>();
        CreateMap<CreatingInstructorProfileInfoModel, CreatingInstructorProfileInfoDto>();
        CreateMap<UpdatingInstructorProfileInfoModel, UpdatingInstructorProfileInfoDto>();
    }
}
