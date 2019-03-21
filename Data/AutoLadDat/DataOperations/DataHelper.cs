namespace AutoLadDat.DataOperations
{
    using System.Data;
    using System.Data.SqlClient;

    static class DataHelper
    {
        public static SqlParameter GetCustomerIdParameter(int custId, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                ParameterName = "@CustId",
                SqlDbType = SqlDbType.Int,
                Value = custId,
                Direction = direction
            };
        }

        public static SqlParameter GetCustomerFirstNameParameter(string firstName, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.Char,
                Value = firstName,
                Direction = direction
            };
        }

        public static SqlParameter GetCustomerLastNameParameter(string lastName, ParameterDirection direction = ParameterDirection.Input)
        {
            return new SqlParameter
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.Char,
                Value = lastName,
                Direction = direction
            };
        }


    }
}
