using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TUSUR.Models.CalculatorModels;
using Xamarin.Forms;

namespace TUSUR.ViewModels.CalendarViewModels
{
    public class SubjectListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SubjectViewModel> ListOfSubjects { get; set; }
        public SubjectViewModel selectedSubject;
        public int sumAmmount;

        public INavigation Navigation { get; set; }

        public SubjectListViewModel()
        {
            ListOfSubjects = new ObservableCollection<SubjectViewModel>()
            {
                new SubjectViewModel { Name = "Русский язык", Ammount = 0, IsSelected = false},
                new SubjectViewModel { Name = "Математика", Ammount = 10, IsSelected = false},
                new SubjectViewModel { Name = "Физика", Ammount = 0, IsSelected = false},
                new SubjectViewModel { Name = "Химия", Ammount = 50, IsSelected = false},
                new SubjectViewModel { Name = "Иностранный язык", Ammount = 0, IsSelected = false},
                new SubjectViewModel { Name = "Информатика", Ammount = 0, IsSelected = false},
                new SubjectViewModel { Name = "Обществознание", Ammount = 0, IsSelected = false},
                new SubjectViewModel { Name = "Индивидуальные достижения", Ammount = 0, IsSelected = false}
            };
            CountSumAmmount();
        }

        public SubjectViewModel SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                if (selectedSubject != value)
                {
                    SubjectViewModel tempSubject = value;
                    selectedSubject = null;
                    OnPropertyChanged("SelectedSubject");
                    if (tempSubject.IsSelected == true)
                    {
                        tempSubject.IsSelected = false;
                    }
                    else
                    {
                        tempSubject.IsSelected = true;
                    }
                }
            }
        }

        public int SumAmmount
        {
            get { return sumAmmount; }
            set
            {
                if (sumAmmount != value)
                {
                    sumAmmount = value;
                    OnPropertyChanged("SumAmmount");
                }
            }
        }

        protected void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public bool CountSumAmmount()
        {
            int sum = 0;
            foreach (var item in ListOfSubjects)
            {
                if(item.Ammount <= 100)
                {
                    sum += item.Ammount;
                }
                else 
                {
                    item.Ammount = 0;
                    return false;
                }
            }
            SumAmmount = sum;
            return true;
        }

        public void ResetTheAmmount()
        {            
            foreach (var item in ListOfSubjects)
            {
                item.Ammount = 0;
            }
            CountSumAmmount();
        }
    }
}
