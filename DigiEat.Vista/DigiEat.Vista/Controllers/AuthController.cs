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
            return View();
        }

        [HttpPost]
        public ActionResult Login(Cliente cliente, string ReturnUrl)
        {
            if(isValid(cliente))
            {
                FormsAuthentication.SetAuthCookie(cliente.CORREO, false);
                if(ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Home");

            }
            
            return View(cliente);
        }

        private bool isValid( Cliente cliente)
        {
            if(cliente.CORREO == "admin@admin.cl" && cliente.CONTRASEÑA == "admin" )
            {
                return true;
            }

            return false;
        }
    }
}