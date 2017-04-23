using CargaExcel.Tables;
using MOD1;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CargaExcel
{
    class Data
    {
        private static Data data;
        private string connString;

        private Data() {
            connString = Conex.cadena;
        }

        public static Data getInstance()
        {
            if (data == null) data = new Data();
            return data;
        }

        public void WriteToDatabase(Forecast forecast)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command;                

                command = new SqlCommand(forecast.deleteProcedure);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.ExecuteNonQuery();

                command = new SqlCommand(forecast.storedProcedure);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter(forecast.parameterName, forecast.dataTable));
                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void executeStoredProcedure(string procedure)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                SqlCommand command;

                command = new SqlCommand(procedure);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
