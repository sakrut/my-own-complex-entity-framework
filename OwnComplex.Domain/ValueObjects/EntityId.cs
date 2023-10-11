namespace OwnComplex.Domain.ValueObjects;

public class EntityId
{
    private EntityId()
    {
    }

    public static EntityId Create(Guid id)
    {
        return new EntityId() { Id = id };
    }

    public static EntityId Random()
    {
        var entityId = new EntityId();
        entityId.Id = Guid.NewGuid();
        return entityId;
    }
    public Guid Id { get; set; }

    public override string ToString()
    {
        return $"       EntityId (id= {Id})";
    }
}