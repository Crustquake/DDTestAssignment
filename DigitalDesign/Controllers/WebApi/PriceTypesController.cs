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
    public class PriceTypesController : ApiController
    {
        private readonly DigitalDesignContext _context = new DigitalDesignContext();

        public IEnumerable<PriceType> GetPriceTypes()
        {
            return _context.PriceTypes.ToList();
        }
        public PriceType GetPriceType(int id)
        {
            return _context.PriceTypes.Find(id);
        }
        [HttpPost]
        public void CreatePriceType([FromBody]PriceType priceType)
        {
            _context.PriceTypes.Add(priceType);
            _context.SaveChanges();
        }
        [HttpPut]
        public void EditPriceType(int id, [FromBody]PriceType priceType)
        {
            if (id == priceType.Id)
            {
                _context.Entry(priceType).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeletePriceType(int id)
        {
            PriceType priceType = _context.PriceTypes.Find(id);
            if (priceType != null)
            {
                _context.PriceTypes.Remove(priceType);
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