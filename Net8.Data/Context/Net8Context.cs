using Microsoft.EntityFrameworkCore;
using Net8.Data.Entities;

namespace Net8.Data.Context
{
    public class Net8Context : DbContext
    {
        public Net8Context(DbContextOptions<Net8Context> options) : base(options)
        { }
        
        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddres> FooterAddres { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricing { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }

        public DbSet<TabloLog> TabloLogs { get; set; }
    }
}
