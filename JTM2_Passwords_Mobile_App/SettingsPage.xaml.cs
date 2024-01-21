using System;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace JTM2_Passwords_Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            entServerAddress.Text = Preferences.Get("JTM2_PasswordManager_BaseURL", "");
            entMasterPassword.Text = Preferences.Get("JTM2_PasswordManager_MasterPassword", "");
        }

        private async void btnSaveSettings_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("JTM2_PasswordManager_BaseURL", entServerAddress.Text); // update URL for logging into DNN
            Preferences.Set("JTM2_PasswordManager_MasterPassword", entMasterPassword.Text); // update password for decrypting passwords
            
            await Navigation.PopModalAsync();
        }
    }
}