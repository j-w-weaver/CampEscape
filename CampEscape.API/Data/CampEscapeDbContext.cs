using CampEscape.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CampEscape.API.Data
{
    public class CampEscapeDbContext : DbContext
    {
        public CampEscapeDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Camp> Camps { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<CampSite> CampSites { get; set; }
        public DbSet<Cabin> Cabins { get; set; }
        public DbSet<Eatery> Eateries { get; set; }
        public DbSet<CommunalArea> CommunalAreas { get; set; }
        public DbSet<BeerGarden> BeerGardens { get; set; }
        public DbSet<Bathroom> Bathrooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Camp>()
                .HasMany(c => c.Regions);
                //.WithOne(r => r.Camp)
                //.HasForeignKey(r => r.CampId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Campsites)
                .WithOne(cs => cs.Region)
                .HasForeignKey(cs => cs.RegionId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Cabins)
                .WithOne(c => c.Region)
                .HasForeignKey(c => c.RegionId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Eateries)
                .WithOne(e => e.Region)
                .HasForeignKey(e => e.RegionId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Bathrooms)
                .WithOne(b => b.Region)
                .HasForeignKey(b => b.RegionId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.CommunalAreas)
                .WithOne(ca => ca.Region)
                .HasForeignKey(ca => ca.RegionId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.BeerGardens)
                .WithOne(bg => bg.Region)
                .HasForeignKey(bg => bg.RegionId);

            // Specifiying precision and scale for decimal properties
            modelBuilder.Entity<Cabin>()
                .Property(c => c.PricePerNight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Cabin>()
                .Property(c => c.PricePerWeek)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CampSite>()
                .Property(cs => cs.PricePerNight)
                .HasPrecision(18, 2);

            modelBuilder.Entity<CampSite>()
                .Property(cs => cs.PricePerWeek)
                .HasPrecision(18, 2);
        }
    }
}
