using System.ComponentModel.DataAnnotations.Schema;

namespace CampEscape.API.Data.Entities
{
    public class CampSite
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double? Rating { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal? PricePerWeek { get; set; }
        public string? Capacity { get; set; } = string.Empty;
        public string? Amenities {  get; set; } = string.Empty;
        public bool RateReduced {  get; set; }

        [ForeignKey(nameof(RegionId))]
        public int RegionId { get; set; }
        public Region Region { get; set; } = new();
    }
}
