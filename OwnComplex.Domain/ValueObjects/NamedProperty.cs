namespace OwnComplex.Domain.ValueObjects;

public class NamedProperty
{
    private NamedProperty()
    {
        Name = null!;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }

    public static NamedProperty Random()
    {
        return new NamedProperty() { Id = Guid.NewGuid() , Name = $"NamedProperty {Guid.NewGuid()}" };
    }

    public static NamedProperty Random(string name)
    {
        return new NamedProperty(){ Id = Guid.NewGuid(), Name = $"{name} {Guid.NewGuid()}" };
    }

    public static NamedProperty Create(Guid id, string name)
    {
        return new NamedProperty() { Id = id, Name = $"{name} {Guid.NewGuid()}" };
    }

    public override string ToString()
    {
        return $"       NamedProperty (Id={Id}, Name={Name})";
    }
}