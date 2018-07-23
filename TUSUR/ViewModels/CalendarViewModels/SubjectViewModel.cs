using System;
using System.ComponentModel;
using TUSUR.Models.CalculatorModels;

namespace TUSUR.ViewModels.CalendarViewModels
{
    public class SubjectViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Subject OurSubject { get; set; }
        private bool subjectIsSelected { get; set; }
        private int editedAmmount { get; set; }

        public SubjectViewModel()
        {
            OurSubject = new Subject();
            subjectIsSelected = false;
            editedAmmount = 0;
        }

        public string Name
        {
            get { return OurSubject.Name; }
            set
            {
                if (OurSubject.Name != value)
                {
                    OurSubject.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public int Ammount
        {
            get { return OurSubject.Ammount; }
            set
            {
                if (OurSubject.Ammount != value)
                {       
                    OurSubject.Ammount = value;
                    OnPropertyChanged("Ammount");                    
                }
            }
        }

        public int EditedAmmount
        {
            get { return editedAmmount; }
            set
            {
                if (editedAmmount != value)
                {
                    editedAmmount = value;
                    OnPropertyChanged("EditedAmmount");
                    OurSubject.Ammount = editedAmmount;
                }
            }
        }

        public bool IsSelected
        {
            get { return subjectIsSelected; }
            set
            {
                if (subjectIsSelected != value)
                {
                    subjectIsSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        protected void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
