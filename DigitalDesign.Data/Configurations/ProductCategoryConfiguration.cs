using System;
using System.Collections.Generic;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using DigitalDesign.Data.Entities;

namespace DigitalDesign.Data.Configurations
{
    public class ProductCategoryConfiguration : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryConfiguration()
        {
            HasKey(productCategory => productCategory.Id);
            Property(productCategory => productCategory.Name).HasMaxLength(100).IsRequired();
            HasIndex(productCategory => productCategory.Name).IsUnique();
        }
    }
}
