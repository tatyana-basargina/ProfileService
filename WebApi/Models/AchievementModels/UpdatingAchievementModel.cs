using ProfileService.Domain.Entities;
using WebApi.Models.FileAchievementModels;

namespace WebApi.Models.AchievementModels;

public class UpdatingAchievementModel
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }

    //public ProfileInfo ProfileInfo { get; set; } = null!;
    public List<UpdatingFileAchievementModel>? FilesAchievement { get; set; } = new();
}
