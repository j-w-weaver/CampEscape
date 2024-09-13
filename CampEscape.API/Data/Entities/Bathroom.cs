using System.ComponentModel.DataAnnotations.Schema;

namespace CampEscape.API.Data.Entities
{
    public class Bathroom
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Capacity { get; set; } = string.Empty;
        public bool HasShowers { get; set; }

        [ForeignKey(nameof(RegionId))]
        public int RegionId { get; set; }
        public Region Region { get; set; } = new();
    }
}