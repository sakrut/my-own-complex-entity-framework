namespace OwnComplex.Domain.Enums;

public static class EnumExt
{
    private static readonly Random Random = new();

    public static T RandomEnumValue<T>() where T : Enum
    {
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(Random.Next(v.Length))!;
    }
}