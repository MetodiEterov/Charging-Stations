using System.Collections.Generic;

namespace Entities.Models
{
    /// <summary>
    /// Location class
    /// </summary>
    public class Location : BaseClass
    {
        public ICollection<ChargePoint> ChargePoints { get; set; }
    }
}
