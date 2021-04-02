namespace Entities.DTOs
{
    using System;

    /// <summary>
    /// LocationRequestModelDto class
    /// </summary>
    public class LocationRequestModelDto
    {
        /// <summary>
        /// LocationId property
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// Type property
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Name property
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address property
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City property
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// PostalCode property
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Country property
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// LastUpdated property
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}
