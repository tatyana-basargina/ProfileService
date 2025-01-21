namespace ProfileService.Domain.Entities;

public class TypeSportEquipment: IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}