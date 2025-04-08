namespace ProfileService.Domain.Entities;

public class TypeSportEquipmentProfile: IEntity<int>
{
    public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public virtual ProfileInfo ProfileInfo { get; set; } = null!;
    public int? TypeSportEquipmentId { get; set; }
    public virtual TypeSportEquipment? TypeSportEquipment { get; set; }
    public int? LevelTrainingId { get; set; }
    public virtual LevelTraining? LevelTraining { get; set; }
}