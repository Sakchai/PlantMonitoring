using System;
using System.Linq;
using LinqToDB.DataProvider.Oracle;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace Orcl.ConsoleApp
{
	partial class Program
    {
		[Table("STUDENT")]
		public class Student 
		{
			[Column("STUID"), PrimaryKey, Identity]
			public int StudentId { get; set; }
			[Column("FIRSTNAME", Length = 40), Nullable]
			public string FirstName { get; set; }
			[Column("SURNAME", Length = 40), Nullable]
			public string Surname { get; set; }
			[Column("AGE")]
			public int? Age { get; set; }
			[Column("SUBJECTSPASSED")]
			public int? SubjectsPassed { get; set; }
			[Column("GENDER", Length = 1), Nullable]
			public string Gender { get; set; }
		}
		static void Main(string[] args)
        {
			OracleTools.ResolveOracle(typeof(Oracle.ManagedDataAccess.Client.OracleConnection).Assembly);
			LoadOracleMetadata("hr", "hr");


		}

		static DataConnection GetOracleConnection(string connectionString)
		{
			//return OracleTools.CreateDataConnection(connectionString);
			return new DataConnection(new OracleDataProvider("OracleManaged"), connectionString);
		}

		static DataConnection GetOracleConnection(string uid, string password)
		{
			//(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl.QIS.local)))
			return GetOracleConnection(string.Format("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = orcl.QIS.local)));User Id={0};Password={1};", uid, password));
		}
		static void LoadOracleMetadata(string uid, string password)
		{
			using (var db = GetOracleConnection(uid, password))
			{
				var query = db.GetTable<Student>();
				var student = query.Where(x => x.FirstName.Equals("Sakchai")).FirstOrDefault();

				Console.WriteLine($"{student.FirstName} {student.Surname}");
				var students = db.GetTable<Student>().ToList();
				foreach (var item in students)
				{
					Console.WriteLine($"{item.FirstName}");
				}
			}
			Console.ReadLine();

		}


	}
}
