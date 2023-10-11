using OwnComplex.Domain.Enums;

namespace OwnComplex.Domain.ValueObjects;

public class Tracker
{
    public Tracker()
    {
        MobileNumber = null!;
    }

    public Tracker(Guid id, TrackerType trackerTypeId, string? trackerMobileNumber)
    {
        Id = id;
        TrackerType = trackerTypeId;
        MobileNumber = trackerMobileNumber;
    }

    public Guid Id { get; private set; }
    public TrackerType TrackerType { get; private set; }
    public string? MobileNumber { get; private set; }

    public static Tracker Random()
    {
        return new Tracker(Guid.NewGuid(), TrackerType.Phone, "123456789");
    }
}