namespace OwnComplex.Domain.ValueObjects;

public sealed class Address
{
    private Address()
    {
        AddressLine1 = null!;
        AddressLine2 = null!;
        County = null!;
        City = null!;
        PostCode = null!;
    }

    public Address(
        string addressLine1,
        string addressLine2,
        string county,
        string city,
        string postCode,
        Guid? countryId)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        County = county;
        City = city;
        PostCode = postCode;
        CountryId = countryId;
    }

  
    public string AddressLine1 { get; private set; }

    public string AddressLine2 { get; private set; }

    public string County { get; private set; }

    public string City { get; private set; }

    public string PostCode { get; private set; }

    public Guid? CountryId { get; private set; }


    public static Address Random()
    {
            return new Address(
            $"address line 1 {Guid.NewGuid()}",
            $"address line 2 {Guid.NewGuid()}",
            $"county {Guid.NewGuid()}",
            $"city {Guid.NewGuid()}",
            $"post code",
            Guid.NewGuid());
    }
}