using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Domain.Entities.Enums;
using ProfileService.Infrastructure.EntityFramework;

namespace ProfileService.Infrastructure.Repositories.Implementations;

public class ProfileInfoRepository : Repository<ProfileInfo, Guid>, IProfileInfoRepository
{
    public ProfileInfoRepository(DatabaseContext context) : base(context)
    {
    }    

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Профиль. </returns>
    public override async Task<ProfileInfo> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        //await Task.Delay(TimeSpan.FromSeconds(20));
        var query = Context.Set<ProfileInfo>().AsQueryable();
        query = query
            .Where(l => l.Id == id && !l.IsDeleted);

        return await query.SingleOrDefaultAsync();
        //return await query.SingleOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Получить список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список профилей. </returns>
    public async Task<List<ProfileInfo>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll().Where(l => !l.IsDeleted);
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }

    /// <summary>
    /// Добавление профиля при изменении
    /// </summary>
    /// <param name="entity"> Сущность для изменения. </param>
    public async Task<ProfileInfo> UpdateAsync(ProfileInfo entity)
    {
        var profile = Get(entity.Id);
        profile.IsActive = false;
        profile.Status = ProfileStatuses.Changed;
        await SaveChangesAsync();

        entity.Id = Guid.NewGuid();
        entity.IsActive = true;
        entity.Status = ProfileStatuses.Created;
        return await AddAsync(entity);
    }
    
}
