using Application.Interfaces.Repository;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
   public class ContenedorTrabajo : IContenedorTrabajo
    {

        private readonly DBContext _db;


        public ContenedorTrabajo()
        {
            _db = new DBContext();


            Article = new ArticuloRepository(_db);


            User = new UserRepository(_db);

        }

        public IArticuloRepository Article { get; private set; }

        public IUserRepository User { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
           var x = _db.SaveChanges();
        }
    }
}
