using Application.Interfaces;
using Application.Interfaces.Repository;
using Application.Tools;
using Autofac;
using Autofac.Integration.Mvc;
using Persistence;
using Persistence.Repository;
using System.Web.Mvc;

namespace MVC
{
    public class IoCConfig
    {


        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();


            //Registar los controllers 
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ContenedorTrabajo>().As<IContenedorTrabajo>();

            builder.RegisterType<Hasher>().As<IHasher>();

            // builder.RegisterType<MemoryStorage<T>>().As<IMemoryStorage<T>>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }



    }
}