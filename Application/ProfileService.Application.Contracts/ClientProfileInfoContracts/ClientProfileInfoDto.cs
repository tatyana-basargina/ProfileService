using ProfileService.Domain.Entities.Enums;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Contracts.ClientProfileInfoContracts;

public class ClientProfileInfoDto : ProfileInfo, IEntity<Guid>
{
    public Guid OwnerProfileId { get; set; }
    public ProfileInfo? OwnerProfile { get; set; }
}