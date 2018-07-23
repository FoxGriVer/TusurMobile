using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TUSUR.ViewModels.DirectionVewModels;
using TUSUR.Models.DirectionModels;
using TUSUR.Views.DirectionViews;

using Xamarin.Forms;

namespace TUSUR.Views.DirectionViews
{
    public partial class DirectionsListView : ContentPage
    {

        public DirectionsListView()
        {
            InitializeComponent();
            BindingContext = new DirectionListViewModel() { Navigation = this.Navigation };
        }

        public async void OnDirectionItemTapped(object sender, ItemTappedEventArgs e)
        {
            Direction selectedDirection = e.Item as Direction;
            if (selectedDirection != null)
                await Navigation.PushAsync(new DirectionView(selectedDirection));
            ((ListView)sender).SelectedItem = null;
        }
    }
}
