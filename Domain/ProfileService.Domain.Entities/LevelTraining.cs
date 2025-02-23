namespace ProfileService.Domain.Entities;

/// <summary>
/// Уровень подготовки.
/// </summary>
public class LevelTraining: IEntity<int>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;
    public IEnumerable<TypeSportEquipmentProfile>? TypeSportEquipmentProfile { get; set; }
}