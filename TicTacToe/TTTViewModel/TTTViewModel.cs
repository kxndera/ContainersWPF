using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;
namespace TicTacToe.TTTViewModel
{
    internal class TTTViewModel : ObserverVM
    {
        private ICommand _startGameCommand;

        public ICommand StartGameCommand
        {
            get { return _startGameCommand; }
            set { _startGameCommand = value;
                OnPropertyChanged(nameof(StartGameCommand));
            }
        }
        private ICommand _buttonClick;

        public ICommand ButtonClick
        {
            get { return _buttonClick; }
            set { _buttonClick = value;
                OnPropertyChanged(nameof(ButtonClick));

            }
        }


    }
}
