using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Infrastructure.EntityFramework;

namespace ProfileService.Infrastructure.Repositories.Implementations;

public class PositionRepository: Repository<Position, int>, IPositionRepository
{
    public PositionRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Должность. </returns>
    public override async Task<Position> GetAsync(int id, CancellationToken cancellationToken)
    {
        //await Task.Delay(TimeSpan.FromSeconds(20));
        var query = Context.Set<Position>().AsQueryable();
        //query = query
        //    .Where(l => l.Id == id && !l.IsDeleted);

        return await query.SingleOrDefaultAsync();
        //return await query.SingleOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Получить список должностей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список должностей. </returns>
    public async Task<List<Position>> GetPagedAsync(int page, int itemsPerPage)
    {
        //var query = GetAll();//.Where(l => !l.IsDeleted);
        return await GetAll()
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}

