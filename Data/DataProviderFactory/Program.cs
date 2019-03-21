namespace DataProviderFactory
{
    using System.Configuration;
    using System.Data.Common;
    using static System.Console;

    class Program
    {
        static void Main(string[] args)
        {
            var dataProvider = ConfigurationManager.AppSettings["Provider2"];
            var connectionString = ConfigurationManager.ConnectionStrings["AutoLotOleDbProvider"].ConnectionString;

            var factory = DbProviderFactories.GetFactory(dataProvider);

            var connection = factory.CreateConnection();
            if (connection == null)
            {
                ShowError("connection");
                return;
            }
            WriteLine($"Your connection object is a: {connection.GetType().Name}");
            connection.ConnectionString = connectionString;
            connection.Open();

            // Make command object.
            DbCommand command = factory.CreateCommand();
            if (command == null)
            {
                ShowError("Command");
                return;
            }
            WriteLine($"Your command object is a: {command.GetType().Name}");
            command.Connection = connection;
            command.CommandText = "Select * From Inventory";

            // Print out data with data reader.
            using (DbDataReader dataReader = command.ExecuteReader())
            {
                WriteLine($"Your data reader object is a: {dataReader.GetType().Name}");

                WriteLine("\n***** Current Inventory *****");

                while (dataReader.Read())
                    WriteLine($"-> Car #{dataReader["CarId"]} is a {dataReader["Make"]}.");
            }

            ReadLine();
        }

        private static void ShowError(string objectName)
        {
            WriteLine($"There was an issue creating the {objectName}");
            ReadLine();
        }

    }
}
