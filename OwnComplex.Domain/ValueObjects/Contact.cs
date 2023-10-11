namespace OwnComplex.Domain.ValueObjects;

public class Contact
{
    private Contact()
    {
        EmailAddress = null!;
        PhoneNumbers = new List<PhoneNumber>();
    }

    private Contact(string emailAddress, List<PhoneNumber> phoneNumbers)
    {
        EmailAddress = emailAddress.Trim();
        PhoneNumbers = phoneNumbers;
    }

    public string EmailAddress { get; private set; }
    public List<PhoneNumber> PhoneNumbers { get; private set; }

    public static Contact Draft(string emailAddress)
    {
        return new Contact(emailAddress, new List<PhoneNumber>());
    }

    public static Contact SimpleRandom()
    {
        var random = new Random();
        var emailAddress = $"test{random.Next(100, 100000000)}@example.com";
        var contact = new Contact(emailAddress, new List<PhoneNumber>()
        {
            PhoneNumber.Random()
        });
        return contact;
    }

    public static Contact MultipleNumbersRandom()
    {
        var random = new Random();
        var emailAddress = $"test{random.Next(0, 1000)}@example.com";
        var contact = new Contact(emailAddress, new List<PhoneNumber>()
        {
            PhoneNumber.Random(),
            PhoneNumber.Random(),
            PhoneNumber.Random(),
            
        });
        return contact;
    }
}