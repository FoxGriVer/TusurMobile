using System;
using System.ComponentModel;
using TUSUR.Models.DirectionModels;
using Xamarin.Forms;

namespace TUSUR.ViewModels.DirectionVewModels
{
    public class DirectionViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation Navigation { get; set; }

        public Direction OurDirection { get; set; }

        private bool showDescription { get; set; }
        private bool showUpIcon { get; set; }
        private bool showDownIcon { get; set; }

        public DirectionViewModel()
        {
            OurDirection = new Direction();
            showDescription = false;
            showUpIcon = false;
            showDownIcon = true;
        }

        public DirectionViewModel(Direction _direction)
        {
            OurDirection = _direction;
            showDescription = false;
            showUpIcon = false;
            showDownIcon = true;
        }

        public string Code
        {
            get { return OurDirection.Code; }
            set
            {
                if (OurDirection.Code != value)
                {
                    OurDirection.Code = value;
                    OnPropertyChanged("Code");
                }
            }
        }

        public string Name
        {
            get { return OurDirection.Name; }
            set
            {
                if (OurDirection.Name != value)
                {
                    OurDirection.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public int PayPlaces
        {
            get { return OurDirection.PayPlaces; }
            set
            {
                if (OurDirection.PayPlaces != value)
                {
                    OurDirection.PayPlaces = value;
                    OnPropertyChanged("PayPlaces");
                }
            }
        }

        public int FreePlaces
        {
            get { return OurDirection.FreePlaces; }
            set
            {
                if (OurDirection.FreePlaces != value)
                {
                    OurDirection.FreePlaces = value;
                    OnPropertyChanged("FreePlaces");
                }
            }
        }

        public int Price
        {
            get { return OurDirection.Price; }
            set
            {
                if (OurDirection.Price != value)
                {
                    OurDirection.Price = value;
                    OnPropertyChanged("Price");
                }
            }
        }

        public int MinBall
        {
            get { return OurDirection.MinBall; }
            set
            {
                if (OurDirection.MinBall != value)
                {
                    OurDirection.MinBall = value;
                    OnPropertyChanged("MinBall");
                }
            }
        }

        public bool ShowDescription
        {
            get { return showDescription; }
            set
            {
                if (showDescription != value)
                {
                    showDescription = value;
                    OnPropertyChanged("ShowDescription");
                }
            }
        }

        public bool ShowUpIcon
        {
            get { return showUpIcon; }
            set
            {
                if (showUpIcon != value)
                {
                    showUpIcon = value;
                    OnPropertyChanged("ShowUpIcon");
                }
            }
        }

        public bool ShowDownIcon
        {
            get { return showDownIcon; }
            set
            {
                if (showDownIcon != value)
                {
                    showDownIcon = value;
                    OnPropertyChanged("ShowDownIcon");
                }
            }
        }

        public void ChangeDecriptionBlockState()
        {
            if(ShowDescription == false)
            {
                ShowDescription = true;
                ShowUpIcon = true;
                ShowDownIcon = false;
            }
            else
            {
                ShowDescription = false;
                ShowUpIcon = false;
                ShowDownIcon = true;
            }
        }

        protected void OnPropertyChanged(string propName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
