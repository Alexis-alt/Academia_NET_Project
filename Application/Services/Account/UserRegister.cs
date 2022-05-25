using Application.Interfaces;
using Application.Interfaces.Repository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Account
{
    public class UserRegister
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;


        private readonly IHasher _hasher;

        public UserRegister(IContenedorTrabajo contenedorTrabajo,IHasher hasher)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hasher = hasher;
        }


        public  void Create(User user)
        {

            user.PasswordHashed = _hasher.HashPassword(user.PasswordHashed);

            _contenedorTrabajo.User.Add(user);

            _contenedorTrabajo.Save();

        }


        public void Update(User user)
        {
            _contenedorTrabajo.User.Update(user);

            _contenedorTrabajo.Save();

        }

        public void Delete(int id)
        {
            _contenedorTrabajo.User.Remove(id);

            _contenedorTrabajo.Save();

        }

        public User GetById(int id)
        {
     
           return _contenedorTrabajo.User.GetById(id);
        }


        public List<User> GetAll(int id)
        {
           return _contenedorTrabajo.User.GetAll().ToList();
        }

    }
}
