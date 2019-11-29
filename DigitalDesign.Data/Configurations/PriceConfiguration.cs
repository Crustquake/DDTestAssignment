using System;
using System.Collections.Generic;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using DigitalDesign.Data.Entities;

namespace DigitalDesign.Data.Configurations
{
    internal class PriceConfiguration : EntityTypeConfiguration<Price>
    {
        public PriceConfiguration()
        {
            HasKey(price => new { price.ProductId, price.TypeId } );
            HasRequired(price => price.Type).WithMany(type => type.Prices).HasForeignKey(price => price.TypeId);
            HasRequired(price => price.Product).WithMany(product => product.Prices).HasForeignKey(price => price.ProductId);
        }
    }
}