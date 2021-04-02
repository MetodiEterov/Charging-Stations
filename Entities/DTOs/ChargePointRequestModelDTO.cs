namespace Entities.DTOs
{
    using System.Collections.Generic;

    /// <summary>
    /// ChargePointRequestModelDto class
    /// </summary>
    public class ChargePointRequestModelDto
    {
        /// <summary>
        /// LocationId property
        /// </summary>
        public string LocationId { get; set; }

        /// <summary>
        /// ChargePoints property
        /// </summary>
        public ICollection<ChargePointDto> ChargePoints { get; set; }
    }
}
