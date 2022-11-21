using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiEat.Vista.Controllers
{
    public class LaCartaController : Controller
    {
        // GET: LaCarta
        [HttpGet]
        public ActionResult LaCarta()
        {
            return View();
        }

        // GET: LaCarta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LaCarta/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaCarta/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("LaCarta");
            }
            catch
            {
                return View();
            }
        }

        // GET: LaCarta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LaCarta/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("LaCarta");
            }
            catch
            {
                return View();
            }
        }

        // GET: LaCarta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LaCarta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("LaCarta");
            }
            catch
            {
                return View();
            }
        }
    }
}
