using System;
using System.Data.Entity;
using System.Linq;

using DigitalDesign.Data.Entities;
using DigitalDesign.Data.Configurations;

namespace DigitalDesign.Data
{
    public class DigitalDesignContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceType> PriceTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public DigitalDesignContext()
            : base("name=DigitalDesignContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new PriceConfiguration());
            modelBuilder.Configurations.Add(new PriceTypeConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}