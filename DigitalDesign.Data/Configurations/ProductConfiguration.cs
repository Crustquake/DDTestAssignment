using System;
using System.Collections.Generic;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using DigitalDesign.Data.Entities;

namespace DigitalDesign.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(product => product.Id);
            Property(product => product.Name).IsRequired();
            HasRequired(product => product.Category).WithMany(productCategory => productCategory.Products).HasForeignKey(product => product.CategoryId);
            HasRequired(product => product.Country).WithMany().HasForeignKey(product => product.CountryId);
        }
    }
}
