using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopDemoC.Controllers
{
    public class SearchController : Controller
    {
        private ShopDbContext db = new ShopDbContext();
        // GET: Search
        public ActionResult Index(string searchString)
        {
            var searchs = from s in db.Products
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                searchs = searchs.Where(s => s.Name.Contains(searchString));
            }

            return View(searchs);
        }
    }
}