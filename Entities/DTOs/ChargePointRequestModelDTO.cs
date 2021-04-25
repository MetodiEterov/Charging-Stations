using System.Collections.Generic;

namespace Entities.DTOs
{
    /// <summary>
    /// ChargePointRequestModelDto class
    /// </summary>
    public class ChargePointRequestModelDto
    {
        public string LocationId { get; set; }

        public ICollection<ChargePointDto> ChargePoints { get; set; }
    }
}
