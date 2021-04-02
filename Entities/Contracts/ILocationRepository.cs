namespace Entities.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;

    /// <summary>
    /// ILocationRepository interface
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ILocationRepository<TEntity>
    {
        /// <summary>
        /// GetAllLocation contract
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Location>> GetAllLocation();

        /// <summary>
        /// GetLocationById contract
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TEntity> GetLocationById(string id);

        /// <summary>
        /// AddNewLocation contract
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Location> AddNewLocation(TEntity entity);

        /// <summary>
        /// PatchLocation contract
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Location> PatchLocation(TEntity entity);

        /// <summary>
        /// PutLocation contract
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ChargePoint> PutLocation(ChargePointRequestModel entity);
    }
}
