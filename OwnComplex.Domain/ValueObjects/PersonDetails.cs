namespace OwnComplex.Domain.ValueObjects;

public class PersonDetails
{
    public PersonDetails(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }

    public static PersonDetails Random()
    {
        return new PersonDetails(Guid.NewGuid(), $"PersonDetails {Guid.NewGuid()}");
    }
}