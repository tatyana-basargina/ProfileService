namespace ProfileService.Domain.Entities;

public class Achievement: IEntity<int>
{
    public int Id { get; set; }
    public ProfileInfo Profile { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string? Description { get; set; }
}