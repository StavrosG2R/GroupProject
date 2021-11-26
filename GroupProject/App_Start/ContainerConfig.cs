using Autofac;
using Autofac.Integration.Mvc;
using DataAccess.Core.Interfaces;
using DataAccess.Persistence;
using System.Web.Mvc;

namespace GroupProject.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register ApplicationDbContext
            builder.RegisterType<ApplicationDbContext>()
                .InstancePerLifetimeScope();
                

            // Register UnitOfWork
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}