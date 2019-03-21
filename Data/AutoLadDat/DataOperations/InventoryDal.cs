namespace AutoLadDat.DataOperations
{
    using AutoLadDat.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class InventoryDal : IDisposable
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public InventoryDal(string connectionString)
        {
            _connectionString = connectionString ?? throw (new ArgumentNullException("connectionString cannot be empty"));
            OpenConnection();
        }

        public InventoryDal() :this(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=AutoLot;Integrated Security=True")
        {
        }

        private void OpenConnection()
        {
            _connection = new SqlConnection(connectionString: _connectionString);

            if (_connection != null)
            {
                _connection.Open();
            } else
            {
                throw new Exception($"Error opening Connection: {_connectionString}");
            }
        }

        private void CloseConnection()
        {
            if (_connection?.State != ConnectionState.Closed)
            {
                _connection?.Close();
            }
        }

        public List<Car> GetAllInventory()
        {
            // This will hold the records.
            List<Car> inventory = new List<Car>();

            // Prep command object.
            string sql = "Select * From Inventory";
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }
            return inventory;
        }

        public Car GetCar(int id)
        {
            Car car = null;
            string sql = $"Select * From Inventory where CarId = {id}";
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                command.CommandType = CommandType.Text;
                SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (dataReader.Read())
                {
                    car = new Car
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    };
                }
                dataReader.Close();
            }
            return car;
        }

        public void InsertAuto(Car car)
        {
            // Format and execute SQL statement.
            string sql = $"Insert Into Inventory (Make, Color, PetName) Values ('{car.Make}', '{car.Color}', '{car.PetName}')";
            // Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
        }

        public void InsertAuto(string make, string color, string petname)
        {
            // Format and execute SQL statement.
            string sql = $"Insert Into Inventory (Make, Color, PetName) Values ('{make}', '{color}', '{petname}')";
            // Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
        }

        public void BetterInsertAuto(Car car)
        {
            // Note the "placeholders" in the SQL query.
            string sql = "Insert Into Inventory" +
              "(Make, Color, PetName) Values" +
              "(@Make, @Color, @PetName)";
            // This command will have internal parameters.
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                // Fill params collection.
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@Make",
                    Value = car.Make,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@Color",
                    Value = car.Color,
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                };
                command.Parameters.Add(parameter);

                parameter = new SqlParameter
                {
                    ParameterName = "@PetName",
                    Value = car.PetName,
                    SqlDbType = SqlDbType.Char,
                    Size = 10
                };
                command.Parameters.Add(parameter);

                command.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            // Get ID of car to delete, then do so.
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            // Get ID of car to modify the pet name.
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCar(Car car)
        {
            string sql = $"update Inventory set PetName = '{car.PetName}', Make = '{car.Make}', Color = '{car.Color}' Where CarId= '{car.CarId}'" ;
            try
            {
                using (SqlCommand updateCmd = new SqlCommand(sql, _connection))
                {
                    updateCmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Cannot add car {car.ToString()}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public string LookUpPetName(int carId)
        {
            string carPetName;

            SqlParameter inputParam = new SqlParameter
            {
                ParameterName = "@carId",
                SqlDbType = SqlDbType.Int,
                Value = carId,
                Direction = ParameterDirection.Input
            };
            SqlParameter outputParam = new SqlParameter
            {
                ParameterName = "@petName",
                SqlDbType = SqlDbType.Char,
                Size = 10,
                Direction = ParameterDirection.Output
            };

            // Establish name of stored proc.
            using (SqlCommand command = new SqlCommand("GetPetName", _connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(inputParam);
                command.Parameters.Add(outputParam);

                // Execute the stored proc.
                command.ExecuteNonQuery();

                // Return output param.
                carPetName = (string)command.Parameters["@petName"].Value;
            }
            return carPetName;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public Customer GetCustomer(int custId)
        {
            string firstName;
            string lastName;


            var cmdSelect = new SqlCommand($"Select * from Customers where CustId=@CustId", _connection);
            cmdSelect.Parameters.Add(DataHelper.GetCustomerIdParameter(custId));

            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    firstName = (string)dataReader["FirstName"];
                    lastName = (string)dataReader["LastName"];
                }
                else
                {
                    return null;
                }
            }

            return new Customer
            {
                CustId = custId,
                FirstName = firstName,
                LastName = lastName
            };
        }

        public void DeleteCustomer(int custId)
        {
            var cmdDelete = new SqlCommand($"Delete from Customers where CustId=@CustId", _connection);
            cmdDelete.Parameters.Add(DataHelper.GetCustomerIdParameter(custId));

            try
            {
                cmdDelete.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting customer {custId}: {ex.Message}");
            }
        }

        public void InsertCustomer(Customer customer)
        {
            var cmdInsert = new SqlCommand($"insert into Customers (FirstName, LastName) values (@FirstName, @LastName)", _connection);
            cmdInsert.Parameters.Add(DataHelper.GetCustomerFirstNameParameter(customer.FirstName));
            cmdInsert.Parameters.Add(DataHelper.GetCustomerLastNameParameter(customer.LastName));

            try
            {
                cmdInsert.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error deleting customer {customer.ToString()}: {ex.Message}");
            }
        }

        public void ProcessCreditRisk(int custId)
        {
            var customer = GetCustomer(custId);

            var cmdInsert = new SqlCommand($"insert into CreditRisks (FirstName, LastName) values (@FirstName, @LastName)", _connection);
            cmdInsert.Parameters.Add(DataHelper.GetCustomerFirstNameParameter(customer.FirstName));
            cmdInsert.Parameters.Add(DataHelper.GetCustomerLastNameParameter(customer.LastName));

            var cmdDelete = new SqlCommand($"Delete from Customers where CustId=@CustId", _connection);
            cmdDelete.Parameters.Add(DataHelper.GetCustomerIdParameter(custId));

            // We will get this from the connection object.
            SqlTransaction tx = null;
            try
            {
                tx = _connection.BeginTransaction();

                // Enlist the commands into this transaction.
                cmdInsert.Transaction = tx;
                cmdDelete.Transaction = tx;

                // Execute the commands.
                cmdInsert.ExecuteNonQuery();
                cmdDelete.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                // Any error will roll back transaction.  Using the new conditional access operator to check for null.
                tx?.Rollback();
            }
        }

        public void Dispose()
        {
            CloseConnection();
        }
    }
}
