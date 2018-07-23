using System;
using System.Collections.Generic;
using TUSUR.Views.ProfileViews.AdminViews.VariantsViews;


using Xamarin.Forms;

namespace TUSUR.Views.ProfileViews.AdminViews.VariantsViews
{
    public partial class VariantsManagePage : ContentPage
    {
        public VariantsManagePage()
        {
            InitializeComponent();
        }

        private async void Create_Variant_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreateVariantPage());
        }

        private async void Change_Variant_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ChangeVariantPage());
        }

        private async void Delete_Variant_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DeleteVariantPage());
        }

        private async void Show_Variants_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ShowVariantsPage());
        }

        private async void Show_Variant_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ShowVariantPage());
        }
    }
}
