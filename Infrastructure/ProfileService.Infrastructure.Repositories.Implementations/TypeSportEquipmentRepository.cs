using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Infrastructure.EntityFramework;

namespace ProfileService.Infrastructure.Repositories.Implementations;

public class TypeSportEquipmentRepository : Repository<TypeSportEquipment, int>, ITypeSportEquipmentRepository
{
    public TypeSportEquipmentRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Тип спортивного оборудования. </returns>
    public override async Task<TypeSportEquipment> GetAsync(int id, CancellationToken cancellationToken)
    {
        //await Task.Delay(TimeSpan.FromSeconds(20));
        var query = Context.Set<TypeSportEquipment>().AsQueryable();
        //query = query
        //    .Where(l => l.Id == id && !l.IsDeleted);

        return await query.SingleOrDefaultAsync();
        //return await query.SingleOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Получить список типов спортивного оборудования.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список типов спортивного оборудования. </returns>
    public async Task<List<TypeSportEquipment>> GetPagedAsync(int page, int itemsPerPage)
    {
        //var query = GetAll();//.Where(l => !l.IsDeleted);
        return await GetAll()
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}
