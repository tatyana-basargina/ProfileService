using ProfileService.Domain.Entities;

namespace ProfileService.Application.Contracts.TypeSportEquipmentProfileInfoContracts;

public class TypeSportEquipmentProfileInfoDto
{
    public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public virtual ProfileInfo ProfileInfo { get; set; } = null!;

    public int? TypeSportEquipmentId { get; set; }
    public virtual TypeSportEquipment? TypeSportEquipment { get; set; }
    public int? LevelTrainingId { get; set; }
    public virtual LevelTraining? LevelTraining { get; set; }
}
