using System;
using TUSUR.Models.DirectionModels;
using System.ComponentModel;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TUSUR.ViewModels.DirectionVewModels
{
    public class DirectionListViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public ObservableCollection<Direction> ListOfDirections { get; set; }

        public DirectionListViewModel()
        {
            ListOfDirections = new ObservableCollection<Direction>
            {
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Инфокоммуникационные технологии и системы связи", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
                new Direction { Code = "11.03.02", Name = "Радио", PayPlaces = 78, FreePlaces = 25, MinBall = 180, Price = 80000},
            };
        }

        protected void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
