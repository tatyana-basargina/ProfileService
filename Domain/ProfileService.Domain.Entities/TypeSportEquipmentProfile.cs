namespace ProfileService.Domain.Entities;

public class TypeSportEquipmentProfile: IEntity<int>
{
    public int Id { get; set; }
    public Guid ProfileId { get; set; }
    public ProfileInfo ProfileInfo { get; set; } = null!;

    public int? TypeSportEquipmentId { get; set; }
    public TypeSportEquipment? TypeSportEquipment { get; set; }
    public int? LevelTrainingId { get; set; }
    public LevelTraining? LevelTraining { get; set; }
}