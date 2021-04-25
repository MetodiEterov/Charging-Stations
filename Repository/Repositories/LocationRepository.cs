using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Entities.Contracts;
using Entities.DbContext;
using Entities.Models;

using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    /// <summary>
    /// LocationRepository class 
    /// </summary>
    public class LocationRepository : ILocationRepository<BaseClass>
    {
        private readonly ChargingStationsDbContext _chargingStationsDbContext;

        public LocationRepository(ChargingStationsDbContext chargingStationsDbContext)
        { _chargingStationsDbContext = chargingStationsDbContext; }

        /// <summary>
        /// SetNewLocation method
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="currentStation"></param>
        /// <returns></returns>
        private static Location SetNewLocation(BaseClass entity, Location currentStation)
        {
            return new Location
            {
                Address = string.IsNullOrEmpty(entity.Address) ? currentStation.Address : entity.Address,
                City = string.IsNullOrEmpty(entity.City) ? currentStation.City : entity.City,
                Country = string.IsNullOrEmpty(entity.Country) ? currentStation.Country : entity.Country,
                Name = string.IsNullOrEmpty(entity.Name) ? currentStation.Name : entity.Name,
                Type = string.IsNullOrEmpty(entity.Type) ? currentStation.Type : entity.Type,
                PostalCode = string.IsNullOrEmpty(entity.PostalCode) ? currentStation.PostalCode : entity.PostalCode,
                LocationId = currentStation.LocationId,
                LastUpdated = DateTime.UtcNow
            };
        }

        /// <summary>
        /// UpdateStation method
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="stationsById"></param>
        /// <param name="updatedStation"></param>
        /// <returns></returns>
        private async Task<ChargePoint> UpdateStation(ChargePointRequestModel entity, List<ChargePoint> stationsById, ChargePoint updatedStation)
        {
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

                var local = _chargingStationsDbContext.Set<ChargePoint>().Local
                    .FirstOrDefault(entry => entry.ChargePointId.Equals(updatedStation.ChargePointId));

                if (local != null)
                    _chargingStationsDbContext.Entry(local).State = EntityState.Detached;

                _chargingStationsDbContext.Entry(updatedStation).State = EntityState.Modified;
                await _chargingStationsDbContext.SaveChangesAsync();
            }

            return updatedStation;
        }

        /// <summary>
        /// AddNewLocation method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// GetAllLocation method
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Location>> GetAllLocation()
        { return await _chargingStationsDbContext.Locations.ToListAsync(); }

        /// <summary>
        /// GetLocationById method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseClass> GetLocationById(string id)
        { return await _chargingStationsDbContext.Locations.FirstOrDefaultAsync(e => e.LocationId == id); }

        /// <summary>
        /// PatchLocation method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Location> PatchLocation(BaseClass entity)
        {
            var currentStation = await _chargingStationsDbContext.Locations
                .FirstOrDefaultAsync(x => x.LocationId == entity.LocationId);
            if (currentStation == null)
                return new Location();

            var updateLocation = SetNewLocation(entity, currentStation);
            var local = _chargingStationsDbContext.Set<Location>().Local
                .FirstOrDefault(entry => entry.LocationId.Equals(updateLocation.LocationId));

            if (local != null)
                _chargingStationsDbContext.Entry(local).State = EntityState.Detached;

            _chargingStationsDbContext.Entry(updateLocation).State = EntityState.Modified;
            await _chargingStationsDbContext.SaveChangesAsync();

            return updateLocation;
        }

        /// <summary>
        /// PutLocation method
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<ChargePoint> PutLocation(ChargePointRequestModel entity)
        {
            var stationsById = await _chargingStationsDbContext.ChargePoints
                .Where(x => x.LocationId == entity.LocationId)
                .ToListAsync();
            if (!stationsById.Any() || !entity.ChargePoints.Any())
                return new ChargePoint();
            {
                ChargePoint updatedStation = null;
                updatedStation = await UpdateStation(entity, stationsById, updatedStation);

                return updatedStation;
            }
        }
    }
}
