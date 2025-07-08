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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "https://example.com/avatar1.png", 0m, new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(5937), "jan.novak@example.com", "Jan", true, "Novak", "hashedpassword1", 2, null, new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(5938) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, null, 0m, new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(5944), "eva.svobodova@example.com", "Eva", false, "Svobodova", null, 1, null, new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(5945) }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "ID", "Address", "CreatedAt", "Deposit", "Description", "ImageUrls", "IsShared", "PetsAllowed", "Price", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Náměstí Míru 5, Praha", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6083), 5000m, null, "[]", true, true, 15000, "Moderní byt v centru", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6084), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Rašínovo nábřeží 12, Praha 2", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6090), 6000m, null, "[]", false, false, 18000, "Byt 2+KK s výhledem na řeku", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6091), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "U školy 45, Brno", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6095), 8000m, null, "[]", false, true, 22000, "Velký byt 3+1 pro rodinu", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6096), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "AdvertisementRealEstates",
                columns: new[] { "ID", "AdvertisementId", "CreatedAt", "Disposition", "RentalType", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3016bba1-e20a-47f0-a7cb-de128dbd301d"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6118), "OneKK", "House", 30.0m, new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6119) },
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6123), "TwoKK", "Flat", 40.0m, new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6124) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6128), "ThreePlusOne", "Flat", 85.0m, new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6129) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "ID", "AdvertisementID", "CreatedAt", "EndDate", "LandlordId", "StartDate", "Status", "TenantId", "UpdatedAt" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6181), new DateTime(2026, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), 2, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6182) });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AdvertisementRealEstateId", "City", "CreatedAt", "PostalCode", "Street", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5928b0b6-1c2e-4311-b9be-4352d999e0a6"), new Guid("3016bba1-e20a-47f0-a7cb-de128dbd301d"), "Praha", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6145), "12000", "Náměstí Míru", "5", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6146) },
                    { new Guid("6866e5a4-bfcd-47e1-901e-050d120bc533"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Brno", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6154), "60200", "U školy", "45", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6155) },
                    { new Guid("cfd54c95-91ac-4d52-b0f5-3517de43c80f"), new Guid("99999999-9999-9999-9999-999999999999"), "Praha", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6149), "12800", "Rašínovo nábřeží", "12", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6150) }
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "ID", "Comment", "CreatedAt", "FromUserID", "Rating", "RentalID", "ToUserID", "UpdatedAt" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), "Velmi spolehlivý pronajímatel", new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6198), new Guid("22222222-2222-2222-2222-222222222222"), 5m, new Guid("44444444-4444-4444-4444-444444444444"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 8, 9, 45, 49, 262, DateTimeKind.Local).AddTicks(6199) });

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
