using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TUSUR.Views.VictorinaViews
{
    public partial class VictorinaEnd : ContentPage
    {
        public VictorinaEnd()
        {
            InitializeComponent();                    
        }

        private async void Over_Button_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StartPage());
        }
    }
}
