using ProfileService.Application.Contracts.ProfileInfoContracts;

namespace ProfileService.Application.Contracts.ClientProfileInfoContracts;

public class UpdatingClientProfileInfoDto : UpdatingProfileInfoDto
{
    public Guid ClientProfileInfoId { get; set; }
}