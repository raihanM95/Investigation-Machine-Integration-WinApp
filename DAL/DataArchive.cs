using MachineIntegrationWinApp.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MachineIntegrationWinApp.DAL
{
    public class DataArchive
    {
        public bool Save(List<SampleResult> results)
        {
            bool response = false;
            DateTime date = DateTime.Now;
            var sample_id = new Common().GetMaxId("sample", "sample_id", 5);

            using (NpgsqlConnection objConnection = Connection.GetConnection())
            {
                NpgsqlTransaction transaction = objConnection.BeginTransaction();

                string query = string.Format(@"INSERT INTO public.sample(sample_id,sample_date,barcode_or_level) VALUES ('{0}','{1}','{2}')",
                sample_id, date, results[0].barcode_or_level.Replace("'", "''"));
                NpgsqlCommand cmd = new NpgsqlCommand(query, objConnection, transaction);
                cmd.ExecuteNonQuery();

                foreach (var result in results)
                {
                    query = string.Format(@"INSERT INTO public.sample_result(sample_id,result_date,test_parameters_name,actual_result_value) VALUES ('{0}','{1}','{2}','{3}')",
                    sample_id, date, result.test_parameters_name.Replace("'", "''"), result.actual_result_value.Replace("'", "''"));
                    cmd = new NpgsqlCommand(query, objConnection, transaction);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                objConnection.Close();
                response = true;
            }

            return response;
        }

        public List<SampleResult> GetSampleResults()
        {
            List<SampleResult> results = new List<SampleResult>();

            using (NpgsqlConnection objConnection = Connection.GetConnection())
            {
                string query = @"SELECT s.barcode_or_level, sr.test_parameters_name, sr.actual_result_value 
                                        FROM public.sample s 
                                        INNER JOIN public.sample_result sr ON s.sample_id = sr.sample_id 
                                        WHERE s.is_hospital_sync isnull or s.is_hospital_sync = false";
                NpgsqlCommand cmd = new NpgsqlCommand(query, objConnection);
                using (IDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        SampleResult result = new SampleResult();
                        result.barcode_or_level = dataReader["barcode_or_level"].ToString();
                        result.test_parameters_name = dataReader["test_parameters_name"].ToString();
                        result.actual_result_value = dataReader["actual_result_value"].ToString();
                        result.result_entry_by = "Machine";
                        result.result_entry_date = DateTime.Now;
                        results.Add(result);
                    }
                }
                objConnection.Close();
            }

            return results;
        }

        public bool SyncSampleResults(List<SampleResult> results)
        {
            bool response = false;
            DateTime date = DateTime.Now;
            
            using (NpgsqlConnection objConnection = Connection.GetConnection())
            {
                NpgsqlTransaction transaction = objConnection.BeginTransaction();

                foreach (var result in results)
                {
                    string query = string.Format(@"UPDATE public.sample
                                                          SET is_hospital_sync=true, result_sync_by='{0}', result_sync_date='{1}'
                                                          WHERE barcode_or_level='{2}'",
                                                          "Machine", date, result.barcode_or_level.Replace("'", "''"));
                    NpgsqlCommand cmd = new NpgsqlCommand(query, objConnection, transaction);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                objConnection.Close();
                response = true;
            }

            return response;
        }
    }
}
