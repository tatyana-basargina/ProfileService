using WebApi.Models.ProfileInfoModels;

namespace WebApi.Models.ClientProfileInfoModels;

public class CreatingClientProfileInfoModel : CreatingProfileInfoModel
{
    public Guid? OwnerProfileInfoId { get; set; }
}