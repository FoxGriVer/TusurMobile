using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TUSUR.Views.ProfileViews.AdminViews.VariantsViews
{
    public partial class ChangeVariantPage : ContentPage
    {
        public ChangeVariantPage()
        {
            InitializeComponent();
        }

        private async void Apply_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new StartPage());
        }
    }
}
