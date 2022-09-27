using System.Data;
using System.Data.SqlClient;

namespace NiksDoughnuts.Web
{
    static internal class DbConfig
    {
        static internal IDbConnection CreateDbConnection(ConfigurationManager configuration)
        {
            string connectionString = "server=localhost;database=Niks Doughnuts;user id=sa;password=Scale_Us3r;"; //configuration["CONNECTION_STRING"];
            
            if(connectionString == null)
            {
                throw new Exception("No Connection String present");
            }

            return new SqlConnection(connectionString);
        }
    }
}
