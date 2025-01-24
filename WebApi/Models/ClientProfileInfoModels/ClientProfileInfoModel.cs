using ProfileService.Domain.Entities;
using WebApi.Models.ProfileInfoModels;
namespace WebApi.Models.ClientProfileInfoModels;

public class ClientProfileInfoModel : ProfileInfoModel
{
    public Guid ClientProfileInfoId { get; set; }
}
