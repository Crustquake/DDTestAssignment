using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalDesign.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public IEnumerable<decimal> Prices { get; set; }
    }
}