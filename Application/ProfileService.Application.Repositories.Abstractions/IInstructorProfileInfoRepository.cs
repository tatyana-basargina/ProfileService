using ProfileService.Domain.Entities;

namespace ProfileService.Application.Repositories.Abstractions;

public interface IInstructorProfileInfoRepository : IRepository<InstructorProfileInfo, Guid>
{
    /// <summary>
    /// Получить список профилей инструктора.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список профилей инструктора. </returns>
    Task<List<InstructorProfileInfo>> GetPagedAsync(int page, int itemsPerPage);

}