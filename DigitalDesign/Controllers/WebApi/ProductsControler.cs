using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DigitalDesign.Data;
using DigitalDesign.Data.Entities;

namespace DigitalDesign.Controllers
{
    public class ProductsControler : ApiController
    {
        private readonly DigitalDesignContext _context = new DigitalDesignContext();

        public IEnumerable<Product> GetProduct()
        {
            return _context.Products.ToList();
        }
        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
        [HttpPost]
        public void CreateProduct([FromBody]Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        [HttpPut]
        public void EditProduct(int id, [FromBody]Product product)
        {
            if (id == product.Id)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteProduct(int id)
        {
            Product product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
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