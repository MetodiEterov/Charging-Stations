
using Entities.Models;

using System;

namespace Entities.DbContext
{
    using Microsoft.EntityFrameworkCore;

    public class ChargingStationsDbContext : DbContext
    {
        public ChargingStationsDbContext(DbContextOptions options) : base(options)
        {
        }

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

        public DbSet<ChargePoint> ChargePoints { get; set; }

        public DbSet<Location> Locations { get; set; }
    }
}
