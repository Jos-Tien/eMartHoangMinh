using eMartHoangMinh.Models;
using eMartHoangMinh.Models.FE;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace eMartHoangMinh.Areas.Admin.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Admin/Posts
        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            var pageIndex = page.HasValue ? page.Value : 1;
            var posts = _db.Posts.OrderByDescending(x => x.CreateDate).ToPagedList(pageIndex, pageSize);
            return View(posts);
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            var post = new Post();
            return View(post);
        }

        // POST: Admin/Posts/Create
        [HttpPost]
        public ActionResult Create(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    post.CreateDate = post.UpdateDate = DateTime.Now.Date;
                    post.CreateBy = "Hoàng Minh";
                    post.CategoryId = 1;
                    post.Alias = Helpers.Helper.Instance.RemoveSign4VietnameseString(post.SeoTitle);
                    _db.Posts.Add(post);
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int id)
        {
            var post = _db.Posts.Find(id);
            post.Category = _db.Categories.Find(post.CategoryId);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            try
            {
                post.UpdateDate = post.CreateDate = DateTime.Now;
                post.CreateBy = "Hoàng Minh";
                _db.Posts.AddOrUpdate(post);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Admin/Posts/Delete/5
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
