using System.Runtime.CompilerServices;

namespace CampEscape.API.Data.Entities
{
    public class Region
    {
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public int? CampId { get; set; }
        public string? Description { get; set; } = string.Empty;
        //public Camp? Camp { get; set; } = new();
        public ICollection<CampSite>? Campsites { get; set; } = new List<CampSite>();
        public ICollection<Cabin>? Cabins { get; set; } = new List<Cabin>();
        public ICollection<Eatery>? Eateries { get; set; } = new List<Eatery>();
        public ICollection<Bathroom>? Bathrooms { get; set; } = new List<Bathroom>();
        public ICollection<CommunalArea>? CommunalAreas { get; set; } = new List<CommunalArea>();
        public ICollection<BeerGarden>? BeerGardens { get; set; } = new List<BeerGarden>();
    }
}