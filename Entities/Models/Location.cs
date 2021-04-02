namespace Entities.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Location class
    /// </summary>
    public class Location : BaseClass
    {
        /// <summary>
        /// ChargePoints property
        /// </summary>
        public ICollection<ChargePoint> ChargePoints { get; set; }
    }
}
