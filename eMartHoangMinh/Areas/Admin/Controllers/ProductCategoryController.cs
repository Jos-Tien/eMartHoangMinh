using eMartHoangMinh.Models;
using eMartHoangMinh.Models.FE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMartHoangMinh.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var products = _db.ProductCategories;
            return View(products);
        }

        // GET: Admin/ProductCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProductCategory/Create
        public ActionResult Create()
        {
            var pro = new ProductCategory();
            return View(pro);
        }

        // POST: Admin/ProductCategory/Create
        [HttpPost]
        public ActionResult Create(ProductCategory pro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pro.UpdateDate = pro.CreateDate = DateTime.Now.Date;
                    pro.Alias = Helpers.Helper.Instance.RemoveSign4VietnameseString(pro.SeoName);
                    _db.ProductCategories.Add(pro);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProductCategory/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _db.ProductCategories.Find(id);
            if (category != null)
            {
                return View(category);
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/ProductCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductCategory pro)
        {
            try
            {
                pro.UpdateDate = DateTime.Now.Date;
                pro.Alias = Helpers.Helper.Instance.RemoveSign4VietnameseString(pro.SeoName);
                _db.ProductCategories.AddOrUpdate(pro);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var pro = _db.ProductCategories.Find(id);
            if (pro != null)
            {
                _db.ProductCategories.Remove(pro);
                _db.SaveChanges();
                return Json(new {success = true});
            }
            return Json(new { succes = false });
        }
    }
}
