
using System.Configuration;
using System.Data.SqlClient;


namespace TestSIE.Classes
{
    public static class ConexionBD
    {
        public static SqlConnection ObtenerConexion()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            return new SqlConnection(connectionString);
        }
    }

}
