using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDesign.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<string> PriceTypes { get; set; }
    }
}