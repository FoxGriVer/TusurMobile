using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TUSUR.Views.ProfileViews.AdminViews.QuestionViews
{
    public partial class DeleteQuestionPage : ContentPage
    {
        public DeleteQuestionPage()
        {
            InitializeComponent();
        }

        private async void Apply_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new StartPage());
        }
    }
}
