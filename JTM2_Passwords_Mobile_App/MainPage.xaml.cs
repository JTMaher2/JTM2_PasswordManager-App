using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace JTM2_Passwords_Mobile_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        HttpClient _client;

        public MainPage()
        {
            InitializeComponent();
            _client = new HttpClient();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SettingsPage());
        }

        private async void Button_Login_Clicked(object sender, EventArgs e)
        {
            string strResp = await (await _client.PostAsync(Preferences.Get("JTM2_PasswordManager_BaseURL", "") + Constants.JTM2_LoginUrl, new StringContent("{\"u\":\"" + entDNNUsername.Text + "\", \"p\":\"" + entDNNPassword.Text + "\"}", Encoding.ASCII, "application/json"))).Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(strResp))
            {
                JObject cJWT = JObject.Parse(strResp);

                Preferences.Set("JTM2_PasswordManager_AccessToken", cJWT["accessToken"].ToString());
                await Navigation.PushModalAsync(new PasswordsPage());
            }
            else
            {
                lblInvalidLogin.IsVisible = true;
            }
        }
    }
}
