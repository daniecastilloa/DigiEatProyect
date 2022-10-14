using Digieat.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;


namespace DigiEat.Vista.Controllers
{
    public class EmpleadoController : Controller
    {
        // Autentificacion
        public ActionResult Empleado()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Empleado(Empleado empleado, string ReturnUrl)
        {
            if(isValid(empleado))
            {
                FormsAuthentication.SetAuthCookie(empleado.correo, false);
                if(ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("EmpleadoL", "EmpleadoL");

            }
            TempData["mensaje"] = "Las Credenciales ingresadas fueron incorrectas";
            return View(empleado);
        }
        private bool isValid(Empleado empleado)
        {
            return empleado.Autenticar();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
