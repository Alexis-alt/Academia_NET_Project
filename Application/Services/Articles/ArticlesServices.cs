using Application.Interfaces;
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

        public ArticlesServices(IMemoryStorage<Article> memoryStorage)
        {
            _memoryStorage = memoryStorage;
        }


        public string Create(Article article)
        {
           return _memoryStorage.Create(article);
        }

        public string Edit(Article article)
        {
            return _memoryStorage.Edit(article);
        }

        public string Delete(string id)
        {
            return _memoryStorage.Delete(id);
        }

        public List<Article> GetAll()
        {
            return _memoryStorage.GetAll();
        }

        public Article GetById(string id)
        {
            return _memoryStorage.GetById(id);
        }


    }
}
