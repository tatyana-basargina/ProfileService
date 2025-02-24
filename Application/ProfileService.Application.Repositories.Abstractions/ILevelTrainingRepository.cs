using ProfileService.Domain.Entities;

namespace ProfileService.Application.Repositories.Abstractions;

public interface ILevelTrainingRepository : IRepository<LevelTraining, int>
{
    /// <summary>
    /// Получить список уровней подготовки.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список уровней подготовки. </returns>
    Task<List<LevelTraining>> GetPagedAsync(int page, int itemsPerPage);
}