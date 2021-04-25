namespace Entities.DTOs
{
    /// <summary>
    /// ChargePointDto class
    /// </summary>
    public class ChargePointDto
    {
        public string ChargePointId { get; set; }

        public string Status { get; set; }

        public string FloorLevel { get; set; }

        public string LastUpdated { get; set; }

        public string LocationId { get; set; }
    }
}
