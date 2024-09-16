using System.ComponentModel.DataAnnotations;

namespace CampEscape.API.DTOs
{
    public class CreateRegionDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}
