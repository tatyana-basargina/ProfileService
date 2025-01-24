using ProfileService.Domain.Entities;

namespace ProfileService.Application.Repositories.Abstractions;

public interface IProfileInfoRepository : IRepository<ProfileInfo, Guid>
{
    /// <summary>
    /// Получить список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список профилей. </returns>
    Task<List<ProfileInfo>> GetPagedAsync(int page, int itemsPerPage);

    /// <summary>
    /// Добавление профиля при изменении
    /// </summary>
    /// <param name="entity"> Сущность для изменения. </param>
    Task<ProfileInfo> UpdateAsync(ProfileInfo entity);

}
