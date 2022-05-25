using Application.Interfaces;
using Application.Interfaces.Repository;
using Domain.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Account
{
    public class AuthenticationsService
    {



        private readonly IContenedorTrabajo _contenedorTrabajo;

        private readonly IHasher _hasher;


        public AuthenticationsService(IContenedorTrabajo contenedorTrabajo, IHasher hasher)
        {
            _hasher = hasher;
            _contenedorTrabajo = contenedorTrabajo;
        }


        public ClaimsIdentity Authenticate(string useranme,string password)
        {
            ClaimsIdentity identity = null;

            //Hasehar el password


            var user = _contenedorTrabajo.User.FirstOrDefaul(u=>u.UserName==useranme);

            var passwordHashed = _hasher.HashPassword(password);

            if (user != null && user.PasswordHashed == passwordHashed)
            {

                var claims = CreateClaims(user);

                identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            }

            return identity;

        }



        private IEnumerable<Claim> CreateClaims(User user)
        {
            //Los claims son un par nombre-valor que representa al usurio o sujeto, no lo que el usuario puede hacer
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.Name),
               
            };
        }


    }
}
