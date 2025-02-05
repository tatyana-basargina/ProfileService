using ProfileService.Domain.Entities;

namespace ProfileService.Application.Repositories.Abstractions;

public interface IFileAchievementRepository : IRepository<FileAchievement, int>
{
    /// <summary>
    /// Получить список .
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список . </returns>
    Task<List<FileAchievement>> GetPagedAsync(int page, int itemsPerPage);
}
