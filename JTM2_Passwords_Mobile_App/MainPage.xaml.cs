using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JTM2_Passwords_Mobile_App
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            RestService restService = new RestService();
            List<JTM2_Password> passwords = await restService.RefreshDataAsync();

            PasswordsList.ItemsSource = passwords;

            PasswordsList.ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    Label nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "PasswordSite");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                nameLabel
                            }
                        }
                    };
                });

            PasswordsList.ItemTapped += PasswordsList_ItemTapped;
        }

        private void PasswordsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushModalAsync(new PasswordPage((JTM2_Password)e.Item));
        }
    }
}
