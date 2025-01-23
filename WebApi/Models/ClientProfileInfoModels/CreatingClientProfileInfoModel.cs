using ProfileService.Domain.Entities;

namespace WebApi.Models.ClientProfileInfoModels;

public class CreatingClientProfileInfoModel : ProfileInfo, IEntity<Guid>
{
    public Guid OwnerProfileId { get; set; }
    public ProfileInfo? OwnerProfile { get; set; }
}