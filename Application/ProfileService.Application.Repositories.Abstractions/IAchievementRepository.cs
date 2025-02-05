using ProfileService.Domain.Entities;

namespace ProfileService.Application.Repositories.Abstractions;

public interface IAchievementRepository : IRepository<Achievement, int>
{
    /// <summary>
    /// Получить список достижений.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список достижений. </returns>
    Task<List<Achievement>> GetPagedAsync(int page, int itemsPerPage);

}