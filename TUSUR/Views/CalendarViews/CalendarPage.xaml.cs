using System;
using TUSUR.ViewModels.CalendarViewModels;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TUSUR.Views.CalendarViews
{
    public partial class CalendarPage : ContentPage
    {
        TapGestureRecognizer tapOnCancel = new TapGestureRecognizer();
        TapGestureRecognizer tapOnCalculate = new TapGestureRecognizer();

        SubjectListViewModel SubjectListVM;

        public CalendarPage()
        {
            InitializeComponent();

            SubjectListVM = new SubjectListViewModel() { Navigation = this.Navigation };
            BindingContext = SubjectListVM;

            tapOnCancel.Tapped += Cancel_Button_Clicked;
            ButtonCancel.GestureRecognizers.Add(tapOnCancel);

            tapOnCalculate.Tapped += Calculate_Button_Clicked;
            ButtonCalculate.GestureRecognizers.Add(tapOnCalculate);
        }

        private void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            SubjectListVM.ResetTheAmmount();
        }

        public void Entred_The_Ammount(object sender, EventArgs e)
        {           
            if(!SubjectListVM.CountSumAmmount())
            {
                DisplayAlert("Уведомление", "Нельзя ввести число больше ста", "ОK");
            }
        }

        public async void Calculate_Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Уведомление", "Расчет закончен, переход на главную страницу", "ОK");
            await Navigation.PushModalAsync(new StartPage());
        }
    }
}
