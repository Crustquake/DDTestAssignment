using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DigitalDesign.Data;
using DigitalDesign.Data.Entities;

namespace DigitalDesign.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly DigitalDesignContext _context = new DigitalDesignContext();

        public IEnumerable<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }
        public Country GetCountry(int id)
        {
            return _context.Countries.Find(id);
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