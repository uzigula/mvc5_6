using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace VirtualOffice.Repositorios.ADO
{
    public class SQLDatabaseContext : IDatabaseContext
    {
        private SqlConnection connection;

        public SQLDatabaseContext(string connectioString)
        {
            connection = new SqlConnection(connectioString);
            connection.Open();
        }
        private IDbCommand GetDbCommand(string commandText)
        {
            if (string.IsNullOrEmpty(commandText))
            {
                throw new ArgumentException(MethodBase.GetCurrentMethod() + " - Parameter cannot be null");
            }

            var command = new SqlCommand(commandText, this.connection);
            return command;
        }

        public void ExecuteCommand(string command, Parameter[] parameters)
        {
            using(var sqlCommand =  GetDbCommand(command))
            {
                SetParameters(parameters, sqlCommand);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public System.Data.IDataReader ExecuteQuery(string query, Parameter[] parameters)
        {
            using (var sqlCommand = GetDbCommand(query))
            {
                SetParameters(parameters, sqlCommand);
                return sqlCommand.ExecuteReader();
            }

        }

        public object ExecuteScalar(string query, Parameter[] parameters)
        {
            using (var sqlCommand = GetDbCommand(query))
            {
                SetParameters(parameters, sqlCommand);
                return sqlCommand.ExecuteScalar();
            }
        }

        private static void SetParameters(Parameter[] parameters, IDbCommand sqlCommand)
        {
            foreach (var param in parameters)
            {
                sqlCommand.Parameters.Add(new SqlParameter(param.Name, param.Value));
            }
        }

        public void Dispose()
        {
            if (connection.State==ConnectionState.Open )  connection.Close();
            connection = null;
        }
    }
}
