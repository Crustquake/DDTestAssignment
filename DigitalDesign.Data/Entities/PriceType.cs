using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace DigitalDesign.Data.Entities
{
    public class PriceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<Price> Prices { get; set; }
    }
}
