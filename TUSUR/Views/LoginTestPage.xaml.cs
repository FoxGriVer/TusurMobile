using System;
using System.Collections.Generic;
using TUSUR.Views;

using Xamarin.Forms;

namespace TUSUR.Views
{
    public partial class LoginTestPage : ContentPage
    {
        public LoginTestPage()
        {
            InitializeComponent();
        }

        private async void LoginWithFacebook_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FacebookProfilePage());
        }

    }
}
