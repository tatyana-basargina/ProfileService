using ProfileService.Domain.Entities;

namespace ProfileService.Application.Contracts.ClientProfileInfoContracts;

public class CreatingClientProfileInfoDto : ProfileInfo, IEntity<Guid>
{
    public Guid OwnerProfileId { get; set; }
    public ProfileInfo? OwnerProfile { get; set; }
}