namespace Entities.DbContext
{
    using System;

    using Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// ChargingStationsDbContext class
    /// </summary>
    public class ChargingStationsDbContext : DbContext
    {
        /// <summary>
        /// ChargingStationsDbContext constructor
        /// </summary>
        /// <param name="options"></param>
        public ChargingStationsDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Locations property
        /// </summary>
        public DbSet<Location> Locations { get; set; }

        /// <summary>
        /// ChargePoints property
        /// </summary>
        public DbSet<ChargePoint> ChargePoints { get; set; }

        /// <summary>
        /// OnModelCreating method
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var location1 = new Location
            {
                Address = "Address 1",
                City = "Sofia",
                Country = "Bulgaria",
                Name = "Station 1",
                Type = "Type 1",
                PostalCode = "1000",
                LocationId = Guid.NewGuid().ToString(),
                LastUpdated = new DateTime(2017, 02, 22)
            };
            var location2 = new Location
            {
                Address = "Address 2",
                City = "Sofia",
                Country = "Bulgaria",
                Name = "Station 2",
                Type = "Type 1",
                PostalCode = "1000",
                LocationId = Guid.NewGuid().ToString(),
                LastUpdated = new DateTime(2017, 02, 22)
            };
            var location3 = new Location
            {
                Address = "Address 3",
                City = "Sofia",
                Country = "Bulgaria",
                Name = "Station 3",
                Type = "Type 3",
                PostalCode = "1000",
                LocationId = Guid.NewGuid().ToString(),
                LastUpdated = new DateTime(2017, 02, 22)
            };

            modelBuilder.Entity<Location>().HasData(location1);
            modelBuilder.Entity<Location>().HasData(location2);
            modelBuilder.Entity<Location>().HasData(location3);

            _ = modelBuilder.Entity<ChargePoint>().HasData(
            new ChargePoint
            {
                ChargePointId = Guid.NewGuid().ToString(),
                FloorLevel = "A",
                Status = "Available",
                LastUpdated = new DateTime(2018, 04, 25),
                LocationId = location1.LocationId
            },
            new ChargePoint
            {
                ChargePointId = Guid.NewGuid().ToString(),
                FloorLevel = "A",
                Status = "Available",
                LastUpdated = new DateTime(2019, 01, 12),
                LocationId = location1.LocationId
            },
            new ChargePoint
            {
                ChargePointId = Guid.NewGuid().ToString(),
                FloorLevel = "A",
                Status = "Blocked",
                LastUpdated = new DateTime(2017, 04, 11),
                LocationId = location1.LocationId
            },
            new ChargePoint
            {
                ChargePointId = Guid.NewGuid().ToString(),
                FloorLevel = "B",
                Status = "Available",
                LastUpdated = new DateTime(2016, 01, 03),
                LocationId = location2.LocationId
            },
            new ChargePoint
            {
                ChargePointId = Guid.NewGuid().ToString(),
                FloorLevel = "A",
                Status = "Available",
                LastUpdated = new DateTime(2019, 03, 03),
                LocationId = location3.LocationId
            },
            new ChargePoint
            {
                ChargePointId = Guid.NewGuid().ToString(),
                FloorLevel = "C",
                Status = "Reserved",
                LastUpdated = new DateTime(2018, 04, 11),
                LocationId = location2.LocationId
            });
        }
    }
}
