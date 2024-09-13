﻿namespace CampEscape.API.Data.Entities
{
    public class Camp
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Region> Regions { get; set; } = new List<Region>();
    }
}