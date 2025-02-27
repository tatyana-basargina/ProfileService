using ProfileService.Common.Enums;

namespace ProfileService.Domain.Entities;

/// <summary>
/// Профиль.
/// </summary>
public class ProfileInfo : IEntity<Guid>
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    /// <summary>
    /// Тип профиля.
    /// </summary>
    public string ProfileType { get; set; } = null!;
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    /// <summary>
    /// Дата обновления.
    /// </summary>
    public DateTime? UpdatedDate { get; set; }
    /// <summary>
    /// Статус.
    /// </summary>
    public ProfileStatuses Status { get; set; }
    /// <summary>
    /// Активность профиля.
    /// </summary>
    public bool IsActive { get; set; } = true;
    /// <summary>
    /// Профиль удален.
    /// </summary>
    public bool IsDeleted { get; set; } = false;
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid? UpdatedUserId { get; set; }
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

    public virtual IEnumerable<Achievement>? Achievements { get; set; }

    public virtual ClientProfileInfo? OwnerProfileInfo { get; set; }

    /// <summary>
    /// Тип спортивного оборудования.
    /// </summary>
    public virtual IEnumerable<TypeSportEquipment>? TypeSportEquipment { get; set; }
    public virtual IEnumerable<TypeSportEquipmentProfile>? TypeSportEquipmentProfile { get; set; }

    // Поля для версионирования (только для инструкторов)
    public int VersionNumber { get; set; } = 1;
    public bool IsCurrentVersion { get; set; } = true;
}