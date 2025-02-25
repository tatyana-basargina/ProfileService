using ProfileService.Application.Contracts.FileAchievementContracts;

namespace ProfileService.Application.Abstractions;

public interface IFileAchievementServiceApp
{
    /// <summary>
    /// Получить .
    /// </summary>
    /// <param name="id"> Идентификатор. </param>
    /// <returns> ДТО . </returns>
    Task<IEnumerable<FileAchievementDto>> GetByAchievementIdAsync(int id);
    /// <summary>
    /// Создать .
    /// </summary>
    /// <param name="creatingFileAchievementDto"> ДТО создаваемого . </param>
    Task<int> CreateAsync(CreatingFileAchievementDto creatingFileAchievementDto);

    /// <summary>
    /// Удалить .
    /// </summary>
    /// <param name="id"> Идентификатор . </param>
    Task DeleteAsync(int id);
}
