namespace OwnComplex.Domain.ValueObjects;

public class PhoneNumber
{
    private PhoneNumber()
    {
        Number = null!;
        CountryCode = null!;
    }

    private PhoneNumber(string number, string countryCode)
    {
        CountryCode = countryCode;
        Number = number;
    }

    public string CountryCode { get; private set; }

    public string Number { get; private set; }

    public static PhoneNumber Create(string number, string countryCode)
    {
        return new PhoneNumber(number, countryCode);
    }

    public static PhoneNumber Random()
    {
        return new PhoneNumber(new Random().Next(10000000, 100000000).ToString(), "44");
    }
}