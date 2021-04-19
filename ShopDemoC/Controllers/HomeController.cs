using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopDemoC.Controllers
{
    public class HomeController : Controller
    {
        private ShopDbContext db = new ShopDbContext();
        public ActionResult Index()
        {
            IEnumerable<Product> products;
            
                products = db.Products.Include(p => p.Category).Where(p => p.Hot == 1 ||  p.Hot == 2);
            

            return View(products.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}