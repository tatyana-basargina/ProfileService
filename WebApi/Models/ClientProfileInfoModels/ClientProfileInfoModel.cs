using WebApi.Models.ProfileInfoModels;
namespace WebApi.Models.ClientProfileInfoModels;

public class ClientProfileInfoModel : ProfileInfoModel
{
    public Guid? OwnerProfileInfoId { get; set; }
}
