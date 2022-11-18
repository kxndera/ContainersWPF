using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;

namespace SliderRGB.ViewModel
{
    class PickedColorVM : ObserverVM
    {
        private double _redComponent;

        public double RedComponent
        {
            get { return _redComponent; }
            set { _redComponent = value;
                OnPropertyChanged(nameof(RedComponent));
                    }
            
        }

        private double _greenComponent;

        public double GreenComponent
        {
            get { return _greenComponent; }
            set { _greenComponent = value;
                OnPropertyChanged(nameof(GreenComponent));
            }
        }

        private double _blueComponent;

        public double BlueComponent
        {
            get { return _blueComponent; }
            set { _blueComponent = value;
                OnPropertyChanged(nameof(BlueComponent));
            }
        }

        private ICommand _setRedColorCommand;

        public ICommand SetRedColorCommand
        {
            get { 
                if(_setRedColorCommand == null)
                {
                    _setRedColorCommand = new RelayCommand<Object>(
                        (Object o) =>
                        {
                            RedComponent = 255;
                            GreenComponent = 0;
                            BlueComponent = 0;
                        }

                    );
                }
                return _setRedColorCommand; 
            }
          
        }

    }
}
