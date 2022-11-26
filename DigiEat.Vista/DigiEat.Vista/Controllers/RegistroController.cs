using Digieat.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiEat.Vista.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Registro()
        {
            return View();
        }

        // GET: Registro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registro/Create
        public ActionResult Create()
        {
            EnviarClientes();
            return View();
        }

        private void EnviarClientes()
        {
            ViewBag.clientes = new Cliente().ObtenerCliente();
        }

        // POST: Registro/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "rut_cliente,nombre,apellido_pat,apellido_mat,telefono,correo,contrasena,estado_cuenta,mesa_num_mesa")] Cliente cliente)
        {
            if (cliente.AgregarCliente()) { 
                // TODO: Add insert logic here
                
                TempData["mensajito"] = "Usuario Creado Correctamente";
                return RedirectToAction("Registro");
            }
            else
            {
                return View(cliente);
            }
        }

        // GET: Registro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Registro");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Registro");
            }
            catch
            {
                return View();
            }
        }
    }
}
