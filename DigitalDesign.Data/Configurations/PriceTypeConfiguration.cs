using System;
using System.Collections.Generic;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using DigitalDesign.Data.Entities;

namespace DigitalDesign.Data.Configurations
{
    public class PriceTypeConfiguration : EntityTypeConfiguration<PriceType>
    {
        public PriceTypeConfiguration()
        {
            HasKey(priceType => priceType.Id);
            Property(priceType => priceType.Name).HasMaxLength(100).IsRequired();
            HasIndex(priceType => priceType.Name).IsUnique();
        }
    }
}
