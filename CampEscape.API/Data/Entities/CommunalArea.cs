using System.ComponentModel.DataAnnotations.Schema;

namespace CampEscape.API.Data.Entities
{
    public class CommunalArea
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public string Amenities { get; set; } = string.Empty;

        [ForeignKey(nameof(RegionId))]
        public int RegionId { get; set; }
        public Region Region { get; set; } = new();
    }
}