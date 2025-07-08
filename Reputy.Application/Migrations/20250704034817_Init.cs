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
                    Disposition = table.Column<int>(type: "int", nullable: false),
                    RentalType = table.Column<int>(type: "int", nullable: false),
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
                    { new Guid("11111111-1111-1111-1111-111111111111"), 0, "https://example.com/avatar1.png", 0m, new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1746), "jan.novak@example.com", "Jan", true, "Novak", "hashedpassword1", 2, null, new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1748) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 0, null, 0m, new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1755), "eva.svobodova@example.com", "Eva", false, "Svobodova", null, 1, null, new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1757) }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "ID", "Address", "CreatedAt", "Deposit", "Description", "ImageUrls", "IsShared", "PetsAllowed", "Price", "Title", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Náměstí Míru 5, Praha", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1916), 5000m, null, "[]", true, true, 15000, "Moderní byt v centru", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1918), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("77777777-7777-7777-7777-777777777777"), "Rašínovo nábřeží 12, Praha 2", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1925), 6000m, null, "[]", false, false, 18000, "Byt 2+KK s výhledem na řeku", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1927), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("88888888-8888-8888-8888-888888888888"), "U školy 45, Brno", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1933), 8000m, null, "[]", false, true, 22000, "Velký byt 3+1 pro rodinu", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1935), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.InsertData(
                table: "AdvertisementRealEstates",
                columns: new[] { "ID", "AdvertisementId", "CreatedAt", "Disposition", "RentalType", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("99999999-9999-9999-9999-999999999999"), new Guid("77777777-7777-7777-7777-777777777777"), new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1973), 4, 1, 40.0m, new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1975) },
                    { new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), new Guid("88888888-8888-8888-8888-888888888888"), new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1990), 5, 1, 85.0m, new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1992) },
                    { new Guid("cf51014d-7fb0-433e-9bc4-97c1b42a3cc6"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1966), 2, 2, 30.0m, new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(1967) }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "ID", "AdvertisementID", "CreatedAt", "EndDate", "LandlordId", "StartDate", "Status", "TenantId", "UpdatedAt" },
                values: new object[] { new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2063), new DateTime(2026, 7, 4, 0, 0, 0, 0, DateTimeKind.Local), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 4, 0, 0, 0, 0, DateTimeKind.Local), 2, new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2064) });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "AdvertisementRealEstateId", "City", "CreatedAt", "PostalCode", "Street", "StreetNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("155bf4ef-e3d7-4987-b7e1-b7836f0dd4df"), new Guid("99999999-9999-9999-9999-999999999999"), "Praha", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2022), "12800", "Rašínovo nábřeží", "12", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2023) },
                    { new Guid("46bf7244-7ee4-4414-b0de-76119d156855"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"), "Brno", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2027), "60200", "U školy", "45", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2028) },
                    { new Guid("fb419a08-1490-4069-adf8-a12113a7d128"), new Guid("cf51014d-7fb0-433e-9bc4-97c1b42a3cc6"), "Praha", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2015), "12000", "Náměstí Míru", "5", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2016) }
                });

            migrationBuilder.InsertData(
                table: "References",
                columns: new[] { "ID", "Comment", "CreatedAt", "FromUserID", "Rating", "RentalID", "ToUserID", "UpdatedAt" },
                values: new object[] { new Guid("55555555-5555-5555-5555-555555555555"), "Velmi spolehlivý pronajímatel", new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2089), new Guid("22222222-2222-2222-2222-222222222222"), 5m, new Guid("44444444-4444-4444-4444-444444444444"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 7, 4, 5, 48, 16, 805, DateTimeKind.Local).AddTicks(2090) });

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
