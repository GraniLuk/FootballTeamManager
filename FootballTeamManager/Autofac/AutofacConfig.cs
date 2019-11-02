using Autofac;
using Autofac.Integration.Mvc;
using FootballTeamManager.Models;
using System.Configuration;
using System.Reflection;
using System.Web.Mvc;

namespace FootballTeamManager.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            var executingAssembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(executingAssembly)
            .AsSelf()
            .AsImplementedInterfaces();

            builder.RegisterType<DoodleParser.Client>()
                .As<DoodleParser.IClient>()
                .WithParameter(new TypedParameter(typeof(string), ConfigurationManager.AppSettings[Properties.DoodleApi]));

            builder.RegisterType<ApplicationDbContext>();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}