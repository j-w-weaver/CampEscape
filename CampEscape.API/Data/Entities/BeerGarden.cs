using System.ComponentModel.DataAnnotations.Schema;

namespace CampEscape.API.Data.Entities
{
    public class BeerGarden
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AlcoholType { get; set; } = string.Empty;
        public string OperatingHours { get; set; } = string.Empty;
        public bool SellFood { get; set; }

        [ForeignKey(nameof(RegionId))]
        public int RegionId { get; set; }
        public Region Region { get; set; } = new();
    }
}