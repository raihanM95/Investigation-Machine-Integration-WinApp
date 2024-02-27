using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineIntegrationWinApp
{
    public class Common
    {
        public string GetMaxId(string tableName, string columnName, int IdRightLength)
        {
            string maxId = "1";
            using (NpgsqlConnection objConnection = Connection.GetConnection())
            {
                string query = string.Format(@"select max(CAST(RIGHT({0},{1})as decimal)) as MaxColoumn from {2}", columnName, IdRightLength, tableName);
                NpgsqlCommand cmd = new NpgsqlCommand (query, objConnection);
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (!string.IsNullOrEmpty(dataReader["MaxColoumn"].ToString()))
                        {
                            maxId = (Convert.ToInt32(dataReader["MaxColoumn"].ToString()) + 1).ToString();
                        }
                    }
                }
                objConnection.Close();
            }
            return maxId;
        }
    }
}
