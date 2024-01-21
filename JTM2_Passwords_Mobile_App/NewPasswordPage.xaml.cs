using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTM2_Passwords_Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPasswordPage : ContentPage
    {
        public NewPasswordPage()
        {
            InitializeComponent();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            await new RestService().CreateDataAsync(entWebsite.Text, entPassword.Text, entUrl.Text, entNotes.Text);
            while (Navigation.ModalStack.Count > 0 && Navigation.ModalStack[Navigation.ModalStack.Count - 1].GetType() == typeof(NewPasswordPage)) {
                await Navigation.PopModalAsync();
            }
        }
    }
}