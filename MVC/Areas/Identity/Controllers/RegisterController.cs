using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Services.Account;
using Domain.Models;
using MVC.Areas.Identity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Identity.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly IHasher _hasher;

        private readonly UserRegister _userRegister;

        public RegisterController(IContenedorTrabajo contenedorTrabajo, IHasher hasher)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hasher = hasher;

            _userRegister = new UserRegister(_contenedorTrabajo, _hasher);
        }


        // GET: Identity/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {


            if (ModelState.IsValid) {

                _userRegister.Create(new User()
                {

                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.Email,
                    PasswordHashed = user.Password

                });

                return RedirectToAction("Login", "Account", new { area = "Identity" });



            }

            return View(user);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            

            return View();
        }


    }
}