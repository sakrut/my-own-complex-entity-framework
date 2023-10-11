using OwnComplex.Domain.ValueObjects;

namespace OwnComplex.Domain.Entities;

public class PersonEntity
{
    private PersonEntity()
    {
        Ancestors = new List<PersonDetails>();
        Descendants = new List<PersonDetails>();
        FirstName = null!;
        LastName = null!;
        Contact = null!;
        Vehicles = new List<VehicleDetails>();
        EmergencyContacts = new List<EmergencyContact>();
        RiskProfile = new List<EntityId>();
        Roles = new List<EntityId>();
        Trackers = new List<Tracker>();
        AssignedSubscriptions = new List<Subscription>();
        Tags = null!;
    }

    private PersonEntity(Guid tenantId, Guid id, string firstName, string lastName, PersonalDetails? personalDetails,
        MedicalDetails? medicalDetails, PhysicalDetails? physicalDetails, Contact contact,
        ICollection<VehicleDetails> vehicles, ICollection<EmergencyContact> emergencyContacts,
        List<EntityId> riskProfile, List<EntityId> roles, ICollection<Tracker> trackers,
        ICollection<Subscription> assignedSubscriptions, ICollection<PersonDetails> ancestors,
        ICollection<PersonDetails> descendants, ICollection<Tag> tags)
    {
        TenantId = tenantId;
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        PersonalDetails = personalDetails;
        MedicalDetails = medicalDetails;
        PhysicalDetails = physicalDetails;
        Contact = contact;
        Vehicles = vehicles;
        EmergencyContacts = emergencyContacts;
        RiskProfile = riskProfile;
        Roles = roles;
        Trackers = trackers;
        AssignedSubscriptions = assignedSubscriptions;
        Ancestors = ancestors;
        Descendants = descendants;
        Tags = tags;
    }

    public Guid TenantId { get; set; }

    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public PersonalDetails PersonalDetails { get; set; } = null!;

    public MedicalDetails MedicalDetails { get; set; } = null!;

    public PhysicalDetails PhysicalDetails { get; set; } = null!;

    public Contact Contact { get; set; }

    public ICollection<VehicleDetails> Vehicles { get; set; }

    public ICollection<EmergencyContact> EmergencyContacts { get; set; }

    public List<EntityId> RiskProfile { get; set; }

    public List<EntityId> Roles { get; set; }

    public ICollection<PersonDetails> Ancestors { get; set; }
    public ICollection<PersonDetails> Descendants { get; set; }
    
    public ICollection<Tracker> Trackers { get; set; }

    public ICollection<Subscription> AssignedSubscriptions { get; set; }

    public ICollection<Tag> Tags { get; set; }
    public byte[] Timestamp { get; set; }

    public void AddTag(Tag tag)
    {
        Tags.Add(tag);
    }

    public void SetRoles(List<EntityId> roles)
    {
        Roles = roles;
    }

    public void AddRiskProfile(EntityId role)
    {
        RiskProfile.Add(role);
    }

    public void SetTags(ICollection<Tag> tags)
    {
        Tags = tags;
    }

    public void SetPhysicalDetails(PhysicalDetails physicalDetails)
    {
        PhysicalDetails = physicalDetails;
    }

    public void SetMedicalDetails(MedicalDetails medicalDetails)
    {
        MedicalDetails = medicalDetails;
    }

    public static PersonEntity ThinPerson(Guid tenantId)
    {
        return new PersonEntity(
            tenantId,
                       Guid.NewGuid(),
                                  $"Thin",
                                  $"Person",
                                  PersonalDetails.Random(),
                                  MedicalDetails.SimpleRandom(),
                                  PhysicalDetails.SimpleRandom(),
                                  Contact.SimpleRandom(),
                                  new List<VehicleDetails> { VehicleDetails.Random() },
                                  new List<EmergencyContact> { EmergencyContact.Random() },
                                  new List<EntityId> {  },
                                  new List<EntityId> {  },
                                  new List<Tracker> { Tracker.Random() },
                                  new List<Subscription> { Subscription.Random() },
                                 new List<PersonDetails> { PersonDetails.Random() },
                                    new List<PersonDetails> { PersonDetails.Random() },
                                    new List<Tag>(){ });
    }

    public static PersonEntity FatPerson(Guid tenantId)
    {
        return new PersonEntity(
            tenantId,
            Guid.NewGuid(),
            $"Fat",
            $"Person",
            PersonalDetails.Random(),
            MedicalDetails.MultipleConditionsRandom(),
            PhysicalDetails.MultipleDistinguishingFeatureRandom(),
            Contact.MultipleNumbersRandom(),
            new List<VehicleDetails>
            {
                VehicleDetails.Random(),
                VehicleDetails.Random(),
                VehicleDetails.Random(),
                VehicleDetails.Random()
            },
            new List<EmergencyContact>
            {
                EmergencyContact.Random(),
                EmergencyContact.Random(),
                EmergencyContact.Random(),
                EmergencyContact.Random(),
            },
            new List<EntityId>
            {
                EntityId.Random(),
                EntityId.Random(),
                EntityId.Random(),
                EntityId.Random()
            },
            new List<EntityId>
            {
                EntityId.Random(),
                EntityId.Random(),
                EntityId.Random(),
                EntityId.Random()
            },
            new List<Tracker>
            {
                Tracker.Random(),
                Tracker.Random()
            },
            new List<Subscription>
            {
                Subscription.Random(),
                Subscription.Random()
            }, new List<PersonDetails>
            {
                PersonDetails.Random(),
                PersonDetails.Random()

            },
            new List<PersonDetails>
            {
                PersonDetails.Random(),
                PersonDetails.Random(),
            },
            new List<Tag>() { Tag.Random() });
    }

    public void UpdateLastName(string lastName)
    {
        this.LastName = lastName;
    }

    public void AddDistinguishingFeature(DistinguishingFeature random)
    {
        this.PhysicalDetails.DistinguishingFeatures.Add(random);
    }
}