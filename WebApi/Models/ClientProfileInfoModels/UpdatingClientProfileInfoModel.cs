using ProfileService.Domain.Entities.Enums;
using WebApi.Models.ProfileInfoModels;

namespace WebApi.Models.ClientProfileInfoModels;

public class UpdatingClientProfileInfoModel: UpdatingProfileInfoModel
{
    public Guid ClientProfileInfoId { get; set; }
}