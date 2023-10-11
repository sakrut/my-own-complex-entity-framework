using OwnComplex.Domain.Enums;

namespace OwnComplex.Domain.ValueObjects;

public class Subscription
{
    private Subscription()
    {
    }

    public Subscription(SubscriptionType type, int available)
    {
        Type = type;
        AvailableQuantity = available;
    }

    public SubscriptionType Type { get; }
    public int AvailableQuantity { get; }

    public static Subscription Random()
    {
        return new Subscription(EnumExt.RandomEnumValue<SubscriptionType>(), 1);
    }

}