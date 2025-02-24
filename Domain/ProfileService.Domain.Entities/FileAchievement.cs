namespace ProfileService.Domain.Entities;

public class FileAchievement: IEntity<int>
{
    public int Id { get; set; }
    public Guid FileId { get; set; }
    public int AchievementId { get; set; }
    public virtual Achievement Achievement { get; set; } = null!;
}