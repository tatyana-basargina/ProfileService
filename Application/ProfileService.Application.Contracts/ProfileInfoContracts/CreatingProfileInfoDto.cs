using ProfileService.Common.Enums;

namespace ProfileService.Application.Contracts.ProfileInfoContracts;

/// <summary>
/// ДТО создаваемого профиля.
/// </summary>
public class CreatingProfileInfoDto
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    /// <summary>
    /// Статус.
    /// </summary>
    public ProfileStatuses Status { get; set; }
    /// <summary>
    /// Активность профиля.
    /// </summary>
    public bool IsActive { get; set; } = true;
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