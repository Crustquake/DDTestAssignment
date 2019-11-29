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
    public class ProductCategoriesController : ApiController
    {
        private readonly DigitalDesignContext _context = new DigitalDesignContext();

        public IEnumerable<ProductCategory> GetProductCategory()
        {
            return _context.ProductCategories.ToList();
        }
        public ProductCategory GetProductCategory(int id)
        {
            return _context.ProductCategories.Find(id);
        }
        [HttpPost]
        public void CreateProductCategory([FromBody]ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
        }
        [HttpPut]
        public void EditProductCategory(int id, [FromBody]ProductCategory productCategory)
        {
            if (id == productCategory.Id)
            {
                _context.Entry(productCategory).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteProductCategory(int id)
        {
            ProductCategory productCategory = _context.ProductCategories.Find(id);
            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
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