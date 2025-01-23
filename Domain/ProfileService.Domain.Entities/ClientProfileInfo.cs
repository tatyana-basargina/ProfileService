namespace ProfileService.Domain.Entities;

public class ClientProfileInfo : ProfileInfo, IEntity<Guid>
{
    public Guid OwnerProfileId { get; set; }
    public ProfileInfo? OwnerProfile { get; set; }
}