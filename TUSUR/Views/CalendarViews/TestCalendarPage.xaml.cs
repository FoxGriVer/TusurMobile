using System;
using System.Collections.Generic;
using TUSUR.ViewModels.CalendarViewModels;

using Xamarin.Forms;

namespace TUSUR.Views.CalendarViews
{
    public partial class TestCalendarPage : ContentPage
    {
        public TestCalendarPage()
        {
            InitializeComponent();
            BindingContext = new SubjectListViewModel();
            testing.Text = "notExist";
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }

    }
}
