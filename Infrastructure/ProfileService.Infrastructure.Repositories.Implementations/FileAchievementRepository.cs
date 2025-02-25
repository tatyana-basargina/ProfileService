using Microsoft.EntityFrameworkCore;
using ProfileService.Application.Repositories.Abstractions;
using ProfileService.Domain.Entities;
using ProfileService.Infrastructure.EntityFramework;

namespace ProfileService.Infrastructure.Repositories.Implementations;

public class FileAchievementRepository : Repository<FileAchievement, int>, IFileAchievementRepository
{
    public FileAchievementRepository(DatabaseContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id"> Id сущности. </param>
    /// <param name="cancellationToken"> Токен отмены </param>
    /// <returns> . </returns>
    public override async Task<FileAchievement> GetAsync(int id, CancellationToken cancellationToken)
    {
        var query = Context.Set<FileAchievement>().AsQueryable();
        query = query
            .Where(l => l.Id == id);

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async Task<List<FileAchievement>> GetByAchievementIdAsync(int id, CancellationToken cancellationToken)
    {
        var query = Context.Set<FileAchievement>().AsQueryable();
        query = query
            .Where(l => l.AchievementId == id);

        return await query.ToListAsync(cancellationToken);
    }
}
