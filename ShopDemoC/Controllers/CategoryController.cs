using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopDemoC.Controllers
{
    public class CategoryController : Controller
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            int categoryId;
            IEnumerable<Product> products;
            if(int.TryParse(Request.Params["category"], out categoryId))
            {
                 products = db.Products.Include(p => p.Category).Where(p => p.CategoryId == categoryId);
            }
            else
            {
                products = db.Products.Include(p => p.Category);
            }

            return View(products.ToList());
        }        
    }
}