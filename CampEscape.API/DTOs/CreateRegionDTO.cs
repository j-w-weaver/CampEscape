using System.ComponentModel.DataAnnotations;

namespace CampEscape.API.DTOs
{
    public class CreateRegionDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public int? CampId { get; set; }
        public string? Description { get; set; } = string.Empty;
    }
}
