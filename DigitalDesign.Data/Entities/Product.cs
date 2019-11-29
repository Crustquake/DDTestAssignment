using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DigitalDesign.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual ProductCategory Category { get; set; }
        public int CountryId { get; set; }
        [JsonIgnore]
        public virtual Country Country { get; set; }
        [JsonIgnore]
        public virtual ICollection<Price> Prices { get; set; }
    }
}
