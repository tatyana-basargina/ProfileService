using ProfileService.Domain.Entities;
using WebApi.Models.ProfileInfoModels;

namespace WebApi.Models.ClientProfileInfoModels;

public class CreatingClientProfileInfoModel : CreatingProfileInfoModel
{
    public Guid ClientProfileInfoId { get; set; }
}