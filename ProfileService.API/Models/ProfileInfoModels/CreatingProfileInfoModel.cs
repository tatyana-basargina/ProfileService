using ProfileService.Common.Enums;

namespace ProfileService.API.Models.ProfileInfoModels;
/// <summary>
/// Модель создаваемого профиля.
/// </summary>
public class CreatingProfileInfoModel
{
    /// <summary>
    /// Id фото профиля.
    /// </summary>
    public Guid? PhotoId { get; set; }
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string Surname { get; set; } = null!;
    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic { get; set; }
    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateTime BirthDate { get; set; }
    /// <summary>
    /// Пол.
    /// </summary>
    public Gender Gender { get; set; }
    /// <summary>
    /// Телефон.
    /// </summary>
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// Телеграм.
    /// </summary>
    public string? TelegramName { get; set; }
}