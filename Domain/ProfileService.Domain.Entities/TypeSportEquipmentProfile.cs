namespace ProfileService.Domain.Entities;

public class TypeSportEquipmentProfile: IEntity<int>
{
    public int Id { get; set; }
    public ProfileInfo Profile { get; set; } = null!;
    public TypeSportEquipment TypeSportEquipment { get; set; } = null!;
    public LevelTraining? LevelTraining { get; set; }
}