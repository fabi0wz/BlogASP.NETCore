using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetBlog.Controllers
{
    public class Post_ImagesController : Controller
    {
        // GET: Post_Images
        public ActionResult Index()
        {
            return View();
        }

        // GET: Post_Images/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post_Images/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post_Images/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post_Images/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post_Images/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Post_Images/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post_Images/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}