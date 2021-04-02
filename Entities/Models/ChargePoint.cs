namespace Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// ChargePoint class
    /// </summary>
    public class ChargePoint
    {
        /// <summary>
        /// ChargePointId property
        /// </summary>
        [Key]
        [Required]
        [StringLength(39)]
        public string ChargePointId { get; set; }

        /// <summary>
        /// Status property
        /// </summary>
        [Required]
        [StringLength(39)]
        public string Status { get; set; }

        /// <summary>
        /// FloorLevel property
        /// </summary>
        [StringLength(4)]
        public string FloorLevel { get; set; }

        /// <summary>
        /// LastUpdated property
        /// </summary>
        [Required]
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// LocationId property
        /// </summary>
        [ForeignKey("LocationId")]
        public string LocationId { get; set; }
    }
}
