using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reputy.Application.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Av = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AverageRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShared = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Deposit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PetsAllowed = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrls = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advertisements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementRealEstates",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertisementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Disposition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementRealEstates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdvertisementRealEstates_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LandlordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdvertisementID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rentals_Advertisements_AdvertisementID",
                        column: x => x.AdvertisementID,
                        principalTable: "Advertisements",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_LandlordId",
                        column: x => x.LandlordId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertisementRealEstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_AdvertisementRealEstates_AdvertisementRealEstateId",
                        column: x => x.AdvertisementRealEstateId,
                        principalTable: "AdvertisementRealEstates",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ID);
                    table.ForeignKey(
                        name: "FK_References_Rentals_RentalID",
                        column: x => x.RentalID,
                        principalTable: "Rentals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_References_Users_FromUserID",
                        column: x => x.FromUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_References_Users_ToUserID",
                        column: x => x.ToUserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Av", "AvatarUrl", "AverageRating", "CreatedAt", "Email", "FirstName", "IsVerified", "LastName", "Password", "Role", "Salt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "https://example.com/avatar1.png", 0m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1952), "jan.novak@example.com", "Jan", true, "Novak", "hashedpassword1", 2, null, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1954) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, null, 0m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1959), "eva.svobodova@example.com", "Eva", false, "Svobodova", null, 1, null, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1960) }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "ID", "Address", "CreatedAt", "Deposit", "Description", "ImageUrls", "IsShared", "PetsAllowed", "Price", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("00a6a112-6782-4ede-83a0-230c9909cac9"), "Jiráskova 4, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1023), 13575m, null, "[]", false, false, 27150, "Byt 59 - Hradec Králové Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1023), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("02745a1b-4f28-4335-a85e-a6d5138d933f"), "Jiráskova 13, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(492), 15589m, null, "[]", true, false, 31179, "Byt 28 - Brno Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(493), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("06af0f8f-18b9-445d-9005-5a30aaadd97e"), "Jiráskova 99, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(899), 12018m, null, "[]", false, false, 24036, "Byt 53 - Hradec Králové Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(899), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("078b9413-a1f2-40ec-984b-e6b9c197e443"), "Masarykova 77, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(237), 10588m, null, "[]", true, true, 21176, "Byt 12 - Brno Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(237), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("0bf69b0e-687f-46ef-961e-18f446c6ee0f"), "Školní 91, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1475), 7021m, null, "[]", true, false, 14043, "Byt 86 - Brno Školní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1476), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("141412be-424b-4421-9d0b-9bb123b6afe6"), "Hlavní 74, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(36), 13976m, null, "[]", true, false, 27952, "Byt 4 - Plzeň Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(37), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("15a8edff-5440-43db-8ff0-b808ef82f97b"), "Nádražní 18, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(362), 6644m, null, "[]", false, false, 13289, "Byt 19 - Hradec Králové Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(363), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("16e1ff72-00ec-42af-acba-282daa59a2c0"), "Nádražní 51, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(308), 8288m, null, "[]", false, false, 16576, "Byt 17 - Brno Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(309), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("181bbf37-b735-41b1-86cf-2d4632ab8e05"), "Hlavní 2, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(620), 8355m, null, "[]", false, false, 16711, "Byt 35 - Liberec Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(621), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("1dc237a3-81d9-4248-b7a2-3cc7387fbbd4"), "Masarykova 79, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(521), 10310m, null, "[]", true, true, 20620, "Byt 30 - České Budějovice Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(522), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("1fbea550-9133-4921-901d-4c8a0a076ab5"), "Masarykova 69, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(420), 17212m, null, "[]", false, false, 34424, "Byt 23 - Pardubice Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(421), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("24609037-f19c-4b6d-8b1a-92d07c3c6503"), "Tyršova 11, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1503), 11051m, null, "[]", true, false, 22102, "Byt 88 - Plzeň Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1504), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("246e4e4f-629a-497d-ada6-cf84914a68a5"), "Smetanova 86, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1658), 5100m, null, "[]", false, false, 10201, "Byt 97 - Brno Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1659), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("262a3bf7-e84f-4eae-957b-ac911bf3940b"), "Jiráskova 36, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(159), 11577m, null, "[]", false, false, 23154, "Byt 7 - Plzeň Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(160), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("288a597f-3e36-4c3f-a0da-0649a9f16a82"), "Nádražní 90, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(347), 15717m, null, "[]", true, true, 31435, "Byt 18 - Olomouc Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(348), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("2cbca316-d307-45d2-8c10-8c3b4f56e1a5"), "Dlouhá 93, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(940), 12436m, null, "[]", true, false, 24872, "Byt 56 - Pardubice Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(941), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("2fbdac33-d345-47e9-9ddf-5279472cb551"), "Hlavní 40, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1517), 9142m, null, "[]", false, false, 18284, "Byt 89 - Brno Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1518), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("30473e7b-a456-4256-8a7b-53f36d3971dc"), "Tyršova 67, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(222), 11963m, null, "[]", false, false, 23926, "Byt 11 - Hradec Králové Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(223), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("3078ed5e-e1d8-4e83-a052-5e4a6e9b26f5"), "Nádražní 83, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(69), 5755m, null, "[]", true, true, 11510, "Byt 6 - Praha Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(70), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Náměstí Míru 5, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2040), 5000m, null, "[]", true, true, 15000, "Moderní byt v centru", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2041), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("35944f10-8548-4647-8044-f03b495f359c"), "Masarykova 20, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1285), 17293m, null, "[]", false, true, 34587, "Byt 75 - Olomouc Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1286), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("36c0975a-03b7-49d0-b783-73d426f18786"), "Hlavní 85, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(869), 17147m, null, "[]", false, true, 34295, "Byt 51 - Praha Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(870), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("39c7a962-7453-4216-b7b9-8728ba136d12"), "Tyršova 77, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(392), 14508m, null, "[]", false, true, 29017, "Byt 21 - Ostrava Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(392), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("3c4fa351-fa76-4df9-93d8-4b5d6e2cf76f"), "Nádražní 12, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1037), 5549m, null, "[]", true, true, 11098, "Byt 60 - Liberec Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1038), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("3fef98b6-5808-43e6-85c3-b917a0d8979a"), "Jiráskova 70, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(266), 13248m, null, "[]", true, false, 26496, "Byt 14 - Pardubice Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(267), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44fa649e-6997-48d8-81de-b78646d3d559"), "Jiráskova 88, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(450), 11016m, null, "[]", false, false, 22033, "Byt 25 - České Budějovice Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(451), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("4973285e-8989-4551-91ec-b5c41cfd18ee"), "Tyršova 89, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(706), 14125m, null, "[]", false, false, 28251, "Byt 41 - Liberec Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(707), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("49fb8223-481b-4a16-a96a-50cd73dab934"), "Dlouhá 35, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(507), 12901m, null, "[]", false, false, 25803, "Byt 29 - Praha Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(508), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("4a5878fe-d516-4ec2-94a8-4d040dc6c256"), "Nádražní 46, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1271), 8320m, null, "[]", true, false, 16641, "Byt 74 - Liberec Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1272), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("50572853-468d-428e-a5c1-c71f38ce9f8c"), "Jiráskova 35, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(606), 16543m, null, "[]", true, false, 33086, "Byt 34 - Olomouc Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(607), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("5253d9ff-65b3-475f-a01d-2be2e1a13c40"), "Tyršova 30, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(175), 15632m, null, "[]", true, false, 31264, "Byt 8 - České Budějovice Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(176), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("5a33bd9d-5099-4f3c-bc24-1532031f94ae"), "Tyršova 91, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(828), 7687m, null, "[]", true, true, 15375, "Byt 48 - Hradec Králové Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(829), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("5b94d906-9414-4c3b-99ff-914987194e4b"), "Hlavní 11, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1532), 16820m, null, "[]", true, true, 33640, "Byt 90 - Olomouc Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1533), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("5bd55e38-9f18-42ee-b7b1-5a66569b17c6"), "Nádražní 41, Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1065), 15418m, null, "[]", true, false, 30837, "Byt 62 - Zlín Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1066), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("5d4117b2-ab62-4a96-965f-38d464b1ea4d"), "Masarykova 61, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(5), 7712m, null, "[]", true, false, 15425, "Byt 2 - Pardubice Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(6), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("5dfd6709-baad-4223-99cf-8a7adb46a612"), "Hlavní 40, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1432), 5605m, null, "[]", false, false, 11211, "Byt 83 - Olomouc Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1432), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("60ae1d22-ec36-4b08-906d-e3ff5d9aadaa"), "Dlouhá 57, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(857), 9803m, null, "[]", true, false, 19607, "Byt 50 - Brno Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(857), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("61740cdb-8a1b-42de-a62a-7ec3ac7382fc"), "Masarykova 92, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(52), 11073m, null, "[]", false, false, 22146, "Byt 5 - Liberec Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(53), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("617b7382-fa21-43c7-899f-ba3993258d11"), "Jiráskova 53, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1215), 15667m, null, "[]", true, false, 31335, "Byt 70 - Pardubice Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1216), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("63cd2104-3f58-442b-a2e0-49288a701d52"), "Dlouhá 23, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(208), 6014m, null, "[]", true, false, 12028, "Byt 10 - Hradec Králové Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(209), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("646616d8-63a3-4cea-964c-5365cef14c97"), "Masarykova 85, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(294), 8817m, null, "[]", true, false, 17635, "Byt 16 - Praha Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(294), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("65b9ff26-9cec-47ab-baae-8dbf234426d1"), "Dlouhá 98, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1328), 17377m, null, "[]", true, true, 34755, "Byt 78 - Hradec Králové Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1329), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("65c9ee88-7f6e-4231-a667-ea7f7ac62d83"), "Tyršova 1, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(478), 10234m, null, "[]", false, true, 20469, "Byt 27 - Hradec Králové Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(478), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("6f95e6b9-5a6f-40af-ab33-b8d1313dbc49"), "Masarykova 21, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(534), 4778m, null, "[]", false, false, 9556, "Byt 31 - Ostrava Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(535), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("71636af7-bf30-481a-994e-152232acf9dd"), "Nádražní 27, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(800), 9393m, null, "[]", true, false, 18786, "Byt 46 - Plzeň Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(801), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("71b8c789-3460-437c-ac85-7255c1b342df"), "Dlouhá 21, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(464), 7595m, null, "[]", true, false, 15191, "Byt 26 - Ostrava Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(465), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("71c83019-e77e-4576-af68-8521161e48a1"), "Hlavní 77, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(884), 11932m, null, "[]", true, false, 23865, "Byt 52 - Hradec Králové Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(885), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("728d4796-0e64-4b0d-8434-4ac08d254529"), "Jiráskova 82, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(771), 13768m, null, "[]", true, false, 27537, "Byt 44 - Liberec Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(772), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("73c4973a-1bc9-46aa-bac3-937c26288c04"), "Tyršova 74, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(720), 9096m, null, "[]", true, true, 18192, "Byt 42 - Olomouc Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(720), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("75bfd2b3-c33c-4465-9367-dcdb452aa81f"), "Jiráskova 58, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1559), 8018m, null, "[]", true, false, 16037, "Byt 92 - Brno Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1560), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Rašínovo nábřeží 12, Praha 2", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2047), 6000m, null, "[]", false, false, 18000, "Byt 2+KK s výhledem na řeku", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2048), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("78dc5c45-6322-48ee-901c-9085cbcad45e"), "Jiráskova 92, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(573), 8969m, null, "[]", true, false, 17939, "Byt 32 - Liberec Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(574), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("80298422-2f86-4751-9949-ad05cccd560f"), "Smetanova 15, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(635), 15178m, null, "[]", true, true, 30357, "Byt 36 - Liberec Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(636), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("82fafb1c-e29e-4f90-8cf7-82e9d550e5ca"), "Školní 19, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1243), 16397m, null, "[]", true, true, 32794, "Byt 72 - Plzeň Školní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1244), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("8515d885-ed6e-4f79-a850-1fb4d99a31af"), "Smetanova 38, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(786), 7636m, null, "[]", false, true, 15272, "Byt 45 - Pardubice Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(786), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "U školy 45, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2052), 8000m, null, "[]", false, true, 22000, "Velký byt 3+1 pro rodinu", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2053), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("910345d7-488d-4c6e-b197-53a4ac9f0dca"), "Tyršova 21, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1446), 12988m, null, "[]", true, true, 25976, "Byt 84 - Ostrava Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1447), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("91ad96d2-30b2-4a7f-9208-347131c49f6d"), "Tyršova 41, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1257), 11693m, null, "[]", false, false, 23387, "Byt 73 - Hradec Králové Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1258), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("93546649-142e-4374-afcf-35e757fe8e0c"), "Hlavní 47, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1171), 5533m, null, "[]", false, false, 11067, "Byt 67 - Hradec Králové Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1172), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("936b9dbd-a456-4a56-b4ae-1db84965781f"), "Jiráskova 81, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1107), 12393m, null, "[]", false, false, 24786, "Byt 65 - Olomouc Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1108), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("940eca52-2cbb-4680-8c5b-64e848be9beb"), "Smetanova 84, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(435), 11046m, null, "[]", true, true, 22093, "Byt 24 - Praha Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(436), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("979e041b-cc63-4046-9e22-fa14a36d8ad1"), "Jiráskova 10, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1390), 16230m, null, "[]", true, false, 32460, "Byt 80 - Pardubice Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1390), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("988a2883-aefb-46fd-b060-fd6987126617"), "Tyršova 37, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1157), 15894m, null, "[]", true, true, 31788, "Byt 66 - České Budějovice Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1158), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("99a32b2d-8446-4d7c-aae6-4a0afbe14291"), "Masarykova 9, Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(678), 8459m, null, "[]", false, true, 16919, "Byt 39 - Zlín Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(679), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("9a987b21-4bec-4f7d-97de-6e226b2de3a0"), "Tyršova 56, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1051), 8473m, null, "[]", false, false, 16947, "Byt 61 - Brno Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1052), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("9b788cb6-a8ee-44ba-96e2-790cfcde513b"), "Dlouhá 90, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(664), 15056m, null, "[]", true, false, 30113, "Byt 38 - Pardubice Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(665), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("9e454efa-c899-42b3-8b12-ace7f2c7e6d9"), "Dlouhá 28, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(926), 9756m, null, "[]", false, false, 19513, "Byt 55 - Plzeň Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(926), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a2c7e1b6-a74e-4490-9b25-2c3124a91479"), "Jiráskova 97, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(407), 16677m, null, "[]", true, false, 33355, "Byt 22 - České Budějovice Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(408), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a3918271-c993-4eda-8fd2-17faa317986a"), "Hlavní 14, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1079), 17163m, null, "[]", false, true, 34327, "Byt 63 - Pardubice Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1079), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a6b5b0c3-b190-4ffa-97d0-71677642524f"), "Nádražní 98, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(191), 13817m, null, "[]", false, true, 27634, "Byt 9 - Brno Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(191), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a7e1f1e0-1569-43a1-aea3-a729665c1610"), "Smetanova 76, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(813), 15238m, null, "[]", false, false, 30476, "Byt 47 - Ostrava Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(814), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("a901c38b-0b67-4bb1-b275-0a88bb986202"), "Smetanova 83, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1186), 8592m, null, "[]", true, false, 17185, "Byt 68 - České Budějovice Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1187), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("ac7afeae-1c50-412f-a97c-b1cb9e930321"), "Tyršova 71, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1628), 16542m, null, "[]", false, false, 33084, "Byt 95 - Plzeň Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1629), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("af63d7ab-79a3-4162-92b6-fda4b07326fa"), "Masarykova 68, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(994), 6905m, null, "[]", false, true, 13810, "Byt 57 - Plzeň Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(995), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("b41ec03c-82e5-42d6-96c5-80c10e9c59d0"), "Masarykova 46, Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1600), 5162m, null, "[]", false, true, 10324, "Byt 93 - Hradec Králové Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1601), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("b53feb0f-3f03-443b-b339-de58f95c1738"), "Hlavní 57, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(913), 12894m, null, "[]", true, true, 25788, "Byt 54 - Ostrava Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(913), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("bd62915c-6580-40f1-b501-4b5e65e8f779"), "Hlavní 84, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1673), 9063m, null, "[]", true, false, 18127, "Byt 98 - České Budějovice Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1674), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("be681d11-bc62-4f7f-be05-de59862bb1c2"), "Nádražní 49, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1314), 9350m, null, "[]", false, false, 18701, "Byt 77 - České Budějovice Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1315), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c19482e5-ada7-443f-ad46-9aa5a8590bb4"), "Nádražní 6, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1404), 4846m, null, "[]", false, true, 9693, "Byt 81 - Praha Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1405), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c3159000-4703-4750-ba10-7dedff1867cb"), "Nádražní 15, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1643), 15083m, null, "[]", true, true, 30167, "Byt 96 - Plzeň Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1644), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("c917b4d2-cc4f-4dbe-94d6-7efb5112c3b9"), "Smetanova 5, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1201), 5480m, null, "[]", false, true, 10960, "Byt 69 - Liberec Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1201), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("cb7c1037-53e6-4608-930a-eface4d8599c"), "Tyršova 34, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1489), 13956m, null, "[]", false, true, 27913, "Byt 87 - Plzeň Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1489), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("cc13b9fe-4073-4bed-bc4a-197a1b1b21b4"), "Hlavní 5, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(589), 16710m, null, "[]", false, true, 33421, "Byt 33 - Brno Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(589), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d2aa4ec0-c93e-4535-942c-fd6c97897f60"), "Školní 79, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1009), 14791m, null, "[]", true, false, 29582, "Byt 58 - Brno Školní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1010), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d3be4ef4-fbd5-412c-92ef-3ce4811ca351"), "Hlavní 63, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1686), 17423m, null, "[]", false, true, 34846, "Byt 99 - České Budějovice Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1687), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("d3f1b385-835e-4227-99cf-e51a9d928db1"), "Školní 31, Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1093), 16157m, null, "[]", true, false, 32315, "Byt 64 - Zlín Školní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1093), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("da3c2130-ab7d-4817-9332-752fc49614cc"), "Smetanova 82, Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(692), 6502m, null, "[]", true, false, 13005, "Byt 40 - Plzeň Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(693), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("db24e1cc-9d54-4a53-bdb5-e09cb3c73c27"), "Školní 84, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(650), 8150m, null, "[]", false, false, 16300, "Byt 37 - Ostrava Školní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(650), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("dc782f9e-becc-43a7-9746-3d4c53689091"), "Masarykova 28, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 264, DateTimeKind.Local).AddTicks(9975), 9120m, null, "[]", false, false, 18240, "Byt 1 - České Budějovice Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 264, DateTimeKind.Local).AddTicks(9977), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("ddfee6b7-78bd-4c87-b4b0-7b76a942f062"), "Dlouhá 5, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1418), 17479m, null, "[]", true, false, 34958, "Byt 82 - Brno Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1419), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("de542311-7cfa-4988-bcca-f877f70fdc8d"), "Masarykova 92, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(21), 14472m, null, "[]", false, true, 28944, "Byt 3 - Praha Masarykova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(21), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("dfcf3925-1874-4454-952b-cc95e9de704a"), "Smetanova 1, Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(279), 13911m, null, "[]", false, true, 27823, "Byt 15 - Zlín Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(280), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("e10047dd-51ec-4ca6-96d9-f2f4109ecb71"), "Hlavní 85, Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(377), 4866m, null, "[]", true, false, 9733, "Byt 20 - Olomouc Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(378), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("e992a882-6254-4598-8aa4-221921d6c0b0"), "Jiráskova 37, Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1299), 16793m, null, "[]", true, false, 33587, "Byt 76 - Ostrava Jiráskova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1300), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("eb141001-cf30-4a7c-9ac2-ac5bae4799fd"), "Hlavní 91, Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1701), 7252m, null, "[]", true, false, 14505, "Byt 100 - Pardubice Hlavní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1702), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("eb3d9316-73f8-40d7-b3c1-f0a7b785a9f5"), "Školní 6, Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(756), 16009m, null, "[]", false, false, 32019, "Byt 43 - Zlín Školní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(757), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("ebbbe892-7e8d-4b1d-9ac9-20f7e5684a3c"), "Nádražní 8, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1374), 11571m, null, "[]", false, false, 23142, "Byt 79 - Liberec Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1375), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("ef5963f8-542f-47f5-bcb9-944b67acb615"), "Smetanova 76, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1229), 10069m, null, "[]", false, false, 20138, "Byt 71 - Praha Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1230), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("f31b9104-29eb-4454-9f70-dc34f0e777e6"), "Smetanova 67, České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(252), 17069m, null, "[]", false, false, 34139, "Byt 13 - České Budějovice Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(252), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("f558eb6c-b852-4083-a3c7-1c6ab8e61e28"), "Nádražní 65, Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1615), 9589m, null, "[]", true, false, 19178, "Byt 94 - Praha Nádražní", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1616), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("fafc0b1c-7273-43a6-8c20-206760c7368c"), "Smetanova 92, Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1545), 9396m, null, "[]", false, false, 18793, "Byt 91 - Brno Smetanova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1546), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("fc33e1bf-8402-4b3d-8771-3bea47d59fc3"), "Tyršova 42, Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(842), 10062m, null, "[]", false, false, 20124, "Byt 49 - Liberec Tyršova", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(843), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("fe8e3d59-71c2-4b03-836c-be4aed6b388a"), "Dlouhá 19, Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1461), 9111m, null, "[]", false, false, 18223, "Byt 85 - Zlín Dlouhá", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1461), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "AdvertisementRealEstates",
                columns: new[] { "ID", "AdvertisementId", "CreatedAt", "Disposition", "RentalType", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0094c2a9-dc51-492a-9ef8-a4d4f3ef977d"), new Guid("4973285e-8989-4551-91ec-b5c41cfd18ee"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(710), "TwoKK", "Roomates", 105m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(711) },
                    { new Guid("012d18dd-b679-448d-8973-901f903f7c72"), new Guid("3078ed5e-e1d8-4e83-a052-5e4a6e9b26f5"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(74), "FivePlusOne", "House", 48m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(74) },
                    { new Guid("08148619-caa4-4be7-8583-14977aff84cf"), new Guid("988a2883-aefb-46fd-b060-fd6987126617"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1161), "FourPlusOne", "Atelier", 40m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1162) },
                    { new Guid("0a862e22-f4c0-41ac-a3f6-61211b9deda2"), new Guid("fafc0b1c-7273-43a6-8c20-206760c7368c"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1550), "FourPlusOne", "Roomates", 87m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1551) },
                    { new Guid("0c18b8db-f6ff-4067-a5b7-c3bdc6aa33f4"), new Guid("ac7afeae-1c50-412f-a97c-b1cb9e930321"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1634), "TwoPlusOne", "Atelier", 50m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1634) },
                    { new Guid("0f92b1aa-c65d-4d64-9727-829fe8b420c0"), new Guid("b41ec03c-82e5-42d6-96c5-80c10e9c59d0"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1604), "OneKK", "Apartman", 78m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1605) },
                    { new Guid("14f7c1e2-4d7f-4db8-9ad3-0d9a419b627c"), new Guid("dfcf3925-1874-4454-952b-cc95e9de704a"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(284), "TwoPlusOne", "Atelier", 43m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(285) },
                    { new Guid("1673d387-42e3-444f-8763-d22c6dd84227"), new Guid("979e041b-cc63-4046-9e22-fa14a36d8ad1"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1393), "ThreePlusOne", "Atelier", 81m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1394) },
                    { new Guid("17b3cb48-24e7-49a3-8225-d5136bf22dbc"), new Guid("c3159000-4703-4750-ba10-7dedff1867cb"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1647), "FourPlusOne", "House", 40m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1648) },
                    { new Guid("1d47de8f-7176-492a-9cbd-1d8d57a6a867"), new Guid("a3918271-c993-4eda-8fd2-17faa317986a"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1084), "ThreePlusOne", "Roomates", 29m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1085) },
                    { new Guid("1d83047e-5a9c-4124-9157-d26b6475c527"), new Guid("99a32b2d-8446-4d7c-aae6-4a0afbe14291"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(683), "OnePlusOne", "Apartman", 82m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(684) },
                    { new Guid("1dd25cdb-7ffc-42ef-b551-c7941cd0758d"), new Guid("eb141001-cf30-4a7c-9ac2-ac5bae4799fd"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1705), "TwoPlusOne", "House", 51m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1705) },
                    { new Guid("1f35fb82-e151-4ecb-8cac-c99bcf0a10f6"), new Guid("16e1ff72-00ec-42af-acba-282daa59a2c0"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(312), "ThreePlusOne", "House", 67m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(313) },
                    { new Guid("22b8f992-dc68-4497-847c-084adcbfbdf9"), new Guid("fe8e3d59-71c2-4b03-836c-be4aed6b388a"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1464), "FivePlusOne", "Apartman", 22m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1465) },
                    { new Guid("269642ff-5840-4b4a-a0ed-c3daa450b83c"), new Guid("5dfd6709-baad-4223-99cf-8a7adb46a612"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1437), "TwoKK", "Flat", 27m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1438) },
                    { new Guid("2feb228e-460e-4100-91c9-a4e49e3442be"), new Guid("db24e1cc-9d54-4a53-bdb5-e09cb3c73c27"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(653), "OnePlusOne", "Roomates", 35m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(654) },
                    { new Guid("34adfda8-e6db-4c3a-a5e2-74fb867cd8d3"), new Guid("246e4e4f-629a-497d-ada6-cf84914a68a5"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1662), "ThreeKK", "Atelier", 44m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1663) },
                    { new Guid("35115eb5-c91c-4af9-8944-5d8ce36506b1"), new Guid("60ae1d22-ec36-4b08-906d-e3ff5d9aadaa"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(860), "ThreeKK", "Apartman", 98m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(861) },
                    { new Guid("38f17407-849c-48ca-9136-621fed82164b"), new Guid("1fbea550-9133-4921-901d-4c8a0a076ab5"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(425), "FourKK", "Apartman", 63m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(426) },
                    { new Guid("3a24a72c-0222-45c2-8db4-356d05eab1d2"), new Guid("f558eb6c-b852-4083-a3c7-1c6ab8e61e28"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1619), "FourKK", "Roomates", 70m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1620) },
                    { new Guid("3a43ff74-cb83-4ab4-a2b9-02755a1e95c6"), new Guid("15a8edff-5440-43db-8ff0-b808ef82f97b"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(367), "ThreeKK", "Roomates", 63m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(368) },
                    { new Guid("3b1c881d-f909-440c-9dec-d6eb26a0d0c1"), new Guid("617b7382-fa21-43c7-899f-ba3993258d11"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1219), "TwoPlusOne", "Flat", 22m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1220) },
                    { new Guid("3d6082bd-5786-4a70-b5f8-fcb72d5c85b0"), new Guid("d3be4ef4-fbd5-412c-92ef-3ce4811ca351"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1691), "TwoPlusOne", "House", 65m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1692) },
                    { new Guid("3dd28fe1-bae1-45cd-83f5-3eec71eed01b"), new Guid("65c9ee88-7f6e-4231-a667-ea7f7ac62d83"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(483), "ThreeKK", "Atelier", 46m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(483) },
                    { new Guid("41f9534f-2d29-4c03-a5d1-0c88ec19c658"), new Guid("288a597f-3e36-4c3f-a0da-0649a9f16a82"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(352), "ThreeKK", "Apartman", 91m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(352) },
                    { new Guid("425539c9-217e-4961-9d4f-37d50bc32755"), new Guid("c19482e5-ada7-443f-ad46-9aa5a8590bb4"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1408), "FiveKK", "House", 81m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1409) },
                    { new Guid("42d115cf-257f-408d-adfc-062acdd4337f"), new Guid("0bf69b0e-687f-46ef-961e-18f446c6ee0f"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1479), "FivePlusOne", "Apartman", 73m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1480) },
                    { new Guid("4528da45-ab0f-458f-9704-78b22498ed58"), new Guid("49fb8223-481b-4a16-a96a-50cd73dab934"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(511), "OneKK", "Apartman", 89m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(511) },
                    { new Guid("472a2338-8387-4f1a-813a-ab7f976a6ec5"), new Guid("5253d9ff-65b3-475f-a01d-2be2e1a13c40"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(179), "FourKK", "Apartman", 73m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(180) },
                    { new Guid("495bbf0a-1f3f-477a-b723-9de5ba5b5950"), new Guid("91ad96d2-30b2-4a7f-9208-347131c49f6d"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1261), "TwoKK", "Apartman", 98m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1262) },
                    { new Guid("4c2f0b34-3538-414b-8c33-449a05f7ec52"), new Guid("a2c7e1b6-a74e-4490-9b25-2c3124a91479"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(411), "ThreePlusOne", "House", 86m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(412) },
                    { new Guid("519dcd8d-0ad8-4cd1-b03a-39f71a92f916"), new Guid("75bfd2b3-c33c-4465-9367-dcdb452aa81f"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1563), "TwoKK", "Flat", 98m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1564) },
                    { new Guid("54f4472f-1f58-4175-b3f1-18c4dea9f708"), new Guid("71636af7-bf30-481a-994e-152232acf9dd"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(804), "ThreeKK", "Atelier", 48m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(805) },
                    { new Guid("562de589-8958-4020-af36-79de7dee8b5a"), new Guid("d3f1b385-835e-4227-99cf-e51a9d928db1"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1096), "OnePlusOne", "Atelier", 29m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1097) },
                    { new Guid("59059e05-a5aa-459e-a7c9-b0e7d8c9fe71"), new Guid("65b9ff26-9cec-47ab-baae-8dbf234426d1"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1332), "TwoKK", "House", 27m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1333) },
                    { new Guid("5a474b30-6a2d-4daa-a76b-17df6d32ba0b"), new Guid("fc33e1bf-8402-4b3d-8771-3bea47d59fc3"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(846), "OnePlusOne", "House", 65m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(847) },
                    { new Guid("5a96da49-0647-4a0e-a2b6-42f108794062"), new Guid("9b788cb6-a8ee-44ba-96e2-790cfcde513b"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(668), "FiveKK", "Roomates", 106m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(669) },
                    { new Guid("5bd34dd2-fb6d-4000-b74b-35b8e6842b4f"), new Guid("be681d11-bc62-4f7f-be05-de59862bb1c2"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1318), "OnePlusOne", "Atelier", 62m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1318) },
                    { new Guid("61fdb9e1-2cd1-4719-ac0a-8e9f506b7d0e"), new Guid("da3c2130-ab7d-4817-9332-752fc49614cc"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(696), "FiveKK", "Atelier", 55m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(696) },
                    { new Guid("62656dad-a7d0-4097-a62e-c4be1df3c0fe"), new Guid("50572853-468d-428e-a5c1-c71f38ce9f8c"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(610), "TwoKK", "Flat", 57m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(611) },
                    { new Guid("62c84ce5-447e-4b94-bd7a-ff89281ffc9f"), new Guid("9e454efa-c899-42b3-8b12-ace7f2c7e6d9"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(931), "TwoPlusOne", "Atelier", 91m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(932) },
                    { new Guid("65129386-9f28-4761-b8a3-becb5bb2743a"), new Guid("30473e7b-a456-4256-8a7b-53f36d3971dc"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(227), "ThreeKK", "Flat", 38m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(228) },
                    { new Guid("655faf67-9d50-4bb7-a5a3-114952dd99cf"), new Guid("44fa649e-6997-48d8-81de-b78646d3d559"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(454), "TwoPlusOne", "Atelier", 105m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(455) },
                    { new Guid("66f479cc-8ef8-4e8c-8894-5e756bd897c9"), new Guid("63cd2104-3f58-442b-a2e0-49288a701d52"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(212), "FourPlusOne", "House", 64m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(213) },
                    { new Guid("6b083b1e-6a3d-4a4b-a366-bc895f602a45"), new Guid("b53feb0f-3f03-443b-b339-de58f95c1738"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(916), "FourKK", "House", 107m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(917) },
                    { new Guid("6d0a1b7c-da79-4abe-93b2-6e675f383c35"), new Guid("3c4fa351-fa76-4df9-93d8-4b5d6e2cf76f"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1041), "TwoKK", "Roomates", 103m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1042) },
                    { new Guid("702ff02b-a04f-439b-8964-6e30f288ce7c"), new Guid("078b9413-a1f2-40ec-984b-e6b9c197e443"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(241), "FourKK", "Apartman", 108m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(242) },
                    { new Guid("71c052f2-784a-4d28-b91e-d3beaac1234d"), new Guid("f31b9104-29eb-4454-9f70-dc34f0e777e6"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(255), "ThreeKK", "Apartman", 20m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(256) },
                    { new Guid("745dd08c-b454-40f0-a67b-d2c8e058c254"), new Guid("cc13b9fe-4073-4bed-bc4a-197a1b1b21b4"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(594), "FiveKK", "Flat", 90m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(594) },
                    { new Guid("748c929b-c877-482e-9336-f578ebe174b4"), new Guid("728d4796-0e64-4b0d-8434-4ac08d254529"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(775), "TwoKK", "House", 25m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(775) },
                    { new Guid("76df5240-55ed-4558-8874-520414369826"), new Guid("ebbbe892-7e8d-4b1d-9ac9-20f7e5684a3c"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1379), "FourKK", "Apartman", 53m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1380) },
                    { new Guid("78285cda-477b-477e-9098-88048b276070"), new Guid("06af0f8f-18b9-445d-9005-5a30aaadd97e"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(902), "FourPlusOne", "Atelier", 66m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(903) },
                    { new Guid("78f9315a-3b6c-49f0-b5b3-42eef0bcd3e0"), new Guid("24609037-f19c-4b6d-8b1a-92d07c3c6503"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1507), "TwoKK", "Flat", 24m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1508) },
                    { new Guid("7c05d140-6f38-42ca-842f-4e97ea6241a5"), new Guid("5bd55e38-9f18-42ee-b7b1-5a66569b17c6"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1069), "TwoPlusOne", "Atelier", 80m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1070) },
                    { new Guid("8622efa0-c0ad-45c7-8e37-84420e291fab"), new Guid("2fbdac33-d345-47e9-9ddf-5279472cb551"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1521), "ThreeKK", "Atelier", 71m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1522) },
                    { new Guid("8804a143-bfa6-4f08-9696-a48d3da816ef"), new Guid("910345d7-488d-4c6e-b197-53a4ac9f0dca"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1450), "FivePlusOne", "Atelier", 46m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1451) },
                    { new Guid("886fea3f-09bc-4be4-8366-19795659b7be"), new Guid("c917b4d2-cc4f-4dbe-94d6-7efb5112c3b9"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1204), "ThreePlusOne", "Flat", 47m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1205) },
                    { new Guid("8cf21c23-8c5e-4dba-b59a-d83031a4c1a2"), new Guid("35944f10-8548-4647-8044-f03b495f359c"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1290), "TwoPlusOne", "Atelier", 86m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1291) },
                    { new Guid("91856718-4f87-4c99-a1b5-503e40157beb"), new Guid("80298422-2f86-4751-9949-ad05cccd560f"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(639), "FourKK", "Apartman", 22m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(639) },
                    { new Guid("91cbc50c-7eb5-4a29-a16a-468bd0a27a52"), new Guid("71b8c789-3460-437c-ac85-7255c1b342df"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(468), "OneKK", "House", 104m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(469) },
                    { new Guid("93572726-ee9d-472d-8cba-2586173f57b0"), new Guid("a901c38b-0b67-4bb1-b275-0a88bb986202"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1190), "FivePlusOne", "Flat", 44m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1191) },
                    { new Guid("935aa974-0ab5-4882-8395-cce0279a4da0"), new Guid("8515d885-ed6e-4f79-a850-1fb4d99a31af"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(789), "FourKK", "Flat", 78m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(790) },
                    { new Guid("94d22e0d-1483-47c5-8906-7950d4185d67"), new Guid("181bbf37-b735-41b1-86cf-2d4632ab8e05"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(625), "ThreeKK", "House", 53m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(626) },
                    { new Guid("95e663ad-9730-43e3-86eb-9dd41f93e9e3"), new Guid("ef5963f8-542f-47f5-bcb9-944b67acb615"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1234), "FiveKK", "Flat", 77m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1235) },
                    { new Guid("994271d8-cc69-498e-ad3c-4293fbc88f28"), new Guid("940eca52-2cbb-4680-8c5b-64e848be9beb"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(439), "TwoPlusOne", "Apartman", 98m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(440) },
                    { new Guid("99970d18-b7ff-4f89-8893-845e4b59b216"), new Guid("646616d8-63a3-4cea-964c-5365cef14c97"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(297), "FourKK", "Atelier", 82m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(298) },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2076), "TwoKK", "Flat", 40.0m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2077) },
                    { new Guid("a0b1db32-46f9-4d65-9db6-79d111f3fc99"), new Guid("e992a882-6254-4598-8aa4-221921d6c0b0"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1303), "FivePlusOne", "Apartman", 44m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1304) },
                    { new Guid("a1816a5a-962e-4ae5-ba8a-eb85d03d5064"), new Guid("ddfee6b7-78bd-4c87-b4b0-7b76a942f062"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1422), "ThreePlusOne", "Roomates", 100m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1423) },
                    { new Guid("a1980ff2-50d6-4c1d-a244-764e2959dc92"), new Guid("2cbca316-d307-45d2-8c10-8c3b4f56e1a5"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(944), "FiveKK", "House", 31m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(944) },
                    { new Guid("a6151fe7-18f4-4a72-a304-f1cead54d82f"), new Guid("73c4973a-1bc9-46aa-bac3-937c26288c04"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(723), "FiveKK", "Atelier", 69m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(724) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2081), "ThreePlusOne", "Flat", 85.0m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2082) },
                    { new Guid("aed0eb63-7b4d-4b1e-a8ac-6e895c1b0d85"), new Guid("e10047dd-51ec-4ca6-96d9-f2f4109ecb71"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(381), "FiveKK", "Apartman", 44m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(382) },
                    { new Guid("b06d433c-d67f-4d2b-bcd0-fe7f8d515721"), new Guid("78dc5c45-6322-48ee-901c-9085cbcad45e"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(577), "TwoKK", "Apartman", 41m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(578) },
                    { new Guid("b2bf31fb-b46f-438b-9bf7-c6b9dedf24a3"), new Guid("1dc237a3-81d9-4248-b7a2-3cc7387fbbd4"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(525), "TwoPlusOne", "Flat", 58m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(525) },
                    { new Guid("b2ed2722-7d9e-4ede-85f4-20bad158d181"), new Guid("4a5878fe-d516-4ec2-94a8-4d040dc6c256"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1276), "TwoKK", "House", 36m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1276) },
                    { new Guid("b36489dd-3eee-4e7a-a5ee-f5a1d21b2992"), new Guid("9a987b21-4bec-4f7d-97de-6e226b2de3a0"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1055), "OnePlusOne", "Roomates", 82m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1056) },
                    { new Guid("b8ff1bb9-3977-457b-a4e8-8d18f1a546db"), new Guid("a6b5b0c3-b190-4ffa-97d0-71677642524f"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(195), "FivePlusOne", "Flat", 108m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(196) },
                    { new Guid("b94a8d6e-9929-4ce6-8d65-9a2e0f4238dc"), new Guid("5d4117b2-ab62-4a96-965f-38d464b1ea4d"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(10), "ThreePlusOne", "House", 61m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(10) },
                    { new Guid("ba03b618-5e71-416a-8748-a62dc44c6919"), new Guid("93546649-142e-4374-afcf-35e757fe8e0c"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1176), "FourPlusOne", "Apartman", 63m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1177) },
                    { new Guid("c0562ecd-acd6-43e3-8ccd-e8d8628191c1"), new Guid("cb7c1037-53e6-4608-930a-eface4d8599c"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1493), "FourPlusOne", "Atelier", 76m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1494) },
                    { new Guid("c1d7b1c6-812d-4f94-b9c7-c3ee5282e2b5"), new Guid("d2aa4ec0-c93e-4535-942c-fd6c97897f60"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1013), "ThreeKK", "Flat", 79m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1014) },
                    { new Guid("c40906ce-7d79-445a-be5a-b6cdaaea7866"), new Guid("02745a1b-4f28-4335-a85e-a6d5138d933f"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(496), "FiveKK", "Atelier", 76m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(497) },
                    { new Guid("c551fdbd-7967-4f9f-8dc2-f7f10bd0137c"), new Guid("af63d7ab-79a3-4162-92b6-fda4b07326fa"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(998), "TwoKK", "Apartman", 98m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(999) },
                    { new Guid("c5bc800c-8c69-4bd8-ab03-bf74cd42c5e2"), new Guid("141412be-424b-4421-9d0b-9bb123b6afe6"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(40), "FourKK", "Apartman", 66m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(41) },
                    { new Guid("c6172569-0a5a-4484-ad4e-2dbe35584ecf"), new Guid("36c0975a-03b7-49d0-b783-73d426f18786"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(874), "FourKK", "Flat", 61m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(875) },
                    { new Guid("c6392336-7170-4e36-99e4-7e05cf98ac80"), new Guid("de542311-7cfa-4988-bcca-f877f70fdc8d"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(26), "FivePlusOne", "Flat", 26m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(27) },
                    { new Guid("cba5b585-6025-4989-9002-0669f123692a"), new Guid("eb3d9316-73f8-40d7-b3c1-f0a7b785a9f5"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(761), "FiveKK", "Roomates", 42m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(762) },
                    { new Guid("d24591e5-966a-48b8-b485-122ee7759073"), new Guid("82fafb1c-e29e-4f90-8cf7-82e9d550e5ca"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1247), "TwoKK", "Flat", 88m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1248) },
                    { new Guid("d682da32-ca07-4281-bc50-12bfd2c5082c"), new Guid("bd62915c-6580-40f1-b501-4b5e65e8f779"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1677), "TwoPlusOne", "Apartman", 84m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1677) },
                    { new Guid("db84aa98-4238-4c4f-b3ae-a3252eb0d51e"), new Guid("dc782f9e-becc-43a7-9746-3d4c53689091"), new DateTime(2025, 7, 8, 12, 50, 40, 264, DateTimeKind.Local).AddTicks(9986), "FourPlusOne", "Atelier", 95m, new DateTime(2025, 7, 8, 12, 50, 40, 264, DateTimeKind.Local).AddTicks(9987) },
                    { new Guid("dbac6303-f63b-4aeb-bb25-8eb7d4df91f3"), new Guid("a7e1f1e0-1569-43a1-aea3-a729665c1610"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(818), "OnePlusOne", "Apartman", 75m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(819) },
                    { new Guid("dcff244e-e048-4913-9e0c-7d3c2d4435be"), new Guid("262a3bf7-e84f-4eae-957b-ac911bf3940b"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(165), "ThreePlusOne", "Apartman", 68m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(165) },
                    { new Guid("de02a30d-8032-4b61-9568-36065ce90656"), new Guid("61740cdb-8a1b-42de-a62a-7ec3ac7382fc"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(57), "TwoKK", "House", 59m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(58) },
                    { new Guid("e0c757d0-bc5f-4eb5-a8ec-c6fe353dea3e"), new Guid("6f95e6b9-5a6f-40af-ab33-b8d1313dbc49"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(539), "FiveKK", "House", 79m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(540) },
                    { new Guid("e2c57a8f-6e58-4db0-a3b5-821d51110ab2"), new Guid("39c7a962-7453-4216-b7b9-8728ba136d12"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(395), "ThreeKK", "Apartman", 36m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(396) },
                    { new Guid("e3254ccd-10eb-445a-b6ae-6d134d078f0c"), new Guid("5a33bd9d-5099-4f3c-bc24-1532031f94ae"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(832), "OnePlusOne", "Atelier", 104m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(833) },
                    { new Guid("e688f42e-68e7-4baa-903d-91499af6a379"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2071), "OneKK", "House", 30.0m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2072) },
                    { new Guid("ecda9ac5-3d3d-4faa-a42b-15ad2500c51f"), new Guid("3fef98b6-5808-43e6-85c3-b917a0d8979a"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(270), "OnePlusOne", "Roomates", 39m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(271) },
                    { new Guid("ed49e1ba-d6b3-4e58-acea-c72cc35efce0"), new Guid("5b94d906-9414-4c3b-99ff-914987194e4b"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1536), "FourPlusOne", "Atelier", 92m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1537) },
                    { new Guid("f29ac9a0-6dd3-47ee-8fb2-0320e947b247"), new Guid("00a6a112-6782-4ede-83a0-230c9909cac9"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1028), "FourPlusOne", "Roomates", 52m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1028) },
                    { new Guid("f3156d5f-4bcf-4dfb-ab1a-c727f0f88c9e"), new Guid("71c83019-e77e-4576-af68-8521161e48a1"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(888), "FivePlusOne", "House", 58m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(889) },
                    { new Guid("fd402fba-bb0b-4376-ac2f-29598df51e53"), new Guid("936b9dbd-a456-4a56-b4ae-1db84965781f"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1113), "TwoKK", "House", 68m, new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1114) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "ID", "AdvertisementID", "CreatedAt", "EndDate", "LandlordId", "StartDate", "Status", "TenantId", "UpdatedAt" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2127), new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 2, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2128) });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AdvertisementRealEstateId", "City", "CreatedAt", "PostalCode", "Street", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("01237476-0180-493b-bbea-6fddbfa5d69e"), new Guid("0c18b8db-f6ff-4067-a5b7-c3bdc6aa33f4"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1636), "46749", "Tyršova", "27", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1637) },
                    { new Guid("0178648a-2045-4696-bb8f-fa3ffadf1b88"), new Guid("3a43ff74-cb83-4ab4-a2b9-02755a1e95c6"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(369), "41536", "Nádražní", "137", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(370) },
                    { new Guid("02c4ec03-aeee-4e33-b8d3-99c687a8b606"), new Guid("3b1c881d-f909-440c-9dec-d6eb26a0d0c1"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1221), "32005", "Jiráskova", "86", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1222) },
                    { new Guid("030feb19-f9c0-454b-a739-2758fb16b81f"), new Guid("61fdb9e1-2cd1-4719-ac0a-8e9f506b7d0e"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(698), "82067", "Smetanova", "39", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(699) },
                    { new Guid("0367d4df-0a9e-49d8-b904-6427e619725b"), new Guid("d682da32-ca07-4281-bc50-12bfd2c5082c"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1679), "51929", "Hlavní", "122", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1679) },
                    { new Guid("03b4f0c4-9c71-4371-9966-021a3e1133b0"), new Guid("8cf21c23-8c5e-4dba-b59a-d83031a4c1a2"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1292), "62446", "Masarykova", "138", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1293) },
                    { new Guid("03f137dd-2d4b-401f-a868-fa75d068d659"), new Guid("425539c9-217e-4961-9d4f-37d50bc32755"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1410), "75314", "Nádražní", "11", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1411) },
                    { new Guid("09e7cb39-dbf8-4c67-9fc4-f45779779739"), new Guid("65129386-9f28-4761-b8a3-becb5bb2743a"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(229), "61813", "Tyršova", "51", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(230) },
                    { new Guid("11516077-f1e5-477c-8189-99e995dc5933"), new Guid("ba03b618-5e71-416a-8748-a62dc44c6919"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1178), "58698", "Hlavní", "35", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1179) },
                    { new Guid("123705f7-21a8-4220-b23c-d5da6484c714"), new Guid("a0b1db32-46f9-4d65-9db6-79d111f3fc99"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1305), "92138", "Jiráskova", "5", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1306) },
                    { new Guid("16dcb4a9-e19b-4fe6-838d-c52cf44c8457"), new Guid("99999999-9999-9999-9999-999999999999"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2099), "12800", "Rašínovo nábřeží", "12", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2100) },
                    { new Guid("1f2ce55b-1902-472b-94ab-4beaf37b09fe"), new Guid("5a474b30-6a2d-4daa-a76b-17df6d32ba0b"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(848), "69019", "Tyršova", "62", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(849) },
                    { new Guid("2316b7d6-d281-4f34-83c5-e4cfc26644c3"), new Guid("94d22e0d-1483-47c5-8906-7950d4185d67"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(627), "65170", "Hlavní", "127", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(628) },
                    { new Guid("264fda3c-c96b-4d96-a01b-a3cab8e6ed2b"), new Guid("8622efa0-c0ad-45c7-8e37-84420e291fab"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1523), "32880", "Hlavní", "111", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1524) },
                    { new Guid("2749c81d-b410-4818-b064-1d0fca073e3d"), new Guid("ecda9ac5-3d3d-4faa-a42b-15ad2500c51f"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(272), "99689", "Jiráskova", "59", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(273) },
                    { new Guid("356d55e9-fdf6-4bdb-965d-5b2115788a05"), new Guid("0f92b1aa-c65d-4d64-9727-829fe8b420c0"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1606), "64504", "Masarykova", "52", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1607) },
                    { new Guid("36f4ef89-297e-4013-b0d8-6ca02d0f5b3f"), new Guid("ed49e1ba-d6b3-4e58-acea-c72cc35efce0"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1538), "12565", "Hlavní", "32", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1539) },
                    { new Guid("3c3b81d1-df19-482d-8ba8-43e91f6822c6"), new Guid("495bbf0a-1f3f-477a-b723-9de5ba5b5950"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1263), "45368", "Tyršova", "61", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1264) },
                    { new Guid("3c8c5933-c2ba-4640-a45d-28d9dc17eb28"), new Guid("38f17407-849c-48ca-9136-621fed82164b"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(427), "89755", "Masarykova", "62", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(428) },
                    { new Guid("3d70386f-3f8e-4318-95bd-35f169f87d00"), new Guid("22b8f992-dc68-4497-847c-084adcbfbdf9"), "Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1466), "68508", "Dlouhá", "80", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1467) },
                    { new Guid("3fe8c105-dc94-4176-b673-30321b3cd16d"), new Guid("34adfda8-e6db-4c3a-a5e2-74fb867cd8d3"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1664), "20202", "Smetanova", "57", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1665) },
                    { new Guid("411da551-7714-488c-890d-8d95f156e123"), new Guid("519dcd8d-0ad8-4cd1-b03a-39f71a92f916"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1565), "80126", "Jiráskova", "103", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1566) },
                    { new Guid("46e40bb4-f000-42ca-b05e-50b63a954548"), new Guid("b2bf31fb-b46f-438b-9bf7-c6b9dedf24a3"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(527), "87702", "Masarykova", "73", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(527) },
                    { new Guid("47ee4e06-d0df-4faa-bc53-3339d721069c"), new Guid("b8ff1bb9-3977-457b-a4e8-8d18f1a546db"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(198), "58251", "Nádražní", "53", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(199) },
                    { new Guid("4d856a58-4ae9-4930-8303-5ef0e5b8f967"), new Guid("472a2338-8387-4f1a-813a-ab7f976a6ec5"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(181), "93330", "Tyršova", "75", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(182) },
                    { new Guid("556704fb-5b41-4f09-80dd-cce04205aff7"), new Guid("6d0a1b7c-da79-4abe-93b2-6e675f383c35"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1043), "79343", "Nádražní", "130", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1044) },
                    { new Guid("5776e6b9-333c-4e59-8a67-75f4de6f31ea"), new Guid("14f7c1e2-4d7f-4db8-9ad3-0d9a419b627c"), "Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(286), "94582", "Smetanova", "27", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(287) },
                    { new Guid("5e27d092-dfb1-46e6-80aa-0c76dcd1e407"), new Guid("35115eb5-c91c-4af9-8944-5d8ce36506b1"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(862), "71343", "Dlouhá", "9", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(863) },
                    { new Guid("5ff8f592-0717-4fa0-84ab-3f13144c5cad"), new Guid("3a24a72c-0222-45c2-8db4-356d05eab1d2"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1621), "22047", "Nádražní", "87", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1622) },
                    { new Guid("63328bec-07d0-4054-8726-f49f10667c87"), new Guid("655faf67-9d50-4bb7-a5a3-114952dd99cf"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(456), "38722", "Jiráskova", "60", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(457) },
                    { new Guid("633dad16-e9be-424d-803f-ad88df8736eb"), new Guid("c5bc800c-8c69-4bd8-ab03-bf74cd42c5e2"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(42), "34524", "Hlavní", "78", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(43) },
                    { new Guid("69e046e9-682d-425a-be48-42683f17af01"), new Guid("702ff02b-a04f-439b-8964-6e30f288ce7c"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(243), "70977", "Masarykova", "33", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(244) },
                    { new Guid("6b0f28ae-d22d-48bf-9003-67db1fef154f"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2102), "60200", "U školy", "45", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2103) },
                    { new Guid("74183313-690e-4742-9bfb-5fb4de9e61d5"), new Guid("3d6082bd-5786-4a70-b5f8-fcb72d5c85b0"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1693), "69418", "Hlavní", "82", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1694) },
                    { new Guid("748bab09-ee04-4191-9e9f-b480b3698e44"), new Guid("c0562ecd-acd6-43e3-8ccd-e8d8628191c1"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1495), "21548", "Tyršova", "91", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1496) },
                    { new Guid("74be0bab-e808-4ef4-83ca-fc18e16e7730"), new Guid("41f9534f-2d29-4c03-a5d1-0c88ec19c658"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(354), "96783", "Nádražní", "129", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(354) },
                    { new Guid("7573229b-b3b9-46d8-ae1c-1a034f3b18fc"), new Guid("b06d433c-d67f-4d2b-bcd0-fe7f8d515721"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(579), "76549", "Jiráskova", "14", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(580) },
                    { new Guid("75e914ed-107f-4ce3-bf69-8b600365d35f"), new Guid("99970d18-b7ff-4f89-8893-845e4b59b216"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(299), "69600", "Masarykova", "105", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(300) },
                    { new Guid("760f9f47-5248-424a-84a7-ccaf46cfde6b"), new Guid("71c052f2-784a-4d28-b91e-d3beaac1234d"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(257), "50476", "Smetanova", "45", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(258) },
                    { new Guid("766d9795-d4df-4689-92b9-974ae011ae36"), new Guid("562de589-8958-4020-af36-79de7dee8b5a"), "Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1098), "30430", "Školní", "30", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1099) },
                    { new Guid("78e0da91-b6c4-4ee4-b8a6-712e7f29f719"), new Guid("6b083b1e-6a3d-4a4b-a366-bc895f602a45"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(919), "82466", "Hlavní", "140", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(919) },
                    { new Guid("7afc3ba4-97a3-4a8c-9840-1b867fd37eba"), new Guid("c551fdbd-7967-4f9f-8dc2-f7f10bd0137c"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1000), "65202", "Masarykova", "134", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1001) },
                    { new Guid("7cb1303f-1814-4b3a-8375-5cb62b94fe44"), new Guid("994271d8-cc69-498e-ad3c-4293fbc88f28"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(441), "73022", "Smetanova", "133", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(442) },
                    { new Guid("7f247608-f81a-4687-ba91-9de31d3d9c02"), new Guid("7c05d140-6f38-42ca-842f-4e97ea6241a5"), "Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1071), "36306", "Nádražní", "96", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1072) },
                    { new Guid("808a8fe9-0735-4fe7-9751-557b39fccaa4"), new Guid("a6151fe7-18f4-4a72-a304-f1cead54d82f"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(725), "13680", "Tyršova", "54", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(726) },
                    { new Guid("8098e4a0-26f3-426a-bf23-238de7646c1b"), new Guid("dbac6303-f63b-4aeb-bb25-8eb7d4df91f3"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(821), "85514", "Smetanova", "3", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(821) },
                    { new Guid("817eeac5-bd55-4383-825e-3073c9801f00"), new Guid("95e663ad-9730-43e3-86eb-9dd41f93e9e3"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1236), "68382", "Smetanova", "14", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1237) },
                    { new Guid("845f5fb8-0ec3-4eeb-aade-03ef7512735f"), new Guid("17b3cb48-24e7-49a3-8225-d5136bf22dbc"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1649), "29479", "Nádražní", "59", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1650) },
                    { new Guid("8868f66a-418e-46fe-ab5e-448ab773c5c3"), new Guid("d24591e5-966a-48b8-b485-122ee7759073"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1249), "68457", "Školní", "40", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1250) },
                    { new Guid("9121d9a0-39e2-4b3e-911c-9920243cf6d5"), new Guid("f3156d5f-4bcf-4dfb-ab1a-c727f0f88c9e"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(890), "15807", "Hlavní", "130", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(891) },
                    { new Guid("92688465-0f36-46df-b47b-b82c26eb72cb"), new Guid("c40906ce-7d79-445a-be5a-b6cdaaea7866"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(498), "52680", "Jiráskova", "123", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(499) },
                    { new Guid("92ae0ae8-65c9-4de3-89b1-fa0ae9856bc3"), new Guid("935aa974-0ab5-4882-8395-cce0279a4da0"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(791), "19686", "Smetanova", "144", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(792) },
                    { new Guid("9847c9b0-f045-44d3-bc97-13dab3a0b408"), new Guid("93572726-ee9d-472d-8cba-2586173f57b0"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1192), "78661", "Smetanova", "66", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1193) },
                    { new Guid("986d86e8-b265-4ee4-b4f2-6f37adfcba8d"), new Guid("4c2f0b34-3538-414b-8c33-449a05f7ec52"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(413), "77261", "Jiráskova", "147", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(414) },
                    { new Guid("9d7962b0-c169-4b11-b1b6-ef84cc5fd217"), new Guid("f29ac9a0-6dd3-47ee-8fb2-0320e947b247"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1030), "44416", "Jiráskova", "60", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1030) },
                    { new Guid("9e0f0f9d-5665-4325-8b18-5dd865db9247"), new Guid("012d18dd-b679-448d-8973-901f903f7c72"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(150), "32284", "Nádražní", "79", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(151) },
                    { new Guid("a0b6bbb0-2422-4721-bf8d-f6acaa8797bf"), new Guid("c6172569-0a5a-4484-ad4e-2dbe35584ecf"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(877), "51846", "Hlavní", "136", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(877) },
                    { new Guid("a0f2f253-19a6-4e02-be5a-39e045c304e7"), new Guid("b36489dd-3eee-4e7a-a5ee-f5a1d21b2992"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1057), "12721", "Tyršova", "137", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1058) },
                    { new Guid("a1585bf8-82f8-49d4-adf6-3c7d5eea9716"), new Guid("78f9315a-3b6c-49f0-b5b3-42eef0bcd3e0"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1509), "16205", "Tyršova", "138", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1510) },
                    { new Guid("a344d553-352b-4afa-90fd-874754613389"), new Guid("745dd08c-b454-40f0-a67b-d2c8e058c254"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(597), "89649", "Hlavní", "7", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(598) },
                    { new Guid("af217c28-48ee-48e8-82cf-6f08a0bf8038"), new Guid("886fea3f-09bc-4be4-8366-19795659b7be"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1207), "68946", "Smetanova", "142", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1207) },
                    { new Guid("af37fe30-645a-4749-a303-7c99ce8fb73e"), new Guid("4528da45-ab0f-458f-9704-78b22498ed58"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(513), "52126", "Dlouhá", "52", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(513) },
                    { new Guid("b2bd07fb-ebd2-4aae-a01b-539e673abb2b"), new Guid("91cbc50c-7eb5-4a29-a16a-468bd0a27a52"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(470), "10814", "Dlouhá", "125", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(471) },
                    { new Guid("b7412789-c68b-4dc6-8ebd-33f3d157c495"), new Guid("2feb228e-460e-4100-91c9-a4e49e3442be"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(655), "16955", "Školní", "87", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(656) },
                    { new Guid("b865cbe5-893f-4ea4-8e33-d6a4170675b2"), new Guid("269642ff-5840-4b4a-a0ed-c3daa450b83c"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1439), "29747", "Hlavní", "11", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1440) },
                    { new Guid("bb4a80f0-0bae-4fcb-b85f-40f670b6271e"), new Guid("db84aa98-4238-4c4f-b3ae-a3252eb0d51e"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 264, DateTimeKind.Local).AddTicks(9990), "34280", "Masarykova", "123", new DateTime(2025, 7, 8, 12, 50, 40, 264, DateTimeKind.Local).AddTicks(9991) },
                    { new Guid("bc030556-51ba-478f-835a-0afd301b32ac"), new Guid("1d83047e-5a9c-4124-9157-d26b6475c527"), "Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(685), "78162", "Masarykova", "33", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(686) },
                    { new Guid("bc5ea7c3-8882-4970-9bbb-2de5584e6315"), new Guid("1dd25cdb-7ffc-42ef-b551-c7941cd0758d"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1707), "24219", "Hlavní", "12", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1707) },
                    { new Guid("be779840-ca74-4d82-8a5c-3925c20baf7d"), new Guid("62c84ce5-447e-4b94-bd7a-ff89281ffc9f"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(933), "15066", "Dlouhá", "69", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(934) },
                    { new Guid("c03d881f-07ba-40eb-bdf9-958e5e0e383b"), new Guid("e2c57a8f-6e58-4db0-a3b5-821d51110ab2"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(398), "37252", "Tyršova", "141", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(398) },
                    { new Guid("c1c0a2d1-fb4b-4451-a552-b841d0e3e159"), new Guid("b2ed2722-7d9e-4ede-85f4-20bad158d181"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1278), "51080", "Nádražní", "17", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1278) },
                    { new Guid("c2a14591-50cd-4301-8d7e-cfbd5ad2d9db"), new Guid("62656dad-a7d0-4097-a62e-c4be1df3c0fe"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(612), "23565", "Jiráskova", "131", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(613) },
                    { new Guid("c5558141-f1da-4041-a52f-3fae21de9fae"), new Guid("aed0eb63-7b4d-4b1e-a8ac-6e895c1b0d85"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(383), "99068", "Hlavní", "130", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(384) },
                    { new Guid("c6550990-c0af-4590-b765-46266fee3f94"), new Guid("e0c757d0-bc5f-4eb5-a8ec-c6fe353dea3e"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(541), "84095", "Masarykova", "72", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(542) },
                    { new Guid("c6f23f52-55a6-49cc-b5c0-5d3cb38a7cb0"), new Guid("5a96da49-0647-4a0e-a2b6-42f108794062"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(670), "53153", "Dlouhá", "7", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(671) },
                    { new Guid("c98e7ec5-7a5b-4235-b729-bfc1ba821e7d"), new Guid("1f35fb82-e151-4ecb-8cac-c99bcf0a10f6"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(315), "42691", "Nádražní", "85", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(316) },
                    { new Guid("ca848208-84a7-4464-83cd-c614f6231aae"), new Guid("78285cda-477b-477e-9098-88048b276070"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(904), "69416", "Jiráskova", "44", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(905) },
                    { new Guid("ce382761-72da-4d9b-af75-23e1cef29452"), new Guid("c1d7b1c6-812d-4f94-b9c7-c3ee5282e2b5"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1015), "88625", "Školní", "43", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1016) },
                    { new Guid("d1a2ed0d-8e6b-4f90-a05c-f738310c304d"), new Guid("fd402fba-bb0b-4376-ac2f-29598df51e53"), "Olomouc", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1116), "38671", "Jiráskova", "74", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1117) },
                    { new Guid("d351d97f-11be-41e0-b3ee-589d924f3a8b"), new Guid("a1980ff2-50d6-4c1d-a244-764e2959dc92"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(946), "41046", "Dlouhá", "68", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(946) },
                    { new Guid("d53c1921-f755-4913-b277-85e8a498425d"), new Guid("8804a143-bfa6-4f08-9696-a48d3da816ef"), "Ostrava", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1452), "84247", "Tyršova", "80", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1453) },
                    { new Guid("d62f9966-a03e-46ff-bf2b-ad0e1a3bbca2"), new Guid("b94a8d6e-9929-4ce6-8d65-9a2e0f4238dc"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(12), "69927", "Masarykova", "9", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(13) },
                    { new Guid("db4f28a7-553f-4dc9-9330-7e9c198288dc"), new Guid("dcff244e-e048-4913-9e0c-7d3c2d4435be"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(167), "90210", "Jiráskova", "145", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(168) },
                    { new Guid("dd7cbdb2-7572-4fc5-b39d-49bbd84139ba"), new Guid("3dd28fe1-bae1-45cd-83f5-3eec71eed01b"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(485), "74459", "Tyršova", "28", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(485) },
                    { new Guid("de73c24c-7557-4f2c-8395-8b858998e7ad"), new Guid("76df5240-55ed-4558-8874-520414369826"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1382), "76465", "Nádražní", "83", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1382) },
                    { new Guid("dfce5ee4-21cb-4f0f-a14f-ba5120fc0d95"), new Guid("59059e05-a5aa-459e-a7c9-b0e7d8c9fe71"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1334), "11747", "Dlouhá", "134", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1335) },
                    { new Guid("e021d07a-ad56-4dd2-9940-e85bb428cba5"), new Guid("a1816a5a-962e-4ae5-ba8a-eb85d03d5064"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1424), "77413", "Dlouhá", "97", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1425) },
                    { new Guid("e0d77047-a59d-4791-8b57-1ae96cad76e5"), new Guid("91856718-4f87-4c99-a1b5-503e40157beb"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(641), "36990", "Smetanova", "138", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(642) },
                    { new Guid("e619137b-0cc8-4409-a5b0-590bd5ea03c7"), new Guid("e688f42e-68e7-4baa-903d-91499af6a379"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2095), "12000", "Náměstí Míru", "5", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2096) },
                    { new Guid("e7553509-19e6-4d92-abc7-2be02922121f"), new Guid("66f479cc-8ef8-4e8c-8894-5e756bd897c9"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(214), "44432", "Dlouhá", "141", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(215) },
                    { new Guid("e8929a9d-c90c-4397-b6e5-f8f201ee7c4f"), new Guid("08148619-caa4-4be7-8583-14977aff84cf"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1163), "91874", "Tyršova", "137", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1164) },
                    { new Guid("eb8fe867-d01f-4929-8bfb-8cdf1cad3e8d"), new Guid("54f4472f-1f58-4175-b3f1-18c4dea9f708"), "Plzeň", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(806), "32798", "Nádražní", "18", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(807) },
                    { new Guid("ecc5c333-e2f5-49f0-967c-59459b1f30da"), new Guid("1673d387-42e3-444f-8763-d22c6dd84227"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1395), "29380", "Jiráskova", "93", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1396) },
                    { new Guid("ee01d08c-8df3-4e00-b9d3-38d33a541cf3"), new Guid("1d47de8f-7176-492a-9cbd-1d8d57a6a867"), "Pardubice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1086), "98793", "Hlavní", "97", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1087) },
                    { new Guid("eeb7d63b-15db-42aa-b3b5-2435ddce9f32"), new Guid("c6392336-7170-4e36-99e4-7e05cf98ac80"), "Praha", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(28), "90192", "Masarykova", "113", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(29) },
                    { new Guid("f2554e0e-3e61-40bb-b68f-5e85cff2a199"), new Guid("e3254ccd-10eb-445a-b6ae-6d134d078f0c"), "Hradec Králové", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(834), "93358", "Tyršova", "50", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(835) },
                    { new Guid("fadd20bb-d76f-4a22-9f80-3ace95754a54"), new Guid("42d115cf-257f-408d-adfc-062acdd4337f"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1481), "21225", "Školní", "137", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1482) },
                    { new Guid("fae7ff2d-c51f-4617-8e44-1a15250ad1c7"), new Guid("de02a30d-8032-4b61-9568-36065ce90656"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(60), "70916", "Masarykova", "105", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(61) },
                    { new Guid("feb4aed9-a219-41f2-9734-87966c95a6e6"), new Guid("0094c2a9-dc51-492a-9ef8-a4d4f3ef977d"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(712), "12226", "Tyršova", "62", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(713) },
                    { new Guid("fefc9da3-4dee-457c-9502-a8dd11f6fa13"), new Guid("748c929b-c877-482e-9336-f578ebe174b4"), "Liberec", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(777), "32630", "Jiráskova", "148", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(777) },
                    { new Guid("ff4b4639-c685-45b5-980c-b5a270030c4b"), new Guid("cba5b585-6025-4989-9002-0669f123692a"), "Zlín", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(763), "22017", "Školní", "29", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(764) },
                    { new Guid("ff4ea0dc-a705-4278-a051-24b295218e3e"), new Guid("0a862e22-f4c0-41ac-a3f6-61211b9deda2"), "Brno", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1552), "55770", "Smetanova", "49", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1553) },
                    { new Guid("ff982dcd-87b5-4b61-9028-f9d174bdef9c"), new Guid("5bd34dd2-fb6d-4000-b74b-35b8e6842b4f"), "České Budějovice", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1320), "52302", "Nádražní", "96", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(1321) }
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "ID", "Comment", "CreatedAt", "FromUserID", "Rating", "RentalID", "ToUserID", "UpdatedAt" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), "Velmi spolehlivý pronajímatel", new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2145), new Guid("22222222-2222-2222-2222-222222222222"), 5m, new Guid("44444444-4444-4444-4444-444444444444"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 8, 12, 50, 40, 265, DateTimeKind.Local).AddTicks(2146) });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AdvertisementRealEstateId",
                table: "Addresses",
                column: "AdvertisementRealEstateId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisementRealEstates_AdvertisementId",
                table: "AdvertisementRealEstates",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_References_FromUserID",
                table: "References",
                column: "FromUserID");

            migrationBuilder.CreateIndex(
                name: "IX_References_RentalID",
                table: "References",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "IX_References_ToUserID",
                table: "References",
                column: "ToUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_AdvertisementID",
                table: "Rentals",
                column: "AdvertisementID");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_LandlordId",
                table: "Rentals",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_TenantId",
                table: "Rentals",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "AdvertisementRealEstates");

            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
