using ProfileService.Domain.Entities;

namespace ProfileService.Application.Repositories.Abstractions;

public interface ITypeSportEquipmentRepository : IRepository<TypeSportEquipment, int>
{
    /// <summary>
    /// Получить список типов спортивного оборудования.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список типов спортивного оборудования. </returns>
    Task<List<TypeSportEquipment>> GetPagedAsync(int page, int itemsPerPage);
}