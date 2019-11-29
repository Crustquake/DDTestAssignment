using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

using DigitalDesign.Models;
using DigitalDesign.Data;
using DigitalDesign.Data.Entities;


namespace DigitalDesign.Controllers
{
    public class MainController : Controller
    {
        private readonly DigitalDesignContext _context = new DigitalDesignContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Products([DataSourceRequest]DataSourceRequest request)
        {
            IEnumerable<ProductViewModel> data = _context.Products
                .Include(product => product.Country)
                .Include(product => product.Category)
                .Select(product => new
                {
                    Id = product.Id,
                    Title = product.Name,
                    Category = product.Category.Name,
                    Country = product.Country.Name,
                    Prices = product.Prices.Select(price => price.Value)
                })
                .ToList()
                .Select(product => new ProductViewModel
                {
                    Id = product.Id,
                    Title = product.Title,
                    Category = product.Category,
                    Country = product.Country,
                    Prices = product.Prices
                });

            return Json(data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
    }
}
