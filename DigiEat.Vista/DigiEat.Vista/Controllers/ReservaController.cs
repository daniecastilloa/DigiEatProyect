using Digieat.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Digieat.Negocio;



namespace DigiEat.Vista.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Reserva()
        {
            
            return View();
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reserva/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "NUM_RESERVA,FECHA,HORA,CLIENTE_RUT,CANTIDAD_PERSONAS")] Reserva reserva)
        {
            //Para testing rellenar rut de un cliente ya existente, de preferencia traer el del usuario que ya esta logueado en ese momento
            try
            {

                if(reserva.AgregarReserva())
                {
                    TempData["mensaje"] = "Reserva creada exitosamente";
                   
                }
                return RedirectToAction("Reserva");
            }
            catch
            {
                TempData["mensaje"] = "No se pudo crear reserva";
                return View(reserva);
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Reserva");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Reserva");
            }
            catch
            {
                return View();
            }
        }

    }
}
