using Application.Interfaces;
using Application.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Articles
{
   public class ArticlesServices
    {

        private readonly IMemoryStorage<Article> _memoryStorage;

        private readonly IContenedorTrabajo _contenedorTrabajo;



        public ArticlesServices( IContenedorTrabajo contenedorTrabajo)
        {
           
            _contenedorTrabajo = contenedorTrabajo;
        }


        public ArticlesServices(IMemoryStorage<Article> memoryStorage)
        {
            _memoryStorage = memoryStorage;
        }


        public void Create(Article article)
        {

           
            
            /*MemoryStorage
             * 
             return _memoryStorage.Create(article);

            */

            _contenedorTrabajo.Article.Add(article);

            _contenedorTrabajo.Save();

  
        }


        public void Edit(Article article)
        {

            /* MemoryStorage
             * 
            _memoryStorage.Edit(article);

            */

            _contenedorTrabajo.Article.Update(article);

            _contenedorTrabajo.Save();


        }


        public void Delete(int id)
        {
            /*MemoryStorage
            _memoryStorage.Delete(id);
            */

            _contenedorTrabajo.Article.Remove(id);

            _contenedorTrabajo.Save();

        }

        public List<Article> GetAll()
        {

            /*MemoryStorage
             * 
              _memoryStorage.GetAll();
             
             */
            return _contenedorTrabajo.Article.GetAll().ToList();
        }

        public Article GetById(int id)
        {
            /*MemoryStorage
             
            _memoryStorage.GetById(id);

             */


            return _contenedorTrabajo.Article.GetById(id);
        }


    }
}
