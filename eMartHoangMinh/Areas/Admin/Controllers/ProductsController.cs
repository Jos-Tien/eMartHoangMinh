﻿using eMartHoangMinh.Models;
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
        public ActionResult Create(Product product)
        {
            try
            {

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                // TODO: Add update logic here

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
            var post = _db.Posts.Find(id);
            if (post != null)
            {
                _db.Posts.Remove(post);
                _db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { succes = false });
        }
    }
}
