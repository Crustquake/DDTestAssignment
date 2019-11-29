using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DigitalDesign.Data;
using DigitalDesign.Data.Entities;

namespace DigitalDesign.Controllers.WebApi
{
    public class PricesController : ApiController
    {
        private readonly DigitalDesignContext _context = new DigitalDesignContext();

        public IEnumerable<Price> GetPrices()
        {
            return _context.Prices.ToList();
        }
        public Price GetPrice(int productId, int priceTypeId)
        {
            return _context.Prices.Find(productId, priceTypeId);
        }
        [HttpPost]
        public void CreatePrice([FromBody]Price price)
        {
            _context.Prices.Add(price);
            _context.SaveChanges();
        }
        [HttpPut]
        public void EditPrice(int productId, int priceTypeId, [FromBody]Price price)
        {
            if (productId == price.ProductId && priceTypeId == price.TypeId)
            {
                _context.Entry(price).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeletePrice(int productId, int priceTypeId)
        {
            Price price = _context.Prices.Find(productId, priceTypeId);
            if (price != null)
            {
                _context.Prices.Remove(price);
                _context.SaveChanges();
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}