using WebApi.Models.ProfileInfoModels;

namespace WebApi.Models.ClientProfileInfoModels;

public class UpdatingClientProfileInfoModel : UpdatingProfileInfoModel
{
    public Guid? OwnerProfileInfoId { get; set; }
}