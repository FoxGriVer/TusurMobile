using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TUSUR.Models.CalculatorModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TUSUR.ViewModels.CalendarViewModels
{
    public class CalendarViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public ObservableCollection<Subject> ListOfSubjects { get; set; }

        public CalendarViewModel()
        {
            ListOfSubjects = new ObservableCollection<Subject>
            {
                new Subject { Name = "Русский язык", Ammount = 0},
                new Subject { Name = "Математика", Ammount = 0},
                new Subject { Name = "Физика", Ammount = 0},
                new Subject { Name = "Химия", Ammount = 0},
                new Subject { Name = "Иностранный язык", Ammount = 0},
                new Subject { Name = "Информатика", Ammount = 0},
                new Subject { Name = "Обществознание", Ammount = 0},
                new Subject { Name = "Индивидуальные достижения", Ammount = 0}
            };
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
