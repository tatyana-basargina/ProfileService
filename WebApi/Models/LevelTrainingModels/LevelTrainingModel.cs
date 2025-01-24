namespace WebApi.Models.LevelTrainingModels;
/// <summary>
/// Уровень подготовки.
/// </summary>
public class LevelTrainingModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = null!;
}