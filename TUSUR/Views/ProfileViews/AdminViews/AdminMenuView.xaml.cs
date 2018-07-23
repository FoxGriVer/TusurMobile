using System;
using System.Collections.Generic;
using TUSUR.Views.ProfileViews.AdminViews.QuestionViews;
using TUSUR.Views.ProfileViews.AdminViews.VariantsViews;

using Xamarin.Forms;

namespace TUSUR.Views.ProfileViews.AdminViews
{
    public partial class AdminMenuView : ContentPage
    {
        public AdminMenuView()
        {
            InitializeComponent();
        }

        private async void Questions_Manage_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new QuestionsManageView());
        }

        private async void Variants_Manage_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new VariantsManagePage());
        }

    }
}
