using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    /// <summary>
    /// ChargePoint class
    /// </summary>
    public class ChargePoint
    {
        [Key]
        [Required]
        [StringLength(39)]
        public string ChargePointId { get; set; }

        [Required]
        [StringLength(39)]
        public string Status { get; set; }

        [StringLength(4)]
        public string FloorLevel { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [ForeignKey("LocationId")]
        public string LocationId { get; set; }
    }
}
