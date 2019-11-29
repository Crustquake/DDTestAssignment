using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DigitalDesign.Data.Entities
{
    public class Price
    {
        public int ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        public int TypeId { get; set; }
        [JsonIgnore]
        public PriceType Type { get; set; }
        public decimal Value { get; set; }
    }
}
