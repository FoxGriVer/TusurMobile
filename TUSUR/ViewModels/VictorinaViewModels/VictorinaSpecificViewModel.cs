using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using TUSUR.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TUSUR.ViewModels.VictorinaViewModels
{
    public class VictorinaSpecificViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
              
        public VictorinaSpecificViewModel()
        {
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
               
    }
}
