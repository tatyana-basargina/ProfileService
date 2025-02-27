using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Infrastructure.EntityFramework;

namespace ProfileService.Infrastructure.Repositories.Implementations;

public class InstructorProfileInfoRepository : Repository<InstructorProfileInfo, Guid>, IInstructorProfileInfoRepository
{
    public InstructorProfileInfoRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить профиль инструктора по Id.
    /// </summary>
    /// <param name="id"> Id профиля инструктора. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Профиль инструктора. </returns>
    public override async Task<InstructorProfileInfo?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await Context
            .Set<InstructorProfileInfo>()
            .OfType<InstructorProfileInfo>()
            .Where(i => !i.IsDeleted && i.IsCurrentVersion && i.Id == id)
            .SingleOrDefaultAsync(cancellationToken);
    }
    /// <summary>
    /// Получить профиль инструктора по Id пользователя.
    /// </summary>
    /// <param name="id"> Id пользователя. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> Профиль инструктора. </returns>
    public async Task<InstructorProfileInfo?> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await Context
            .Set<InstructorProfileInfo>()
            .OfType<InstructorProfileInfo>()
            .Where(i => !i.IsDeleted && i.IsCurrentVersion && i.UserId == userId && i.IsActive)
            .SingleOrDefaultAsync(cancellationToken);
    }

    /// <summary>
    /// Получить список профилей.
    /// </summary>
    /// <param name="page"> Номер страницы. </param>
    /// <param name="itemsPerPage"> Количество элементов на странице. </param>
    /// <returns> Список профилей. </returns>
    public async Task<List<InstructorProfileInfo>> GetPagedAsync(int page, int itemsPerPage)
    {
        var query = GetAll().OfType<InstructorProfileInfo>().Where(l => !l.IsDeleted);
        return await query
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToListAsync();
    }
}