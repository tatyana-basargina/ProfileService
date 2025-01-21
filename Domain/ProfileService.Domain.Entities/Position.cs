namespace ProfileService.Domain.Entities;

public class Position: IEntity<int>
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
}