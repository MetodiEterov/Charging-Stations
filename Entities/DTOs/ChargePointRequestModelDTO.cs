using System.Collections.Generic;

namespace Entities.DTOs
{
    public class ChargePointRequestModelDto
    {
        public string LocationId { get; set; }

        public ICollection<ChargePointDto> ChargePoints { get; set; }
    }
}
