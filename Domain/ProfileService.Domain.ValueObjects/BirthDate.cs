namespace ProfileService.Domain.ValueObjects;

public class BirthDate
{
    public int Age => CalculateAge();

    private int CalculateAge()
    {
        throw new NotImplementedException();
    }
}