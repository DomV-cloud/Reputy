using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reputy.Domain.Entities;
using Reputy.Domain.Enums;

namespace Reputy.Application.DatabaseContext
{
    public class ReputyContext : DbContext
    {
        public static readonly Guid User1Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public static readonly Guid User2Id = Guid.Parse("22222222-2222-2222-2222-222222222222");

        public static readonly Guid Ad1Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        public static readonly Guid Ad2Id = Guid.Parse("77777777-7777-7777-7777-777777777777");
        public static readonly Guid Ad3Id = Guid.Parse("88888888-8888-8888-8888-888888888888");

        public static readonly Guid RealEstate1Id = Guid.NewGuid();
        public static readonly Guid RealEstate2Id = Guid.Parse("99999999-9999-9999-9999-999999999999");
        public static readonly Guid RealEstate3Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

        public static readonly Guid Address1Id = Guid.NewGuid();
        public static readonly Guid Address2Id = Guid.NewGuid();
        public static readonly Guid Address3Id = Guid.NewGuid();

        public static readonly Guid Rental1Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
        public static readonly Guid Reference1Id = Guid.Parse("55555555-5555-5555-5555-555555555555");

        public ReputyContext(DbContextOptions<ReputyContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Advertisement> Advertisements => Set<Advertisement>();
        public DbSet<AdvertisementRealEstate> AdvertisementRealEstates => Set<AdvertisementRealEstate>();
        public DbSet<Address> Addresses => Set<Address>();
        public DbSet<Reference> References => Set<Reference>();
        public DbSet<Rental> Rentals => Set<Rental>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdvertisementRealEstate>()
               .Property(e => e.Disposition)
               .HasConversion(new EnumToStringConverter<Disposition>());

            modelBuilder.Entity<AdvertisementRealEstate>()
               .Property(e => e.RentalType)
               .HasConversion(new EnumToStringConverter<TypeOfRental>());

            // Reference relationships
            modelBuilder.Entity<Reference>()
                .HasOne(r => r.FromUser)
                .WithMany(u => u.ReferencesWritten)
                .HasForeignKey(r => r.FromUserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Reference>()
                .HasOne(r => r.ToUser)
                .WithMany(u => u.ReferencesReceived)
                .HasForeignKey(r => r.ToUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Rental relationships
            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Landlord)
                .WithMany(u => u.RentalsAsLandlord)
                .HasForeignKey(r => r.LandlordId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Tenant)
                .WithMany(u => u.RentalsAsTenant)
                .HasForeignKey(r => r.TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            // Advertisement 1:1
            modelBuilder.Entity<Advertisement>()
                .HasOne(e => e.AdvertisementRealEstate)
                .WithOne(e => e.Advertisement)
                .HasForeignKey<AdvertisementRealEstate>(e => e.AdvertisementId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            // AdvertisementRealEstate <-> Address (1:1)
            modelBuilder.Entity<AdvertisementRealEstate>()
                .HasOne(r => r.Address)
                .WithOne(a => a.AdvertisementRealEstate)
                .HasForeignKey<Address>(a => a.AdvertisementRealEstateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    ID = User1Id,
                    FirstName = "Jan",
                    LastName = "Novak",
                    Email = "jan.novak@example.com",
                    Password = "hashedpassword1",
                    Role = Role.LandLord,
                    IsVerified = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    AvatarUrl = "https://example.com/avatar1.png"
                },
                new User
                {
                    ID = User2Id,
                    FirstName = "Eva",
                    LastName = "Svobodova",
                    Email = "eva.svobodova@example.com",
                    Role = Role.Tenant,
                    IsVerified = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Advertisement>().HasData(
                new Advertisement
                {
                    ID = Ad1Id,
                    UserId = User1Id,
                    Title = "Moderní byt v centru",
                    Address = "Náměstí Míru 5, Praha",
                    Price = 15000,
                    IsShared = true,
                    Deposit = 5000m,
                    PetsAllowed = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Advertisement
                {
                    ID = Ad2Id,
                    UserId = User1Id,
                    Title = "Byt 2+KK s výhledem na řeku",
                    Address = "Rašínovo nábřeží 12, Praha 2",
                    Price = 18000,
                    IsShared = false,
                    Deposit = 6000m,
                    PetsAllowed = false,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new Advertisement
                {
                    ID = Ad3Id,
                    UserId = User1Id,
                    Title = "Velký byt 3+1 pro rodinu",
                    Address = "U školy 45, Brno",
                    Price = 22000,
                    IsShared = false,
                    Deposit = 8000m,
                    PetsAllowed = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<AdvertisementRealEstate>().HasData(
                new AdvertisementRealEstate
                {
                    ID = RealEstate1Id,
                    AdvertisementId = Ad1Id,
                    Disposition = Disposition.OneKK,
                    RentalType = TypeOfRental.House,
                    Size = 30.0m,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new AdvertisementRealEstate
                {
                    ID = RealEstate2Id,
                    AdvertisementId = Ad2Id,
                    Disposition = Disposition.TwoKK,
                    RentalType = TypeOfRental.Flat,
                    Size = 40.0m,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new AdvertisementRealEstate
                {
                    ID = RealEstate3Id,
                    AdvertisementId = Ad3Id,
                    Disposition = Disposition.ThreePlusOne,
                    RentalType = TypeOfRental.Flat,
                    Size = 85.0m,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    ID = Address1Id,
                    AdvertisementRealEstateId = RealEstate1Id,
                    City = "Praha",
                    Street = "Náměstí Míru",
                    PostalCode = "12000",
                    StreetNumber = "5"
                },
                new Address
                {
                    ID = Address2Id,
                    AdvertisementRealEstateId = RealEstate2Id,
                    City = "Praha",
                    Street = "Rašínovo nábřeží",
                    PostalCode = "12800",
                    StreetNumber = "12"
                },
                new Address
                {
                    ID = Address3Id,
                    AdvertisementRealEstateId = RealEstate3Id,
                    City = "Brno",
                    Street = "U školy",
                    PostalCode = "60200",
                    StreetNumber = "45"
                }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental
                {
                    ID = Rental1Id,
                    TenantId = User2Id,
                    LandlordId = User1Id,
                    AdvertisementID = Ad1Id,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddMonths(12),
                    Status = RentalStatus.Active,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );

            modelBuilder.Entity<Reference>().HasData(
                new Reference
                {
                    ID = Reference1Id,
                    FromUserID = User2Id,
                    ToUserID = User1Id,
                    RentalID = Rental1Id,
                    Rating = 5,
                    Comment = "Velmi spolehlivý pronajímatel",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }
            );
        }
    }
}
