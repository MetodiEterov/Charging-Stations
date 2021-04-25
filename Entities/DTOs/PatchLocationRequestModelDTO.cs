using System;

namespace Entities.DTOs
{
    /// <summary>
    /// PatchLocationRequestModelDto class
    /// </summary>
    public class PatchLocationRequestModelDto
    {
        public string LocationId { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
