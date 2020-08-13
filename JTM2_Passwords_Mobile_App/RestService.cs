using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace JTM2_Passwords_Mobile_App
{
    public class RestService : IRestService
    {
        HttpClient _client;

        public RestService ()
        {
            _client = new HttpClient();
        }

        public async Task<List<JTM2_Password>> RefreshDataAsync()
        {
            List<JTM2_Password> Passwords = null;
            var uri = new Uri(string.Format(Constants.JTM2_PasswordsUrl, string.Empty));

            StringContent stringContent = new StringContent("{\"MasterPassword\":\"UqJ3W8WqT4#q%hQj#\", \"ModuleId\":440}", System.Text.Encoding.ASCII, "application/json");

            var response = await _client.PostAsync(uri, stringContent);
            if (response.IsSuccessStatusCode)
            {
                Passwords = JsonConvert.DeserializeObject<List<JTM2_Password>>((await response.Content.ReadAsStringAsync()).Trim('"').Replace("\\", ""));
            }

            return Passwords;
        }

        public async Task<bool> SaveDataAsync(JTM2_Password pw)
        {
            var uri = new Uri(string.Format(Constants.JTM2_SavePasswordUrl, string.Empty));

            StringContent stringContent = new StringContent("{\"PasswordId\":" + pw.PasswordId + ",\"PasswordSite\":\"" + pw.PasswordSite + "\", \"PasswordPlainText\":\"" + pw.PasswordPlainText + "\",\"PasswordUrl\":\"" + pw.PasswordUrl + "\", \"PasswordNotes\":\"" + pw.PasswordNotes + "\", \"AssignedUserId\":-1, \"ModuleId\":" + pw.ModuleId + ",\"CreatedByUserId\":" + pw.CreatedByUserId + ",\"LastModifiedByUserId\":" + pw.LastModifiedByUserId + ",\"CreatedOnDate\":\"" + pw.CreatedOnDate + "\",\"LastModifiedOnDate\":\"" + pw.LastModifiedOnDate + "\"}", System.Text.Encoding.ASCII, "application/json");

            var response = await _client.PostAsync(uri, stringContent);
            return response.IsSuccessStatusCode;
        }
    }
}
