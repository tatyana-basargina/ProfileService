using ProfileService.Common.Enums;

namespace ProfileService.Application.Contracts.ProfileInfoContracts;

/// <summary>
/// ДТО создаваемого профиля.
/// </summary>
public class CreatingProfileInfoDto
{
    /// <summary>
    /// Тип профиля.
    /// </summary>
    public ProfileType ProfileType { get; set; }
    /// <summary>
    /// Id фото профиля.
    /// </summary>
    public Guid? PhotoId { get; set; }
    /// <summary>
    /// Фамилия.
    /// </summary>
    public string? Surname { get; set; }
    /// <summary>
    /// Имя.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// Отчество.
    /// </summary>
    public string? Patronymic { get; set; }
    /// <summary>
    /// Дата рождения.
    /// </summary>
    public DateTime? BirthDate { get; set; }
    /// <summary>
    /// Пол.
    /// </summary>
    public Gender? Gender { get; set; }
    /// <summary>
    /// Телефон.
    /// </summary>
    public string? PhoneNumber { get; set; }
    /// <summary>
    /// Телеграм.
    /// </summary>
    public string? TelegramName { get; set; }
}