using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Areas.OnlineStore.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: OnlineStore/Product
        public ActionResult Index()
        {
            return View();
        }

        // GET: OnlineStore/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OnlineStore/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OnlineStore/Product/Create
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

        // GET: OnlineStore/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OnlineStore/Product/Edit/5
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

        // GET: OnlineStore/Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OnlineStore/Product/Delete/5
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
