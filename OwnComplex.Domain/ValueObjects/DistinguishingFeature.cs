using OwnComplex.Domain.Enums;

namespace OwnComplex.Domain.ValueObjects;

public sealed class DistinguishingFeature
{
    public DistinguishingFeature(DistinguishingFeatureType type, string additionalInformation)
    {
        Type = type;
        AdditionalInformation = additionalInformation;
    }

    public DistinguishingFeatureType Type { get; private set; }
    public string AdditionalInformation { get; private set; }

    public static DistinguishingFeature Random()
    {
        return new DistinguishingFeature(EnumExt.RandomEnumValue<DistinguishingFeatureType>(), $"Tattoo on left arm - {Guid.NewGuid()}");
    }

    public override string ToString()
    {
        return $"       DistinguishingFeature (type= {Type}, additionalInformation= {AdditionalInformation})";
    }
}