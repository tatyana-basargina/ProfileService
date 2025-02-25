using ProfileService.Domain.Entities;

namespace WebApi.Models.TypeSportEquipmentProfileInfoModels;

public class TypeSportEquipmentProfileInfoModel
{
    public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public virtual ProfileInfo ProfileInfo { get; set; } = null!;

    public int? TypeSportEquipmentId { get; set; }
    public virtual TypeSportEquipment? TypeSportEquipment { get; set; }
    public int? LevelTrainingId { get; set; }
    public virtual LevelTraining? LevelTraining { get; set; }
}
