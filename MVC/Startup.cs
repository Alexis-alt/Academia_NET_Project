using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;


namespace MVC
{
    public class Startup
    {
        /*Agregamos esta clase para configurar la Authentication
         * 
        */


        public void Configuration(IAppBuilder app)
        {
            // Para obtener más información sobre cómo configurar la aplicación, visite https://go.microsoft.com/fwlink/?LinkID=316888

            CookieAuthenticationOptions options = new CookieAuthenticationOptions();

            //Usamos cookies para guardar la autenticación del usuario en la webApplication
            options.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;

            //Ruta de inicio de sesión
            options.LoginPath = new PathString("/Identity/Account/Login");

           

            app.UseCookieAuthentication(options);

            

        }
    }
}
