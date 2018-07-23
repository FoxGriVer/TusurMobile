using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TUSUR.Views.VictorinaViews
{
    public partial class VictorinaSpecificPage : ContentPage
    {
        public Models.Victorina OurVictorina;
        private bool? ChoosedVariant;

        public VictorinaSpecificPage(Models.Victorina _victorina)
        {
            InitializeComponent();

            OurVictorina = _victorina;
            this.BindingContext = OurVictorina;
        }

        public VictorinaSpecificPage()
        {
            InitializeComponent();
        }

        public void OnVariantItemTapped(object sender, ItemTappedEventArgs e)
        {
            Models.Variant selectedVariant = e.Item as Models.Variant;
            if (selectedVariant != null)
            {
                ChoosedVariant = selectedVariant.RightVariant;
            }
                //await Navigation.PushAsync(new VictorinaSpecificPage(selectedVictorina));
            //((ListView)sender).SelectedItem = null;
            //await DisplayAlert("Выбранная викторина", $"{selectedPhone.listOfVariants[1]}", "OK");
        }

        private async void CheckVariant(bool? _variantTrue)
        {
            if(_variantTrue == true)
            {
                await Navigation.PushModalAsync(new VictorinaEnd());
            }
            else 
            {
                await DisplayAlert("Уведомление", "Вы выбрали неверный вариант", "ОK");
            }
        }

        private async void Answer_Button_Click(object sender, EventArgs e)
        {
            if( ChoosedVariant.HasValue)
            {
                CheckVariant(ChoosedVariant);
            }
            else
            {
                await DisplayAlert("Варинат ответа не выбран", "Выберите вариант ответа", "ОK");
            }

        }

    }
}
