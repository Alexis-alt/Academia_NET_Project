using Application.Interfaces.Repository;
using Domain.Models;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    class ArticuloRepository : Repository<Article>, IArticuloRepository
    {


        private readonly DBContext _db;

        public ArticuloRepository(DBContext db):base(db)
        {
            _db = db;
        }


        public void Update(Article article)
        {
           var articleUpdate = _db.Article.Find(article.Id);

            articleUpdate.Name = article.Name;
            articleUpdate.Description = article.Description;
            articleUpdate.Price = article.Price;


        }
    }
}
