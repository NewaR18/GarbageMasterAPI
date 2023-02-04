using OurProject.SqlConnector;
using System.Data;
using System.Data.SqlClient;

namespace OurProject.Repository
{
    public class ConnRepo
    {
        public SqlConnection Connection()
        {
            string constr = new Connection().GetConnectionString();
            SqlConnection connection = new SqlConnection(constr);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            return connection;
        }

    }
}
