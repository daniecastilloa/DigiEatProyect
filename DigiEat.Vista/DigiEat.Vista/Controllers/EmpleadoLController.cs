using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiEat.Vista.Controllers
{
    public class EmpleadoLController : Controller
    {
        // GET: EmpleadoL
        public ActionResult EmpleadoL()
        {
            return View();
        }

        // GET: EmpleadoL/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoL/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoL/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("EmpleadoL");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoL/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoL/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("EmpleadoL");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoL/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoL/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("EmpleadoL");
            }
            catch
            {
                return View();
            }
        }
    }
}
