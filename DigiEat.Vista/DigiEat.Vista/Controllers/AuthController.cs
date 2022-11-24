using Digieat.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;


namespace DigiEat.Vista.Controllers
{
    public class AuthController : Controller
    {
       //Autentifacion artefacto
       public ActionResult Login()
        {
            ViewBag.clientes = new Cliente().ObtenerCliente();
            ViewBag.buscars = new Cliente().ObtenerNombre();
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(Cliente cliente, string ReturnUrl)
        {
            if(isValid(cliente))
            {
                FormsAuthentication.SetAuthCookie(cliente.correo, false);
                if(ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Cliente");

            }
            TempData["mensaje"] = "Credenciales incorrectas";
            return View(cliente);
        }

        private bool isValid(Cliente cliente)
        {
            return cliente.Autenticar();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        /*TODO DE AQUI PARA ABAJO SE PODRA OCUPAR PARA REALIZAR LA RESERVA*/
        /*----------------------------------------------------------------*/
        /*----------------------------------------------------------------*/
        /*----------------------------------------------------------------*/
        /*----------------------------------------------------------------*/

        // POST: Empleado/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //   try
        //  {
        // TODO: Add insert logic here

        //    return RedirectToAction("Empleado");
        //}
        //catch
        //{
        //   return View();
        //}
        //}

        // GET: Empleado/Edit/5
        //public ActionResult Edit(int id)
        //{
        //   return View();
        //}

        // POST: Empleado/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //   try
        // {
        // TODO: Add update logic here

        //   return RedirectToAction("Empleado");
        //}
        //catch
        //{
        //  return View();
        //}
        //}

        // GET: Empleado/Delete/5
        //public ActionResult Delete(int id)
        //{
        //   return View();
        //}

        // POST: Empleado/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //  try
        //  {
        // TODO: Add delete logic here

        //    return RedirectToAction("Empleado");
        //}
        //catch
        //{
        //  return View();
        //}
        //}


    }
}