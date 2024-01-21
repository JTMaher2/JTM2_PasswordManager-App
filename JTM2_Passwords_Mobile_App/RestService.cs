using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace JTM2_Passwords_Mobile_App
{
    public class RestService : IRestService
    {
        HttpClient _client;
        string m_strBaseURL;

        public RestService ()
        {
            m_strBaseURL = Preferences.Get("JTM2_PasswordManager_BaseURL", "");
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Preferences.Get("JTM2_PasswordManager_AccessToken", ""));
        }

        public async Task<List<ItemViewModel>> RefreshDataAsync()
        {
            string strMasterPassword = Preferences.Get("JTM2_PasswordManager_MasterPassword", "");

            HttpResponseMessage response = await _client.GetAsync(m_strBaseURL + Constants.JTM2_PasswordsUrl + "?" + (!string.IsNullOrWhiteSpace(strMasterPassword) ? "M_StrMasterPassword=" + Uri.EscapeDataString(strMasterPassword) : "") + "&Page=1&PageSize=10&Descending=false");

            if (response.IsSuccessStatusCode)
            {
                string strResp = (await response.Content.ReadAsStringAsync()).Trim('"').Replace("\\", "");
                JObject cObj = JObject.Parse(strResp);

                return JsonConvert.DeserializeObject<List<ItemViewModel>>(cObj["Items"].ToString());
            }

            return null;
        }

        public async Task<bool> SaveDataAsync(ItemViewModel pw)
        {
            return (await _client.PostAsync(new Uri(m_strBaseURL + Constants.JTM2_SavePasswordUrl), new StringContent("{\"Id\":" + pw.Id + ",\"Name\":\"" + pw.Name + "\", \"Description\":\"" + pw.Description + "\", \"M_StrMasterPassword\":\"" + Preferences.Get("JTM2_PasswordManager_MasterPassword", "") + "\"}", Encoding.ASCII, "application/json"))).IsSuccessStatusCode;
        }

        public async Task<bool> DeleteDataAsync(string strPasswordId)
        {
            Uri cUri = new Uri(string.Format(m_strBaseURL + Constants.JTM2_DeletePasswordUrl + "?itemId={0}", strPasswordId));
            HttpResponseMessage cMsg = await _client.PostAsync(cUri, null);
            return cMsg.IsSuccessStatusCode;
        }

        public async Task<bool> CreateDataAsync(string strWebsite, string strPassword, string strUrl, string strNotes)
        {
            return (await _client.PostAsync(new Uri(m_strBaseURL + Constants.JTM2_CreatePasswordUrl), new StringContent("{\"Name\":\"" + strWebsite + "\", \"Description\":\"" + strPassword + "\", \"M_StrMasterPassword\":\"" + Preferences.Get("JTM2_PasswordManager_MasterPassword", "") + "\" }", Encoding.ASCII, "application/json"))).IsSuccessStatusCode;
        }
    }
}
