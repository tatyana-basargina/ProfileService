using ProfileService.Domain.Entities.Enums;

namespace WebApi.Models.ProfileInfoModels;
/// <summary>
/// Модель редактируемого профиля.
/// </summary>
public class UpdatingProfileInfoModel
{
    /// <summary>
    /// Дата обновления.
    /// </summary>
    public DateTime UpdatedDate { get; set; }
    /// <summary>
    /// Статус.
    /// </summary>
    public ProfileStatuses Status { get; set; }
    /// <summary>
    /// Активность профиля.
    /// </summary>
    public bool IsActive { get; set; }
    /// <summary>
    /// Профиль удален.
    /// </summary>
    public bool IsDeleted { get; set; }
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UpdatedUserId { get; set; }
    /// <summary>
    /// Id фото профиля.
    /// </summary>
    public Guid PhotoId { get; set; }
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