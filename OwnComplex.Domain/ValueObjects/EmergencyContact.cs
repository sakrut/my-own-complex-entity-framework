namespace OwnComplex.Domain.ValueObjects;

public class EmergencyContact
{
    private EmergencyContact()
    {
        FirstName = null!;
        LastName = null!;
        PhoneNumber = null!;
    }

    private EmergencyContact(string firstName, string lastName, PhoneNumber phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public PhoneNumber PhoneNumber { get; }

    public static EmergencyContact Random()
    {
        return new EmergencyContact("John", "Doe", PhoneNumber.Random());
    }
}