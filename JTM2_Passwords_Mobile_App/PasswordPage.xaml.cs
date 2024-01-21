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
    public partial class PasswordPage : ContentPage
    {
        private ItemViewModel mPw;
        private RestService m_cRestSvc;
        private PasswordsPage m_cParent;

        public PasswordPage(ItemViewModel pw)
        {
            InitializeComponent();
            m_cRestSvc = new RestService();
            mPw = pw;
            m_cParent = new PasswordsPage();

            hiddenId.Text = pw.Id.ToString();
            siteEntry.Text = pw.Name;
            passwordEntry.Text = pw.Description;
            //urlEntry.Text = pw.PasswordUrl;
            //notesEntry.Text = pw.PasswordNotes;
        }

        private async void saveBtn_Clicked(object sender, EventArgs e)
        {
            mPw.Name = siteEntry.Text;
            mPw.Description = passwordEntry.Text;
            //mPw.PasswordUrl = urlEntry.Text;
            //mPw.PasswordNotes = notesEntry.Text;

            await m_cRestSvc.SaveDataAsync(mPw);
            await Navigation.PushModalAsync(m_cParent);
        }

        private async void deleteBtn_Clicked(object sender, EventArgs e)
        {
            await m_cRestSvc.DeleteDataAsync(hiddenId.Text);
            await Navigation.PushModalAsync(m_cParent);
        }
    }
}