using ProfileService.API.Models.FileAchievementModels;
using ProfileService.Domain.Entities;

namespace ProfileService.API.Models.AchievementModels;

public class CreatingAchievementModel
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Title { get; set; } = null!;
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }
    public Guid ProfileInfoId { get; set; }
    //public ProfileInfo ProfileInfo { get; set; } = null!;
    public IEnumerable<CreatingFileAchievementModel>? FilesAchievement { get; set; }
}
