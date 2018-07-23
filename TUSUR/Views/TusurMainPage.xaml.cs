using System;
using System.Collections.Generic;
using TUSUR.Views.CalendarViews;
using TUSUR.Views.VictorinaViews;

using Xamarin.Forms;

namespace TUSUR.Views
{
    public partial class TusurMainPage : ContentPage
    {
        public TusurMainPage()
        {
            InitializeComponent();
            TapGestureRecognizer tapOnAnketa = new TapGestureRecognizer();
            TapGestureRecognizer tapOnVictorina = new TapGestureRecognizer();
            TapGestureRecognizer tapOnResults = new TapGestureRecognizer();
            TapGestureRecognizer tapOnConcurse = new TapGestureRecognizer();

            tapOnAnketa.Tapped += (sender, e) =>
            {
                Navigation.PushAsync(new TestNetworkConnection());
            }; 
            AnketaFrame.GestureRecognizers.Add(tapOnAnketa);

            tapOnVictorina.Tapped += Victoria_Click;
            VictorinaFrame.GestureRecognizers.Add(tapOnVictorina);

            tapOnConcurse.Tapped += Concurse_Click;
            ConcurseFrame.GestureRecognizers.Add(tapOnConcurse);
        }

        private async void Victoria_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VictorinaPage());
        }

        private async void Concurse_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginTestPage());
        }
    }
}
