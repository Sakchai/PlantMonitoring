using Autofac;
using Plant.Model;
using Plant.Services;
using LinqToDB.DataProvider.Oracle;
using Oracle.ManagedDataAccess.Client;

namespace Plant.Web
{
    public class AutofacModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.

            OracleTools.ResolveOracle(typeof(OracleConnection).Assembly);

            builder.RegisterType<BaseDataProvider>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //data layer
            builder.RegisterType<DataProviderManager>().As<IDataProviderManager>().InstancePerDependency();
            builder.Register(context => context.Resolve<IDataProviderManager>().DataProvider).As<IPlantDataProvider>().InstancePerDependency();

            builder.RegisterType<PlantContext>().AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope();
            builder.RegisterType<CountryService>().As<ICountryService>().InstancePerLifetimeScope();
        }
    }
}
