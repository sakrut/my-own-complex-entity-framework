using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwnComplex.EF7.Migrations
{
    /// <inheritdoc />
    public partial class StartEF7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "EF7");

            migrationBuilder.CreateTable(
                name: "People",
                schema: "EF7",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalDetails_DateOfBirth = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    PersonalDetails_Gender_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalDetails_Gender_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PersonalDetails_HomeAddress_AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalDetails_HomeAddress_AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalDetails_HomeAddress_County = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PersonalDetails_HomeAddress_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalDetails_HomeAddress_PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PersonalDetails_HomeAddress_CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonalDetails_WorkAddress_AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalDetails_WorkAddress_AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PersonalDetails_WorkAddress_County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalDetails_WorkAddress_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PersonalDetails_WorkAddress_PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PersonalDetails_WorkAddress_CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicalDetails_ProgramingImpairment = table.Column<bool>(type: "bit", nullable: false),
                    MedicalDetails_ProgramingImpairmentLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalDetails_BloodType_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicalDetails_BloodType_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhysicalDetails_Height = table.Column<int>(type: "int", nullable: true),
                    PhysicalDetails_Build_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhysicalDetails_Build_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhysicalDetails_HairColour_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhysicalDetails_HairColour_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhysicalDetails_EyeColour_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhysicalDetails_EyeColour_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Contact_EmailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => new { x.TenantId, x.Id });
                });

            migrationBuilder.CreateTable(
                name: "Tracker",
                schema: "EF7",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrackerType = table.Column<int>(type: "int", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracker", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_Tracker_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistinguishingFeature",
                schema: "EF7",
                columns: table => new
                {
                    PhysicalDetailsPersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhysicalDetailsPersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AdditionalInformation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistinguishingFeature", x => new { x.PhysicalDetailsPersonEntityTenantId, x.PhysicalDetailsPersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_DistinguishingFeature_People_PhysicalDetailsPersonEntityTenantId_PhysicalDetailsPersonEntityId",
                        columns: x => new { x.PhysicalDetailsPersonEntityTenantId, x.PhysicalDetailsPersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                schema: "EF7",
                columns: table => new
                {
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PhoneNumber_CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber_Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_EmergencyContact_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People_Ancestors",
                schema: "EF7",
                columns: table => new
                {
                    AssignedTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_Ancestors", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.AssignedTeamId });
                    table.ForeignKey(
                        name: "FK_People_Ancestors_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People_Descendants",
                schema: "EF7",
                columns: table => new
                {
                    ManagedTeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_Descendants", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.ManagedTeamId });
                    table.ForeignKey(
                        name: "FK_People_Descendants_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People_MedicalConditions",
                schema: "EF7",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalDetailsPersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalDetailsPersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_MedicalConditions", x => new { x.MedicalDetailsPersonEntityTenantId, x.MedicalDetailsPersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_People_MedicalConditions_People_MedicalDetailsPersonEntityTenantId_MedicalDetailsPersonEntityId",
                        columns: x => new { x.MedicalDetailsPersonEntityTenantId, x.MedicalDetailsPersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People_PhoneNumbers",
                schema: "EF7",
                columns: table => new
                {
                    ContactPersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactPersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_PhoneNumbers", x => new { x.ContactPersonEntityTenantId, x.ContactPersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_People_PhoneNumbers_People_ContactPersonEntityTenantId_ContactPersonEntityId",
                        columns: x => new { x.ContactPersonEntityTenantId, x.ContactPersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People_RiskProfile",
                schema: "EF7",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_RiskProfile", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_People_RiskProfile_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People_Roles",
                schema: "EF7",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People_Roles", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_People_Roles_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "EF7",
                columns: table => new
                {
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_Subscription_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                schema: "EF7",
                columns: table => new
                {
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_Tag_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleDetails",
                schema: "EF7",
                columns: table => new
                {
                    PersonEntityTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleOwnedOrUsed = table.Column<bool>(type: "bit", nullable: false),
                    VehicleRegistration = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDetails", x => new { x.PersonEntityTenantId, x.PersonEntityId, x.Id });
                    table.ForeignKey(
                        name: "FK_VehicleDetails_People_PersonEntityTenantId_PersonEntityId",
                        columns: x => new { x.PersonEntityTenantId, x.PersonEntityId },
                        principalSchema: "EF7",
                        principalTable: "People",
                        principalColumns: new[] { "TenantId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PhoneNumber_Number",
                schema: "EF7",
                table: "EmergencyContact",
                column: "PhoneNumber_Number")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_People_Contact_EmailAddress",
                schema: "EF7",
                table: "People",
                column: "Contact_EmailAddress",
                unique: true,
                filter: "[Contact_EmailAddress] <> ''")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_People_PhoneNumbers_Number",
                schema: "EF7",
                table: "People_PhoneNumbers",
                column: "Number")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracker",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "DistinguishingFeature",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "EmergencyContact",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "People_Ancestors",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "People_Descendants",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "People_MedicalConditions",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "People_PhoneNumbers",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "People_RiskProfile",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "People_Roles",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "Tag",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "VehicleDetails",
                schema: "EF7");

            migrationBuilder.DropTable(
                name: "People",
                schema: "EF7");
        }
    }
}
