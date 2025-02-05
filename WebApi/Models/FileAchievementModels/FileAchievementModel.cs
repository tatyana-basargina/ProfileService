namespace WebApi.Models.FileAchievementModels;

public class FileAchievementModel
{
    public int Id { get; set; }
    public Guid FileId { get; set; }
    public int AchievementId { get; set; }
}
