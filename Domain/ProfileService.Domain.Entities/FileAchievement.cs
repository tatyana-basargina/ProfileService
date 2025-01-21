namespace ProfileService.Domain.Entities;

public class FileAchievement: IEntity<int>
{
    public int Id { get; set; }
    public Achievement Achievement { get; set; } = null!;
    public Guid FileId { get; set; }
}