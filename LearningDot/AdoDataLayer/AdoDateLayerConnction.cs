using Microsoft.Data.SqlClient;
using System.Data;

namespace LearningDot.AdoDataLayer
{
    public class AdoDateLayerConnction
    {
      
            private static string SqlConnectionString = "Data Source=DESKTOP-T918QFB\\SQLEXPRESS02;Initial Catalog=village;Integrated Security=True;TrustServerCertificate=True";
            public static SqlDataReader GetDataReaderFromStoredProcedure(string storedProcedureName, SqlParameter[] parameters = null)
            {
                SqlConnection sqlConnection = new SqlConnection();
                SqlCommand sqlCommand = new SqlCommand();

                sqlConnection.ConnectionString = SqlConnectionString;
                sqlConnection.Open();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = storedProcedureName;
                sqlCommand.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                return sqlDataReader;
            }



            public static int SaveInformation(string query, SqlParameter[] parameters = null)
            {
                SqlConnection sqlConnection = new SqlConnection();
                SqlCommand sqlCommand = new SqlCommand();

                sqlConnection.ConnectionString = SqlConnectionString;
                sqlConnection.Open();

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = query;
                sqlCommand.CommandType = CommandType.Text;

                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }

                int count = sqlCommand.ExecuteNonQuery();
                return count;
            }
        
    }
}
