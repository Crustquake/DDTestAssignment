using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DigitalDesign.Data.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
