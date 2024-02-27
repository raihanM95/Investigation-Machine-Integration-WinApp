using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineIntegrationWinApp
{
    public class Connection
    {
        public static NpgsqlConnection GetConnection()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["PostgreSqlConnectionString"].ConnectionString;
                NpgsqlConnection con = new NpgsqlConnection(connectionString);
                con.Open(); return con;
            }
            catch (System.Exception)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["PostgreSqlConnectionString"].ConnectionString;
                NpgsqlConnection con = new NpgsqlConnection(connectionString);
                con.Open(); return con;
            }
        }
    }
}
