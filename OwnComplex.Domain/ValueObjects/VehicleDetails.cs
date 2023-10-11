namespace OwnComplex.Domain.ValueObjects;

public class VehicleDetails
{
    private VehicleDetails()
    {
        VehicleRegistration = null!;
        Model = null!;
    }

    public VehicleDetails(
        bool vehicleOwnedOrUser,
        string vehicleRegistration,
        string model)
    {
        VehicleOwnedOrUsed = vehicleOwnedOrUser;
        VehicleRegistration = vehicleRegistration;
        Model = model;
    }

    public bool VehicleOwnedOrUsed { get; private set; }

    public string VehicleRegistration { get; private set; }


    public string Model { get; private set; }

    public static VehicleDetails Random()
    {
        return new VehicleDetails(
            true,
            new Random().Next(100000, 1000000).ToString(),
            "Ford");
    }
}