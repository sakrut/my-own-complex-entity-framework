using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwnComplex.Domain.Entities;
using static OwnComplex.EF7.OwnModel.EntityFrameworkCommonBuilders;

namespace OwnComplex.EF7.OwnModel
#pragma warning disable SA1305 // Field names should not use Hungarian notation
{
    public class PersonEntityTypeConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.ToTable("People", "EF7");

            builder.HasKey(p => new { p.TenantId, p.Id });

            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.TenantId).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Timestamp).IsRowVersion();

            builder.OwnsOne(p => p.PersonalDetails!, pdBuilder =>
            {
                pdBuilder.Property(pd => pd.DateOfBirth);
                pdBuilder.OwnsOne(pd => pd.Gender, BuildNamedProperty);
                pdBuilder.OwnsOne(pd => pd.HomeAddress!, aBuilder =>
                {

                    aBuilder.Property(a => a.AddressLine1).HasMaxLength(100);
                    aBuilder.Property(a => a.AddressLine2).HasMaxLength(100);
                    aBuilder.Property(a => a.County).HasMaxLength(60);
                    aBuilder.Property(a => a.City).HasMaxLength(50);
                    aBuilder.Property(a => a.PostCode).HasMaxLength(10);
                });
                pdBuilder.OwnsOne(pd => pd.WorkAddress!, aBuilder =>
                {
                    aBuilder.Property(a => a.AddressLine1).HasMaxLength(100);
                    aBuilder.Property(a => a.AddressLine2).HasMaxLength(100);
                    aBuilder.Property(a => a.County).HasMaxLength(50);
                    aBuilder.Property(a => a.City).HasMaxLength(50);
                    aBuilder.Property(a => a.PostCode).HasMaxLength(10);
                });
            });

            builder.OwnsOne(p => p.MedicalDetails!, mBuilder =>
            {
                mBuilder.Property(mi => mi.ProgramingImpairment);
                mBuilder.Property(mi => mi.ProgramingImpairmentLevel).IsRequired(false);
                mBuilder.OwnsOne(mi => mi.BloodType, BuildNamedProperty);
                mBuilder.OwnsMany(mi => mi.MedicalConditions, rBuilder =>
                {
                    rBuilder.Property(rp => rp.Id).IsRequired();
                    rBuilder.Property(rp => rp.Name).HasMaxLength(100);
                });

            });

            builder.OwnsOne(p => p.PhysicalDetails!, piBuilder =>
            {
                piBuilder.Property(ph => ph.Height);
                piBuilder.OwnsOne(p => p.Build, BuildNamedProperty);
                piBuilder.OwnsOne(p => p.HairColour, BuildNamedProperty);
                piBuilder.OwnsOne(p => p.EyeColour, BuildNamedProperty);

                piBuilder.OwnsMany(p => p.DistinguishingFeatures, dfBuilder =>
                {
                    dfBuilder.Property(df => df.Type);
                    dfBuilder.Property(df => df.AdditionalInformation);
                });
            });

            builder.OwnsOne(p => p.Contact, cBuilder =>
            {
                cBuilder.Property(c => c.EmailAddress).IsRequired();
                cBuilder.HasIndex(c => c.EmailAddress)
                    .IsUnique()
                    .HasFilter("[Contact_EmailAddress] <> ''")
                    .IsClustered(false);

                cBuilder.OwnsMany(c => c.PhoneNumbers, pnBuilder =>
                {
                    pnBuilder.Property(pn => pn.Number);
                    pnBuilder.Property(pn => pn.CountryCode);

                    pnBuilder.HasIndex(pn => pn.Number)
                        .IsClustered(false);
                });
            });

            builder.OwnsMany(p => p.Vehicles!, vBuilder =>
            {
                vBuilder.Property(vi => vi.VehicleOwnedOrUsed);
                vBuilder.Property(vi => vi.VehicleRegistration).HasMaxLength(30).IsRequired(false);
                vBuilder.Property(vi => vi.Model).HasMaxLength(100).IsRequired(false);
            });

            builder.OwnsMany(p => p.EmergencyContacts!, ecBuilder =>
            {
                ecBuilder.Property(vi => vi.FirstName);
                ecBuilder.Property(vi => vi.LastName).HasMaxLength(30).IsRequired(false);
                ecBuilder.OwnsOne(c => c.PhoneNumber, pnBuilder =>
                {
                    pnBuilder.Property(pn => pn.Number);
                    pnBuilder.Property(pn => pn.CountryCode);
                    pnBuilder.HasIndex(pn => pn.Number)
                        .IsClustered(false);
                });
            });


            builder.OwnsMany(p => p.RiskProfile, rBuilder =>
            {
                rBuilder.Property(rp => rp.Id).IsRequired();
            });

            builder.OwnsMany(p => p.Roles, rBuilder =>
            {
                rBuilder.Property(rp => rp.Id).IsRequired();
            });

            builder.OwnsMany(p => p.Ancestors, gBuilder =>
            {
                gBuilder.Property(r => r.Id).HasColumnName("AssignedTeamId");
                gBuilder.Property(rp => rp.Name).HasMaxLength(100);
            });


            builder.OwnsMany(p => p.Descendants, gBuilder =>
            {
                gBuilder.Property(r => r.Id).HasColumnName("ManagedTeamId");
                gBuilder.Property(rp => rp.Name).HasMaxLength(100);
            });



            builder.OwnsMany(p => p.Trackers, dBuilder =>
            {
                dBuilder.Property(d => d.Id).IsRequired();
                dBuilder.Property(d => d.TrackerType);
                dBuilder.Property(d => d.MobileNumber);
            });

            builder.OwnsMany(p => p.AssignedSubscriptions, sBuilder =>
            {
                sBuilder.Property(s => s.Type);
                sBuilder.Property(s => s.AvailableQuantity);
            });
            builder.OwnsMany(p => p.Tags, sBuilder =>
            {
                sBuilder.Property(tm => tm.Name).IsRequired();
            });


            //builder.HasIndex(x => new { x.FirstName, x.LastName });
            //builder.HasIndex(x => new { x.FirstName, x.LastName, x.Contact.EmailAddress });
        }
    }


}

#pragma warning restore SA1305 // Field names should not use Hungarian notation
