using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TicTacToe.ViewModel;
using TicTacToeMVVM21.Model;

namespace TicTacToeMVVM21.ViewModel
{
    internal class ViewModelTTC : ONPChanged
    {
        private Model model = new Model();

        public string CurrentPlayer
        {
            get => model._currentPlayer;
        }

        public string Score
        {
            get => "X: " + model.Score[StateOfGame.X_won].ToString() + "\n"
                + "O: " + model.Score[StateOfGame.O_won].ToString() + "\n" +
                "Remisy: " + model.Score[StateOfGame.Draw].ToString(); 
        }

        public ObservableCollection<Field> Gameboard
        {
            get
            {
               
                return model.Board;
            }
        }

        private ICommand newGame;
        public ICommand NewGame
        {
            get
            {
                return newGame ??= new RelayCommand(
                    p =>
                    {
                        model.NewGameStart();
                        OnPropertyChanged(nameof(NewGame));
                    },
                    p => true
                );
            }
        }

        private ICommand move;
        public ICommand Move
        {
            get
            {
                return move ??= new RelayCommand(
                        p =>
                        {
                            model.Move(int.Parse(p.ToString()));
                            OnPropertyChanged("Gameboard");
                            OnPropertyChanged("Score", "CurrentPlayer");
                        },
                        p => true
                    );
            }
        }

    }
}
