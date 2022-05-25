using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Services.Articles;
using Domain.Models;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace WebAPI.Controllers
{
    public class ArticlesController : ApiController
    {


        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly ArticlesServices _articlesServices;


        public ArticlesController()
        {
            _contenedorTrabajo = new ContenedorTrabajo();

            _articlesServices = new ArticlesServices( _contenedorTrabajo);

        }


        [HttpPost]
        public IHttpActionResult Create([FromBody] Article article)
        {
            try
            {
                _articlesServices.Create(article);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Something was wrong {ex.Message}");
            }

        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Article article)
        {
            try
            {
                _articlesServices.Edit(article);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Something was wrong {ex.Message}");
            }

        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] int id)
        {
            try
            {
                _articlesServices.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Something was wrong {ex.Message}");
            }

        }


        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var article = _articlesServices.GetById(id);

                return Ok(article);
            }
            catch (Exception ex)
            {

                return BadRequest($"Something was wrong {ex.Message}");
            }

        
        }


        [HttpGet]
        public IHttpActionResult GetAll()
        {
            try
            {
                var articles = _articlesServices.GetAll();

                return Ok(articles);
            }
            catch (Exception ex)
            {

                return BadRequest($"Something was wrong {ex.Message}");
            }


        }



    }
}