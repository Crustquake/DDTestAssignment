using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DigitalDesign.Data.Entities;

namespace DigitalDesign.Models
{
    public class ProductsViewModel
    {
        //public IEnumerable<ProductViewModel> Products { get; set; }
        public IEnumerable<PriceType> PriceTypes { get; set; }
    }
}