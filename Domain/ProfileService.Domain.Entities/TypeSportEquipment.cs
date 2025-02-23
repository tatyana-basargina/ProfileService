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
    public IEnumerable<ProfileInfo>? ProfileInfo { get; set; }
    public IEnumerable<TypeSportEquipmentProfile>? TypeSportEquipmentProfile { get; set; }
}