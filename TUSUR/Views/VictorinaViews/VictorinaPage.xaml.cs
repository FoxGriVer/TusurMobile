using System;
using System.Collections.Generic;
using TUSUR.Views.VictorinaViews;
using TUSUR.ViewModels.VictorinaViewModels;
using TUSUR.ViewModels;
using Xamarin.Forms;

namespace TUSUR.Views.VictorinaViews
{
    public partial class VictorinaPage : ContentPage
    {       
        public VictorinaPage()
        {
            InitializeComponent();

            BindingContext = new VictorinaViewModel() { Navigation = this.Navigation };
        }

        public async void OnVictorinaItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Victorina selectedVictorina = e.Item as Models.Victorina;
            if (selectedVictorina != null)
                await Navigation.PushAsync(new VictorinaSpecificPage(selectedVictorina));
            ((ListView)sender).SelectedItem = null;
        }
    }
}
