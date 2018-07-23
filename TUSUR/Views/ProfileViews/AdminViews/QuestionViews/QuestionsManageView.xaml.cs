using System;
using System.Collections.Generic;
using TUSUR.Views.ProfileViews.AdminViews.QuestionViews;

using Xamarin.Forms;

namespace TUSUR.Views.ProfileViews.AdminViews.QuestionViews
{
    public partial class QuestionsManageView : ContentPage
    {
        public QuestionsManageView()
        {
            InitializeComponent();
        }

        private async void Create_Question_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CreateQuestionPage());
        }

        private async void Change_Question_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ChangeQuestionPage());
        }

        private async void Delete_Question_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new DeleteQuestionPage());
        }

        private async void Show_Questions_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ShowQuestionsPage());
        }

    }
}
