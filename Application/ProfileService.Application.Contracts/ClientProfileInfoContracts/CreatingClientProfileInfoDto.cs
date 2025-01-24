using ProfileService.Application.Contracts.ProfileInfoContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Contracts.ClientProfileInfoContracts;

public class CreatingClientProfileInfoDto : CreatingProfileInfoDto
{
    public Guid ClientProfileInfoId { get; set; }
}