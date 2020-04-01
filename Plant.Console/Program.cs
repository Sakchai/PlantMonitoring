using Autofac;
using LinqToDB.DataProvider.Oracle;
using Plant.Model;
using Plant.Services;
using System;

namespace Plant.Console
{
    class Program
    {
		static void Main(string[] args)
		{
			OracleTools.ResolveOracle(typeof(Oracle.ManagedDataAccess.Client.OracleConnection).Assembly);

			var builder = new ContainerBuilder();
			builder.RegisterType<BaseDataProvider>().AsImplementedInterfaces().InstancePerLifetimeScope();
			//data layer
			builder.RegisterType<DataProviderManager>().As<IDataProviderManager>().InstancePerDependency();
			builder.Register(context => context.Resolve<IDataProviderManager>().DataProvider).As<IPlantDataProvider>().InstancePerDependency();

			builder.RegisterType<PlantContext>().AsImplementedInterfaces().InstancePerLifetimeScope();

			builder.RegisterGeneric(typeof(EntityRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

			builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
			using (var container = builder.Build())
			{
				var studentService = container.Resolve<IStudentService>();
				var students = studentService.GetStudentsList();
				foreach (var item in students)
				{
					System.Console.WriteLine($"{item.FirstName}");
				}
			}
		}
    }
}
