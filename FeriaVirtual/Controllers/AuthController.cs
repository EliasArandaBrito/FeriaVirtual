using FeriaVirtual.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using System.Net;
namespace FeriaVirtual.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario, string ReturnUrl)
        {
            if (IsValid(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                //FormsAuthentication.SetAuthCookie(usuario.Id.ToString(), false);

                // Obtén el rol del usuario autenticado
                var rolUsuario = usuario.ObtenerRolUsuario();
                var idUsuario = usuario.ObtenerIdUsuario();

                // Agrega una declaración de depuración para verificar el rol del usuario
                System.Diagnostics.Debug.WriteLine("Rol del usuario: " + rolUsuario);
                System.Diagnostics.Debug.WriteLine("Id del usuario: " + idUsuario);


                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }

                // Guarda el rol del usuario en una variable de sesión para su posterior uso
                Session["Roles"] = rolUsuario;
                Session["UserID"] = idUsuario;
                Session["ContratoID"] = 0;

                return RedirectToAction("Index", "Home");
            }
            TempData["mensaje"] = "Credenciales Incorrectas";
            return View(usuario);
        }

        private bool IsValid(Usuario usuario)
        {
            return usuario.Autenticar();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }



    }
}