using CKFinder.Settings;
using eMartHoangMinh.Models;
using eMartHoangMinh.Models.FE;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace eMartHoangMinh.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            var pageIndex = page.HasValue ? page.Value : 1;
            var products = _db.Products.OrderBy(x => x.Quantity).ToPagedList(pageIndex, pageSize);
            return View(products);
        }
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.ProductCategory = new SelectList(_db.ProductCategories.ToList(),"Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product, List<string> Images, List<int> rdDefault)
        {
            try
            {
                var imageIndex = -1;
                if (ModelState.IsValid)
                {
                    if (Images != null && Images.Count > 0)
                    {
                        for (int i = 0; i < Images.Count; i++)
                        {
                            var productImage = new ProductImage()
                            {
                                ProductId = product.Id,
                                Image = Images[i]
                            };
                            if (i + 1 == rdDefault[0])
                            {
                                productImage.IsDefault = true;
                                imageIndex = i;
                            }
                            _db.ProductImages.Add(productImage);
                        }
                    }
                    product.Image = imageIndex >= 0 ? Images[imageIndex] : "";
                    _db.Products.Add(product);
                    _db.SaveChanges();
                }
                ViewBag.ProductCategory = new SelectList(_db.ProductCategories.ToList(), "Id", "Name");
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
        public ActionResult Edit(int id)
        {
            var product = _db.Products.Find(id);
            ViewBag.ProductCategory = new SelectList(_db.ProductCategories.ToList(), "Id", "Name");
            product.ProductImages = _db.ProductImages.Where(x => x.ProductId == product.Id).ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, List<string> Images, List<int> rdDefault)
        {
            try
            {
                product.UpdateDate = DateTime.Now;
                var imageIndex = -1;
                if (ModelState.IsValid)
                {
                    if (Images != null && Images.Count > 0)
                    {
                        for (int i = 0; i < Images.Count; i++)
                        {
                            var productImage = new ProductImage()
                            {
                                ProductId = product.Id,
                                Image = Images[i]
                            };
                            if (i + 1 == rdDefault[0])
                            {
                                productImage.IsDefault = true;
                                imageIndex = i;
                            }
                            _db.ProductImages.Add(productImage);
                        }
                    }
                    product.Image = imageIndex >= 0 ? Images[imageIndex] : "";
                    _db.Products.Add(product);
                    _db.SaveChanges();
                }
                ViewBag.ProductCategory = new SelectList(_db.ProductCategories.ToList(), "Id", "Name");
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
            var product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                var imgs = _db.ProductImages.Where(x => x.ProductId == product.Id).ToList();
                if (imgs != null)
                {
                    foreach (var img in imgs)
                    {
                        _db.ProductImages.Remove(img);
                    }
                }
                _db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { succes = false });
        }
    }
}
