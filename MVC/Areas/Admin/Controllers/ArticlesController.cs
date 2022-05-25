using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Services.Articles;
using Domain.Models;
using Persistence;
using Persistence.Contexts;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Authorize]
    public class ArticlesController : Controller
    {

        private readonly IMemoryStorage<Article> _memoryStorage;

        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly ArticlesServices _articlesServices;

        //Cuando configuremos la inyección de dependencias inyectamos en el constructor 
        public ArticlesController(IContenedorTrabajo contenedorTrabajo)
        {
            _memoryStorage = new MemoryStorage<Article>();

            _contenedorTrabajo = contenedorTrabajo;

            _articlesServices = new ArticlesServices(_contenedorTrabajo);

        }

        // GET: Admin/Articles
        [HttpGet]
        public ActionResult Index()
        {
           
            var articles = _articlesServices.GetAll();

            return View(articles.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {

                _articlesServices.Create(article);

                return RedirectToAction(nameof(Index));

            }


            return View(article);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var article = _articlesServices.GetById(id);
         
            return View(article);
        }

  
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                _articlesServices.Edit(article);

                return RedirectToAction(nameof(Index));

            }

            return View(article);
        }

        public ActionResult Delete(int id)
        {

            _articlesServices.Delete(id);


            return RedirectToAction(nameof(Index));
        }




    }
}