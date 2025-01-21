namespace ProfileService.Domain.Entities;

public class ClientProfile : Profile
{
    public Profile Profile { get; set; } = null!;
    public Profile? OwnerProfile { get; set; }
}