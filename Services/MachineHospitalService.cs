using MachineIntegrationWinApp.DAL;
using MachineIntegrationWinApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineIntegrationWinApp.Services
{
    public class MachineHospitalService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly string _bearerToken;

        public MachineHospitalService()
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = System.Configuration.ConfigurationManager.AppSettings["HospitalIntegrationBaseUrl"]; ;
            _bearerToken = System.Configuration.ConfigurationManager.AppSettings["HospitalIntegrationKey"]; ;
        }

        public async Task<bool> PostSampleResults()
        {
            DataArchive dataArchive = new DataArchive();
            var results = dataArchive.GetSampleResults();
            if(results.Count > 0)
            {
                var jsonContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(results), Encoding.UTF8, "application/json");

                // Set the authorization header with the bearer token
                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _bearerToken);

                HttpResponseMessage response = new HttpResponseMessage();
                response = await _httpClient.PostAsync($"{_apiBaseUrl}/api/MachineIntegration/ResultPass", jsonContent);
                string message = response.Content.ReadAsStringAsync().Result.ToString();

                if (response.IsSuccessStatusCode)
                {
                    dataArchive.SyncSampleResults(results);
                    return true;
                }
                else
                {
                    Log.Write(message.ToString());
                    return false;
                }
            }
            return false;
        }
    }
}
