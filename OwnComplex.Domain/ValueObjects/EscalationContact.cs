namespace OwnComplex.Domain.ValueObjects;

public class EscalationContact
{
    public EscalationContact(string escalationContactId)
    {
        Id = escalationContactId;
    }

    public string Id { get; private set; }
}