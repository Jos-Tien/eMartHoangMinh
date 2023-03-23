using eMartHoangMinh.Models;
using eMartHoangMinh.Models.FE;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eMartHoangMinh.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = _db.Categories.ToList();
            return View(items);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            var category = new Category();
            return View(category);
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    category.UpdateDate = category.CreateDate = DateTime.Now.Date;
                    _db.Categories.Add(category);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                return View(category);
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                category.UpdateDate = DateTime.Now.Date;
                _db.Categories.AddOrUpdate(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            if (category != null)
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
