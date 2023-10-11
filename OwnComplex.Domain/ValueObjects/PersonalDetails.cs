namespace OwnComplex.Domain.ValueObjects;

public sealed class PersonalDetails
{
    private PersonalDetails()
    {
        HomeAddress = null!;
        WorkAddress = null!;
    }

    private PersonalDetails(DateTimeOffset? dateOfBirth, NamedProperty gender, Address homeAddress, Address workAddress)
    {
        DateOfBirth = dateOfBirth;
        Gender = gender;
        HomeAddress = homeAddress;
        WorkAddress = workAddress;
    }

    public DateTimeOffset? DateOfBirth { get; private set; }

    public NamedProperty Gender { get; private set; }

    public Address HomeAddress { get; private set; }

    public Address WorkAddress { get; private set; }

    public static PersonalDetails Random()
    {
        return new PersonalDetails(
            DateTimeOffset.UtcNow,
            NamedProperty.Random(),
            Address.Random(),
            Address.Random());
    }
}