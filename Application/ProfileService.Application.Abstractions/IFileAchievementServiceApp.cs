using ProfileService.Application.Contracts.FileAchievementContracts;

namespace ProfileService.Application.Abstractions;

public interface IFileAchievementServiceApp
{
    
    Task<IEnumerable<FileAchievementDto>> GetByAchievementIdAsync(int id);
    
    Task<int> CreateAsync(int achievementId, CreatingFileAchievementDto creatingFileAchievementDto);
    
    Task DeleteAsync(int id);
}
