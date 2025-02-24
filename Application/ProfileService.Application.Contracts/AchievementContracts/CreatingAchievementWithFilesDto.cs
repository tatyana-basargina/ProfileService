using ProfileService.Application.Contracts.FileAchievementContracts;
using ProfileService.Domain.Entities;

namespace ProfileService.Application.Contracts.AchievementContracts;

public class CreatingAchievementWithFilesDto
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
    public IEnumerable<CreatingFileAchievementDto>? FilesAchievement { get; set; }
}
