using ProfileService.Domain.Entities;
using WebApi.Models.FileAchievementModels;

namespace WebApi.Models.AchievementModels;

public class AchievementModel
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Идентификатор профиля.
    /// </summary>
    public Guid ProfileInfoId { get; set; }
    //public ProfileInfo ProfileInfo { get; set; } = null!;
    public List<FileAchievementModel>? FilesAchievement { get; set; } = new();
}
