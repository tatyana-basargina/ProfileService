namespace ProfileService.Domain.Entities;

public class InstructorProfile: Profile
{
    public Profile Profile { get; set; } = null!;
    public Position? Position { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime DateDismissal { get; set; }
    public int ExperienceBeforeHiring { get; set; }
}