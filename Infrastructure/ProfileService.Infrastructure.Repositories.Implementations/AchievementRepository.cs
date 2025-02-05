using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Infrastructure.EntityFramework;

namespace ProfileService.Infrastructure.Repositories.Implementations;

public class AchievementRepository : Repository<Achievement, int>, IAchievementRepository
{
    public AchievementRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Профиль. </returns>
    public override async Task<Achievement> GetAsync(int id, CancellationToken cancellationToken)
    {
        var query = Context.Set<Achievement>().AsQueryable();
        query = query
            .Where(l => l.Id == id);

        return await query.SingleOrDefaultAsync();
        //return await query.SingleOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Получить список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список профилей. </returns>
    public async Task<List<Achievement>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll();
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}