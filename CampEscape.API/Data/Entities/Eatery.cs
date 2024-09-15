using System.ComponentModel.DataAnnotations.Schema;

namespace CampEscape.API.Data.Entities
{
    public class Eatery
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CuisineType { get; set; } = string.Empty;
        public string? OperatingHours { get; set; } = string.Empty;
        public bool SellAlcohol { get; set; }

        [ForeignKey(nameof(RegionId))]
        public int RegionId { get; set; }
        public Region Region { get; set; } = new();
    }
}