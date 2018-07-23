using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TUSUR.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TUSUR.ViewModels.VictorinaViewModels
{
    public class VictorinaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Models.Victorina> PresentVictorins { get; set; }
        public ObservableCollection<Models.Victorina> PastVictorins { get; set; }

        public ICommand SelectItemOfVictorins { protected get; set; }
        public INavigation Navigation { get; set; }

        Models.Victorina selectedVictorin;

        public VictorinaViewModel()
        {
            //SelectItemOfVictorins = new Command(SelectVictorin);

            PresentVictorins = new ObservableCollection<Models.Victorina>
            {
                new Models.Victorina { Id = 1, Name = "Вопрос #1",
                    Question = "Самолет летит со скоростью 1000 м/с, медведь бежит со скоростью распростронения звука в кипящем масле, сколько надо разогревать воду ?",
                    listOfVariants = new List<Models.Variant>
                    {
                        new Models.Variant{ Text = "7 минут" , RightVariant = true},
                        new Models.Variant{ Text = "20 WAT" , RightVariant = false},
                        new Models.Variant{ Text = "3.14" , RightVariant = false},
                        new Models.Variant{ Text = "1703" , RightVariant = false}
                    } },
                new Models.Victorina { Id = 2, Name = "Вопрос #2" },
                new Models.Victorina { Id = 3, Name = "Вопрос #3" },
            };
            PastVictorins = new ObservableCollection<Models.Victorina>
            {
                new Models.Victorina { Id = 4, Name = "Вопрос #4" },
                new Models.Victorina { Id = 5, Name = "Вопрос #5" },
                new Models.Victorina { Id = 6, Name = "Вопрос #6" },
                new Models.Victorina { Id = 7, Name = "Вопрос #7" },
                new Models.Victorina { Id = 8, Name = "Вопрос #8" },
                new Models.Victorina { Id = 9, Name = "Вопрос #9" },
            };
        }

        public Models.Victorina SelectedVictorina
        {
            get { return selectedVictorin; }
            set
            {
                selectedVictorin = value;
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
