using System;
using System.Collections.Generic;
using TUSUR.ViewModels.DirectionVewModels;
using TUSUR.Models.DirectionModels;

using Xamarin.Forms;

namespace TUSUR.Views.DirectionViews
{
    public partial class DirectionView : ContentPage
    {
        TapGestureRecognizer tapOnGalochkaStack = new TapGestureRecognizer();

        DirectionViewModel DirectionVM;

        public DirectionView(Direction _direction)
        {
            InitializeComponent();

            DirectionVM = new DirectionViewModel(_direction) { Navigation = this.Navigation };
            BindingContext = DirectionVM;

            tapOnGalochkaStack.Tapped += Direction_Button_Click;
            GalochkaStack.GestureRecognizers.Add(tapOnGalochkaStack);
        }

        public DirectionView()
        {
            
        }

        private void Direction_Button_Click(object sender, EventArgs e)
        {
            DirectionVM.ChangeDecriptionBlockState();
        }
    }
}
