using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop.Common;
using Shop.Models;
using Shop.Models.ViewModels;

namespace ShopDemoC.Areas.Admin.Controllers
{
    [Authorize]
    [CustomActionFilter]
    [ExceptionHandlerFilter]
    public class ProductsController : BaseController
    {
        private ShopDbContext db = new ShopDbContext();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "DisplayText");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductView viewModel)
        {
            Product product = new Product();
            if (ModelState.IsValid)
            {
                viewModel.CopyToProduct(ref product);
                product.FeatureImage = SaveFile(viewModel.UploadFile, product.FeatureImage);
                product.ImgLink1 = SaveFile(viewModel.UploadFile1, product.ImgLink1);
                product.ImgLink2 = SaveFile(viewModel.UploadFile2, product.ImgLink2);
                product.ImgLink3 = SaveFile(viewModel.UploadFile3, product.ImgLink3);
                product.ImgLink4 = SaveFile(viewModel.UploadFile4, product.ImgLink4);

                db.Products.Add(product);
                db.SaveChanges();
                SetSuccessNotification();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "DisplayText", product.CategoryId);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "DisplayText", product.CategoryId);
            var viewModel = new ProductView(product);
            return View(viewModel);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductView viewModel)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.Find(viewModel.Id);
                viewModel.CopyToProduct(ref product);
                product.FeatureImage = SaveFile(viewModel.UploadFile, product.FeatureImage);
                product.ImgLink1 = SaveFile(viewModel.UploadFile1, product.ImgLink1);
                product.ImgLink2 = SaveFile(viewModel.UploadFile2, product.ImgLink2);
                product.ImgLink3 = SaveFile(viewModel.UploadFile3, product.ImgLink3);
                product.ImgLink4 = SaveFile(viewModel.UploadFile4, product.ImgLink4);

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                SetSuccessNotification();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "DisplayText", viewModel.CategoryId);
            return View(viewModel);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            SetSuccessNotification();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private string SaveFile(HttpPostedFileBase postedFile, string previousUrl = null)
        {
            if (postedFile == null)
            {
                return !string.IsNullOrEmpty(previousUrl) ? previousUrl : null;
            }
            string relativePath = ConfigurationManager.AppSettings.Get("shop:uploadsDir:products") ?? "/Uploads/Products";
            string physicFolderPath = Server.MapPath(relativePath);
            string previousFilePath = Server.MapPath(Server.UrlDecode(previousUrl));

            // Create upload folder if not exist
            if (!Directory.Exists(physicFolderPath))
            {
                Directory.CreateDirectory(physicFolderPath);
            }
            if (!string.IsNullOrEmpty(previousFilePath) && System.IO.File.Exists(previousFilePath))
            {
                System.IO.File.Delete(previousFilePath);
            }

            postedFile.SaveAs(Path.Combine(physicFolderPath, postedFile.FileName));
            return Server.UrlEncode(relativePath + "/" + postedFile.FileName);
        }
    }
}
