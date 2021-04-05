using System.Collections.Generic;

namespace Entities.Models
{
    public class Location : BaseClass
    {
        public ICollection<ChargePoint> ChargePoints { get; set; }
    }
}
