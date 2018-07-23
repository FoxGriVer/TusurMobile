using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TUSUR.Views;
using TUSUR.Views.VictorinaViews;
using TUSUR.Views.CalendarViews;
using TUSUR.Views.DirectionViews;
using TUSUR.Views.ProfileViews.AdminViews;
using Xamarin.Forms;

namespace TUSUR.Views
{
    public partial class StartPage : MasterDetailPage
    {
        TapGestureRecognizer tapOnVictorina = new TapGestureRecognizer();
        TapGestureRecognizer tapOnLogo = new TapGestureRecognizer();
        TapGestureRecognizer tapOnCalculator = new TapGestureRecognizer();
        TapGestureRecognizer tapOnDirections = new TapGestureRecognizer();
        TapGestureRecognizer tapOnProfile = new TapGestureRecognizer();

        public StartPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new TusurMainPage());

            tapOnVictorina.Tapped += Victorina_Button_Click;
            VictorinaStack.GestureRecognizers.Add(tapOnVictorina);

            tapOnLogo.Tapped += MainPage_Button_Click;
            tusurLogo.GestureRecognizers.Add(tapOnLogo);

            tapOnCalculator.Tapped += Calculator_Button_Click;
            CalculatorStack.GestureRecognizers.Add(tapOnCalculator);

            tapOnDirections.Tapped += Directions_Button_Click;
            DirectionsStack.GestureRecognizers.Add(tapOnDirections);

            tapOnProfile.Tapped += Profile_Button_Click;
            ProfileStack.GestureRecognizers.Add(tapOnProfile);
        }

        private void Victorina_Button_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new VictorinaPage());
            IsPresented = false;
        }

        private void MainPage_Button_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new TusurMainPage());
            IsPresented = false;
        }

        private void Calculator_Button_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CalendarPage());
            IsPresented = false;
        }

        private void Directions_Button_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new DirectionsListView());
            IsPresented = false;
        }

        private void Profile_Button_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new AdminMenuView());
            IsPresented = false;
        }
    }
}
