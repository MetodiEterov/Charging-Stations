namespace Entities.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// BaseClass class
    /// </summary>
    public abstract class BaseClass
    {
        /// <summary>
        /// LocationId property
        /// </summary>
        [Required]
        [StringLength(39)]
        public string LocationId { get; set; }

        /// <summary>
        /// Type property
        /// </summary>
        [Required]
        [StringLength(45)]
        public string Type { get; set; }

        /// <summary>
        /// Name property
        /// </summary>
        [StringLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Address property
        /// </summary>
        [Required]
        [StringLength(45)]
        public string Address { get; set; }

        /// <summary>
        /// City property
        /// </summary>
        [Required]
        [StringLength(45)]
        public string City { get; set; }

        /// <summary>
        /// PostalCode property
        /// </summary>
        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Country property
        /// </summary>
        [Required]
        [StringLength(45)]
        public string Country { get; set; }

        /// <summary>
        /// LastUpdated property
        /// </summary>
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
