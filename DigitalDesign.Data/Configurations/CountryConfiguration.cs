using System;
using System.Collections.Generic;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using DigitalDesign.Data.Entities;

namespace DigitalDesign.Data.Configurations
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            HasKey(country => country.Id);
            Property(country => country.Name).HasMaxLength(100).IsRequired();
            HasIndex(country => country.Name).IsUnique();
        }
    }
}
