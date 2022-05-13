using Application.Interfaces;
using Application.Services.Articles;
using Domain.Models;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IMemoryStorage<Article> _memoryStorage;

        public ArticlesController()
        {
            _memoryStorage = new MemoryStorage<Article>();
        }

        // GET: Admin/Articles
        [HttpGet]
        public ActionResult Index()
        {
            var articleServices = new ArticlesServices(_memoryStorage);

            var articles = articleServices.GetAll();

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
            var articleServices = new ArticlesServices(_memoryStorage);

            articleServices.Create(article);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var articleServices = new ArticlesServices(_memoryStorage);

            var article = articleServices.GetById(id);
         
            return View(article);
        }


        public ActionResult Edit(Article article)
        {
            var articleServices = new ArticlesServices(_memoryStorage);

            articleServices.Edit(article);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(string id)
        {
            var articleServices = new ArticlesServices(_memoryStorage);

            articleServices.Delete(id);


            return RedirectToAction(nameof(Index));
        }




    }
}