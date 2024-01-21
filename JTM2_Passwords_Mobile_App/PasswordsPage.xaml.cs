using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JTM2_Passwords_Mobile_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordsPage : ContentPage
    {
        public PasswordsPage()
        {
            InitializeComponent();
        }

        private async void RefreshData()
        {
            RestService restService = new RestService();
            List<ItemViewModel> passwords = await restService.RefreshDataAsync();

            PasswordsList.ItemsSource = passwords;

            PasswordsList.ItemTemplate = new DataTemplate(() =>
            {
                // Create views with bindings for displaying each property.
                Label nameLabel = new Label();
                nameLabel.SetBinding(Label.TextProperty, "Name");
                Label passwordLabel = new Label();
                passwordLabel.SetBinding(Label.TextProperty, "Description");
                // Return an assembled ViewCell.
                return new ViewCell
                {
                    View = new StackLayout
                    {
                        Padding = new Thickness(0, 5),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                            {
                                nameLabel,
                                passwordLabel
                            }
                    }
                };
            });

            PasswordsList.ItemTapped += PasswordsList_ItemTapped;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshData();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            RefreshData();
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewPasswordPage());
        }

        private async void Button_Logout_Clicked(object sender, EventArgs e)
        {
            Preferences.Remove("JTM2_PasswordManager_AccessToken");
            await Navigation.PushModalAsync(new MainPage());
        }

        private async void PasswordsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushModalAsync(new PasswordPage((ItemViewModel)e.Item));
        }
    }
}