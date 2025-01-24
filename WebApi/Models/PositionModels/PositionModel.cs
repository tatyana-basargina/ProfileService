namespace WebApi.Models.PositionModels;
/// <summary>
/// Должность.
/// </summary>
public class PositionModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; set; } = null!;
}