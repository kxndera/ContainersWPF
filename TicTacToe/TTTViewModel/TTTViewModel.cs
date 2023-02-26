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
        private ICommand StartGameCommand;

        public ICommand _startGameCommand
        {
            get { return _startGameCommand; }
            set { _startGameCommand = value;
                OnPropertyChanged(nameof(StartGameCommand));
            }
        }
        private ICommand ButtonClick;

        public ICommand _buttonClick
        {
            get { return _buttonClick; }
            set { _buttonClick = value;
                OnPropertyChanged(nameof(ButtonClick));

            }
        }


    }
}
