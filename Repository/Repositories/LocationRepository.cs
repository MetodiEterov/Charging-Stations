 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.DbContext;
using Entities.Models;
using Entities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class LocationRepository : ILocationRepository<BaseClass>
    {
        private readonly ChargingStationsDbContext _chargingStationsDbContext;

        public LocationRepository(ChargingStationsDbContext chargingStationsDbContext)
        {
            _chargingStationsDbContext = chargingStationsDbContext;
        }

        public async Task<IEnumerable<Location>> GetAllLocation()
        {
            return await _chargingStationsDbContext.Locations.ToListAsync();
        }

        public async Task<BaseClass> GetLocationById(string id)
        {
            return await _chargingStationsDbContext.Locations.FirstOrDefaultAsync(e => e.LocationId == id);
        }

        public async Task<Location> AddNewLocation(BaseClass entity)
        {
            var newLocation = new Location
            {
                Address = entity.Address,
                City = entity.City,
                Country = entity.Country,
                Name = entity.Name,
                PostalCode = entity.PostalCode,
                Type = entity.Type,
                LastUpdated = DateTime.Now,
                LocationId = Guid.NewGuid().ToString()
            };

            await _chargingStationsDbContext.Locations.AddAsync(newLocation);
            await _chargingStationsDbContext.SaveChangesAsync();

            return newLocation;
        }

        public async Task<ChargePoint> PutLocation(ChargePointRequestModel entity)
        {
            var stationsById = await _chargingStationsDbContext.ChargePoints
                .Where(x => x.LocationId == entity.LocationId)
                .ToListAsync();
            if (!stationsById.Any() || !entity.ChargePoints.Any()) return new ChargePoint();
            {
                ChargePoint updatedStation = null;
                foreach (var item in stationsById)
                {
                    var currentStation = entity.ChargePoints.FirstOrDefault(x => x.ChargePointId == item.ChargePointId);
                    if (currentStation == null)
                    {
                        updatedStation = item;
                        updatedStation.Status = "Removed";
                    }
                    else
                    {
                        updatedStation = new ChargePoint
                        {
                            ChargePointId = currentStation.ChargePointId,
                            FloorLevel = currentStation.FloorLevel,
                            Status = currentStation.Status,
                            LastUpdated = DateTime.Now,
                            LocationId = entity.LocationId
                        };
                    }

                    var local = _chargingStationsDbContext.Set<ChargePoint>()
                        .Local
                        .FirstOrDefault(entry => entry.ChargePointId
                            .Equals(updatedStation.ChargePointId));

                    if (local != null) _chargingStationsDbContext.Entry(local).State = EntityState.Detached;

                    _chargingStationsDbContext.Entry(updatedStation).State = EntityState.Modified;
                    await _chargingStationsDbContext.SaveChangesAsync();
                }

                return updatedStation;
            }

        }

        public async Task<Location> PatchLocation(BaseClass entity)
        {
            var currentStation = await _chargingStationsDbContext.Locations.FirstOrDefaultAsync(x => x.LocationId == entity.LocationId);
            if (currentStation == null) return new Location();
            var updateLocation = new Location
            {
                Address = string.IsNullOrEmpty(entity.Address) ? currentStation.Address : entity.Address,
                City = string.IsNullOrEmpty(entity.City) ? currentStation.City : entity.City,
                Country = string.IsNullOrEmpty(entity.Country) ? currentStation.Country : entity.Country,
                Name = string.IsNullOrEmpty(entity.Name) ? currentStation.Name : entity.Name,
                Type = string.IsNullOrEmpty(entity.Type) ? currentStation.Type : entity.Type,
                PostalCode =
                    string.IsNullOrEmpty(entity.PostalCode) ? currentStation.PostalCode : entity.PostalCode,
                LocationId = currentStation.LocationId,
                LastUpdated = DateTime.Now
            };

            var local = _chargingStationsDbContext.Set<Location>()
                .Local
                .FirstOrDefault(entry => entry.LocationId
                    .Equals(updateLocation.LocationId));

            if (local != null) _chargingStationsDbContext.Entry(local).State = EntityState.Detached;

            _chargingStationsDbContext.Entry(updateLocation).State = EntityState.Modified;
            await _chargingStationsDbContext.SaveChangesAsync();

            return updateLocation;

        }
    }
}
