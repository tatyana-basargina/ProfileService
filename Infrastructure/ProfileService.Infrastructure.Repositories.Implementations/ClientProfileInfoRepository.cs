using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Infrastructure.EntityFramework;


namespace ProfileService.Infrastructure.Repositories.Implementations;

public class ClientProfileInfoRepository : Repository<ClientProfileInfo, Guid>, IClientProfileInfoRepository
{
    public ClientProfileInfoRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Профиль. </returns>
    public override async Task<ClientProfileInfo> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        //await Task.Delay(TimeSpan.FromSeconds(20));
        var query = Context.Set<ClientProfileInfo>().AsQueryable();
        query = query
            .Where(l => l.ClientProfileInfoId == id && !l.IsDeleted);

        return await query.SingleOrDefaultAsync();
        //return await query.SingleOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Получить список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список профилей. </returns>
    public async Task<List<ClientProfileInfo>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll().Where(l => !l.IsDeleted);
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}