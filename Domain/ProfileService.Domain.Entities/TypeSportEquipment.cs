namespace ProfileService.Domain.Entities;

/// <summary>
/// Тип спортивного оборудования.
/// </summary>
public class TypeSportEquipment: IEntity<int>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;
    public List<ProfileInfo>? ProfileInfo { get; set; } = new();
    public List<TypeSportEquipmentProfile>? TypeSportEquipmentProfile { get; set; } = new();
}