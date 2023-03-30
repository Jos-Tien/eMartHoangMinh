using eMartHoangMinh.Models;
using eMartHoangMinh.Models.FE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            var news = _db.News.Find(id);
            news.Category = _db.Categories.Find(news.CategoryId);
            return View(news);
        }

        // GET: Admin/News/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _db.Categories.ToList();
            var model = new News();
            return View(model);
        }

        // POST: Admin/News/Create
        [HttpPost]
        public ActionResult Create(News news)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    news.CreateDate = news.UpdateDate = DateTime.Now.Date;
                    news.CreateBy = "Hoàng Minh";
                    news.CategoryId = 1;
                    _db.News.Add(news);
                    _db.SaveChanges();
                }

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
            var news = _db.News.Find(id);
            ViewBag.Categories = _db.Categories.Where(x => x.ID != news.CategoryId).ToList();
            news.Category = _db.Categories.Find(news.CategoryId);
            return View(news);
        }

        // POST: Admin/News/Edit/5
        [HttpPost]
        public ActionResult Edit(News news)
        {
            try
            {
                news.UpdateDate = news.CreateDate = DateTime.Now;
                news.CreateBy = "Hoàng Minh";
                //news.CategoryId = 1;
                _db.News.AddOrUpdate(news);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
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
