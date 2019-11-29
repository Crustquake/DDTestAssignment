using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
using System.Linq;

using DigitalDesign.Data.Entities;

namespace DigitalDesign.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DigitalDesignContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DigitalDesignContext context)
        {
            IEnumerable<Country> countries = GetAllCountries();
            context.Countries.AddRange(countries);

            IEnumerable<PriceType> priceTypes = Enumerable.Range(1, 6).Select(index => new PriceType { Name = $"PriceType{index}" });
            context.PriceTypes.AddRange(priceTypes);

            var mouses = new ProductCategory { Name = "Mouses" };
            var keyboards = new ProductCategory { Name = "Keyboards" };
            var processors = new ProductCategory { Name = "Processors" };
            var displays = new ProductCategory { Name = "Displays" };
            var videocards = new ProductCategory { Name = "Videocards" };
            var mobilePhones = new ProductCategory { Name = "Mobile phones" };
            context.ProductCategories.AddRange(new ProductCategory[] { mouses, keyboards, processors, displays, videocards});

            context.SaveChanges();

            Country usa = context.Countries.First(country => country.Name == "United States");
            Country russia = context.Countries.First(country => country.Name == "Russia");

            var product0 = new Product { Name = "Mouse 01", Country = usa, Category = mouses };
            var product1 = new Product { Name = "Super Gaming Mouse", Country = usa, Category = mouses };
            var product2 = new Product { Name = "Magic Keyboard", Country = usa, Category = keyboards };
            var product3 = new Product { Name = "Intel Core 9", Country = usa, Category = processors };
            var product4 = new Product { Name = "YotaPhone ", Country = russia, Category = mobilePhones };
            var product5 = new Product { Name = "iPhone", Country = usa, Category = mobilePhones };
            var products = new Product[] { product0, product1, product2, product3, product4, product5 };

            var random = new Random();
            foreach (Product product in products)
            {
                product.Prices = new List<Price>();
                foreach (PriceType priceType in context.PriceTypes)
                {
                    product.Prices.Add(new Price { Type = priceType, Value = 100.0m * new decimal(random.NextDouble()) });
                }
            }
            context.Products.AddRange(products);

            context.SaveChanges();
        }

        private IEnumerable<Country> GetAllCountries()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            var names = cultures.Select(culture => (new RegionInfo(culture.LCID)).DisplayName).Distinct().OrderBy(name => name);

            return names.Select(name => { System.Diagnostics.Debug.WriteLine(name); return new Country { Name = name }; });
        }
    }
}
