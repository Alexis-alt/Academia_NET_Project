using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Services.Account;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MVC.Areas.Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly IHasher _hasher;

        private readonly AuthenticationsService _authService;

        public AccountController(IContenedorTrabajo contenedorTrabajo, IHasher hasher)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hasher = hasher;
            _authService = new AuthenticationsService(_contenedorTrabajo, _hasher);
        }

        // GET: Identity/Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Implementar logica para login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel user)
        {

            if (ModelState.IsValid) {

                var userClaims = _authService.Authenticate(user.Email, user.Password);

                if (userClaims != null)
                {
                    IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;


                    authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

                    AuthenticationProperties props = new AuthenticationProperties();
                    props.IsPersistent = user.RememberMe;

                    authenticationManager.SignIn(props, userClaims);

                    return RedirectToAction("Index", "Articles", new { area = "Admin" });

                }
                else
                {

                    ModelState.AddModelError(string.Empty, "Usuario o contraseña no válidos");

                }



            }

            return View(user);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Account");
        }

    }
}