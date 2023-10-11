namespace OwnComplex.Domain.ValueObjects;

public sealed class PhysicalDetails
{
    private PhysicalDetails()
    {
        Height = null!;
        DistinguishingFeatures = null!;
    }

    private PhysicalDetails(
        int? height,
        NamedProperty? build,
        NamedProperty? hairColour,
        NamedProperty? eyeColour,
        ICollection<DistinguishingFeature> distinguishingFeatures)
    {
        Height = height;
        Build = build;
        HairColour = hairColour;
        EyeColour = eyeColour;
        DistinguishingFeatures = distinguishingFeatures;
    }

    public int? Height { get; set; }

    public NamedProperty? Build { get; set; }

    public NamedProperty? HairColour { get; set; }

    public NamedProperty? EyeColour { get; set; }

    public ICollection<DistinguishingFeature> DistinguishingFeatures { get; set; }

    public static PhysicalDetails SimpleRandom()
    {
        return new PhysicalDetails(
            new Random().Next(120,205),
            NamedProperty.Random("Build 1"),
            NamedProperty.Random("Hair Colour 1"),
            NamedProperty.Random("Eye Colour 1"),
            new List<DistinguishingFeature>() { DistinguishingFeature.Random() });
    }

    public static PhysicalDetails MultipleDistinguishingFeatureRandom()
    {
        return new PhysicalDetails(
            new Random().Next(120, 205),
            NamedProperty.Random("Build 1"),
            NamedProperty.Random("Hair Colour 1"),
            NamedProperty.Random("Eye Colour 1"),
            new List<DistinguishingFeature>()
            {
                DistinguishingFeature.Random(),
                DistinguishingFeature.Random(),
                DistinguishingFeature.Random(),
                
            });
    }
}