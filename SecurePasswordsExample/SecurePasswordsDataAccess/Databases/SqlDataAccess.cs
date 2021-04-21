namespace SecurePasswordsDataAccess.Databases
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    
    public class SqlDataAccess : IDataAccess
    {
        public List<T> LoadData<T, U>(
            string sqlStatement, 
            U parameters, 
            string connectionString, 
            bool isStoredProcedure = false)
        {
            var commandType = isStoredProcedure == true ? CommandType.StoredProcedure : CommandType.Text;

            using IDbConnection connection = new SqlConnection(connectionString);
            var rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
            return rows;
        }

        public void SaveData<T>(
            string sqlStatement, 
            T parameters, 
            string connectionString,
            bool isStoredProcedure = false)
        {
            var commandType = isStoredProcedure == true ? CommandType.StoredProcedure : CommandType.Text;

            using IDbConnection connection = new SqlConnection(connectionString);
            connection.Execute(sqlStatement, parameters, commandType: commandType);
        }
        
    }
}
