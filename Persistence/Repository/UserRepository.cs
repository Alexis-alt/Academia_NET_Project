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
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly DBContext _db;

        public UserRepository(DBContext db) : base(db)
        {
            _db = db;
        }


        public void Update(User user)
        {

            var userUpdate = _db.User.Find(user.Id);

            userUpdate.Name = user.Name;
            userUpdate.LastName = user.LastName;
            userUpdate.UserName = user.UserName;
            userUpdate.PasswordHashed = user.PasswordHashed;
        }
    }
}
