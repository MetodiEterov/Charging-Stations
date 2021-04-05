using System.Collections.Generic;
using System.Threading.Tasks;

using Models;

namespace Entities.Contracts
{
    public interface ILocationRepository<TEntity>
    {
        Task<IEnumerable<Location>> GetAllLocation();

        Task<TEntity> GetLocationById(string id);

        Task<Location> AddNewLocation(TEntity entity);

        Task<Location> PatchLocation(TEntity entity);

        Task<ChargePoint> PutLocation(ChargePointRequestModel entity);
    }
}
