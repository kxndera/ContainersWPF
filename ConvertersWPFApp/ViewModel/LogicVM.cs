using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;

namespace ConvertersWPFApp.ViewModel
{
    public class LogicVM : ObserverVM
    {
        private Visibility _isVisible;

        public Visibility IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        private ICommand _myVisibleFirstCommand;

        public ICommand MyVisibleFirstCommand
        {
            get {
                if (_myVisibleFirstCommand == null)
                    _myVisibleFirstCommand = new RelayCommand<Object>(
                        (Object o) =>
                        {
                            if (IsVisible == Visibility.Visible)
                            {
                                IsVisible = Visibility.Hidden;
                            }
                            else
                            {
                                IsVisible = Visibility.Visible;
                            }
                        }

                        );
                return _myVisibleFirstCommand; }

        }
        private bool _isVisibleBool;

        public bool IsVisibleBool
        {
            get { return _isVisibleBool; }
            set
            {
                _isVisibleBool = value;
                OnPropertyChanged(nameof(IsVisibleBool));
            }
        }

        private ICommand _myVisibleSecondCommand;

        public ICommand MyVisibleSecondCommand
        {
            get
            {
                if (_myVisibleSecondCommand == null)
                    _myVisibleSecondCommand = new RelayCommand<Object>(
                        (Object o) =>
                        {
                            IsVisibleBool = !IsVisibleBool;
                        }

                        );
                return _myVisibleSecondCommand;
            }

        }


        private bool _isChecked;
        public bool IsChecked 
        {
            get
            { return _isChecked; }
            set { 
            _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }

        }
       
    }
}
    