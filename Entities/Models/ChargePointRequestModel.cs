namespace Entities.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// ChargePointRequestModel class
    /// </summary>
    public class ChargePointRequestModel
    {
        /// <summary>
        /// LocationId property
        /// </summary>
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; }

        /// <summary>
        /// ChargePoints property
        /// </summary>
        public ICollection<ChargePoint> ChargePoints { get; set; }
    }
}
