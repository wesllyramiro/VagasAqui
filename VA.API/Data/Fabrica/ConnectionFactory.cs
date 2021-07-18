using System.Data;
using System.Data.SqlClient;

namespace VA.API.Data.Fabrica
{
    public class ConnectionFactory : IConnectionFactory
    {
        public static SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(
                "Persist Security Info=False;User ID=sa;Password=Sa.12345678; Initial Catalog=VagasAqui;Server=localhost");
        }
        public IDbConnection CreateSqlConnectionOpened()
        {
            var connection = CreateSqlConnection();

            connection.Open();

            return connection;
        }
    }
}
