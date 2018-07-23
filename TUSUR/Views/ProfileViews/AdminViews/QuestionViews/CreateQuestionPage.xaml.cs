using System;
using System.Collections.Generic;
using TUSUR.Views.ProfileViews.AdminViews.QuestionViews;

using Xamarin.Forms;

namespace TUSUR.Views.ProfileViews.AdminViews.QuestionViews
{
    public partial class CreateQuestionPage : ContentPage
    {
        public CreateQuestionPage()
        {
            InitializeComponent();
        }

        private async void Apply_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new StartPage());
        }
    }
}
