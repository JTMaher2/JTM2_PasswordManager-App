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
        private JTM2_Password mPw;
        public PasswordPage(JTM2_Password pw)
        {
            InitializeComponent();

            mPw = pw;

            hiddenId.Text = pw.PasswordId.ToString();
            siteEntry.Text = pw.PasswordSite;
            passwordEntry.Text = pw.PasswordPlainText;
            urlEntry.Text = pw.PasswordUrl;
            notesEntry.Text = pw.PasswordNotes;
        }

        private async void saveBtn_Clicked(object sender, EventArgs e)
        {
            mPw.PasswordSite = siteEntry.Text;
            mPw.PasswordPlainText = passwordEntry.Text;
            mPw.PasswordUrl = urlEntry.Text;
            mPw.PasswordNotes = notesEntry.Text;

            await new RestService().SaveDataAsync(mPw);
        }
    }
}