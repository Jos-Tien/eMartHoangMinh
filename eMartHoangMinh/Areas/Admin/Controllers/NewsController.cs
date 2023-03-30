using eMartHoangMinh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace eMartHoangMinh.Areas.Admin.Controllers
{
    public class NewsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/News
        public ActionResult Index()
        {
            var news = _db.News.OrderByDescending(x => x.CreateDate).ToList();
            return View(news);
        }

        // GET: Admin/News/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/News/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/News/Delete/5
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
