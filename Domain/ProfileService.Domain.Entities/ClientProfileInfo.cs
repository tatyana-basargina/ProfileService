namespace ProfileService.Domain.Entities;

public class ClientProfileInfo : ProfileInfo
{
    public ProfileInfo Profile { get; set; } = null!;
    public ProfileInfo? OwnerProfile { get; set; }
}