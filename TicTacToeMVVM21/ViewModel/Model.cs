using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeMVVM21.Model;

namespace TicTacToeMVVM21.ViewModel
{
    enum StateOfGame
    {
        OnGoing, O_won, X_won, Draw
    };

    internal class Model 
    {
      
        private Dictionary<StateOfGame, int> score = new Dictionary<StateOfGame, int>()
        {
            {StateOfGame.Draw, 0},
            {StateOfGame.O_won, 0},
            {StateOfGame.X_won, 0}
        };

        public Dictionary<StateOfGame, int> Score
        {
            get => score; 
        }

        private int[] gameboard = new int[9];

        public int[] Gameboard
        {
            get => gameboard;
        }

        public ObservableCollection<Field> Board
        {
            get; 
            set;
        }

        private int _current_Player = 1;

        public string _currentPlayer
        {
            get
            {
                if (_current_Player == 1)
                {
                    return "O";
                }
                else return "X";
            }
        }

        private int starting_player = 1;

        private StateOfGame CurrentState
        {
            get
            {
                //rzedy
                for (int i = 0; i < 3; i += 1)
                {
                    if(gameboard[i] * gameboard[i + 3] * gameboard[i+6] == 1) return StateOfGame.O_won;
                    if(gameboard[i] * gameboard[i + 3] * gameboard[i+6] == 8) return StateOfGame.X_won;
                }

                //kolumny
                for (int i = 0; i <= 6; i += 3)
                {
                    if (gameboard[i] * gameboard[i + 1] * gameboard[i + 2] == 1) return StateOfGame.O_won;
                    if (gameboard[i] * gameboard[i + 1] * gameboard[i + 2] == 8) return StateOfGame.X_won;
                }

                if (gameboard[0] * gameboard[4] * gameboard[8] == 1) return StateOfGame.O_won;
                if (gameboard[0] * gameboard[4] * gameboard[8] == 8) return StateOfGame.X_won;
                if (gameboard[2] * gameboard[4] * gameboard[6] == 1) return StateOfGame.O_won;
                if (gameboard[2] * gameboard[4] * gameboard[6] == 8) return StateOfGame.X_won;

                foreach (int i in gameboard)
                {
                    if (i == 0) return StateOfGame.OnGoing;
                }
                return StateOfGame.Draw;
            }
        }

        public void Move(int cell)
        {
            if(gameboard[cell] != 0 || CurrentState != StateOfGame.OnGoing)
                    return;
            if (CurrentState != StateOfGame.OnGoing) score[CurrentState] += 1;

            Board.FirstOrDefault(f => f.Position == cell).Character = _currentPlayer;

            SwitchCurrentPlayer();
        }

        public void NewGameStart()
        {
            SwitchStartPlayer();
            _current_Player = starting_player;
            ClearGameboard();
        }

        private void ClearGameboard()
        {
            for (int i = 0; i < gameboard.Length; i++)
            {
                gameboard[i] = 0;
            }
        }
        private void SwitchCurrentPlayer()
        {
            if (_current_Player == 1) _current_Player = 2;
            else if (_current_Player == 2) _current_Player = 1;
        }

        private void SwitchStartPlayer()
        {
            if (starting_player == 1) starting_player = 2;
            else if (starting_player == 2) starting_player = 1;
        }


        public Model()
        {
            Board = new ObservableCollection<Field>();
            for (int i = 0; i < 9; i++)
            {
                Board.Add(new Field() 
                {
                    Character = "",
                    Position = i,
                });
            }
        }

    }

 
}
