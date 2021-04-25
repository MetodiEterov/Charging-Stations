using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    /// <summary>
    /// ChargePointRequestModel class
    /// </summary>
    public class ChargePointRequestModel
    {
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; }

        public ICollection<ChargePoint> ChargePoints { get; set; }
    }
}
