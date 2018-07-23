using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TUSUR.Views.ProfileViews.AdminViews.QuestionViews
{
    public partial class ShowQuestionsPage : ContentPage
    {
        public ShowQuestionsPage()
        {
            InitializeComponent();
        }

        private async void Apply_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new StartPage());
        }
    }
}
