using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TicTacToeqdsqdw.Field;
using UtilitiesWpf;
using UtilitiesWPF;

namespace DynamicBoardWpfApp
{
    class MainWindowViewModel : ObserverVM
    {
        private bool currentPlayer = true;

        private HashSet<FieldDescription> clickedField = new HashSet<FieldDescription>();
        public ObservableCollection<FieldDescription> BoardList { get; set; }


        private int xWins;
        public int XWins
        {
            get { return xWins; }
            set
            {
                xWins = value;
                OnPropertyChanged(nameof(XWins));
            }
        }



        private int oWins;
        public int OWins
        {
            get { return oWins; }
            set
            {
                oWins = value;
                OnPropertyChanged(nameof(OWins));
            }
        }


        public MainWindowViewModel()
        {
            BoardList = new ObservableCollection<FieldDescription>();
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                ColIndex = 0,
                RowIndex = 0,
                NumberOfCell = 0,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 0,
                ColIndex = 1,
                NumberOfCell = 1,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 0,
                ColIndex = 2,
                NumberOfCell = 2,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 1,
                ColIndex = 0,
                NumberOfCell = 3,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 1,
                ColIndex = 1,
                NumberOfCell = 4,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 1,
                ColIndex = 2,
                NumberOfCell = 5,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 2,
                ColIndex = 0,
                NumberOfCell = 6,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 2,
                ColIndex = 1,
                NumberOfCell = 7,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 2,
                ColIndex = 2,
                NumberOfCell = 8,
                Command = PropertiesNameCommand
            });
        }


        private ICommand fieldNameCommand;
        public ICommand PropertiesNameCommand
        {
            get
            {
                if (fieldNameCommand == null)
                    fieldNameCommand = new RelayCommand<FieldDescription>(
                        o =>
                        {
                            if (!clickedField.Contains(o))
                            {
                                o.Name = currentPlayer ? "X" : "O";
                                clickedField.Add(o);
                                


                                if (IsGameWonByAnyone())
                                {

                                    MessageBox.Show($"Gracz {(currentPlayer ? "X" : "O")} wygrał!");
                                    if (currentPlayer)
                                        OWins++;
                                    else XWins++;
                                    ClearBoard();
                                }

                                if (IsGameDrawn())
                                {
                                    MessageBox.Show("Remis");
                                    ClearBoard();
                                }
                                currentPlayer = !currentPlayer;
                            }
                           

                        });
                return fieldNameCommand;
            }
        }



        private bool HorizontalWin()
        {
            if ((BoardList[0].Name != "" && BoardList[0].Name == BoardList[1].Name && BoardList[1].Name == BoardList[2].Name) ||
            (BoardList[3].Name != "" && BoardList[3].Name == BoardList[4].Name && BoardList[4].Name == BoardList[5].Name) ||
            (BoardList[6].Name != "" && BoardList[6].Name == BoardList[7].Name && BoardList[7].Name == BoardList[8].Name)) {

                return true;
            }
            else return false;
        }

        private bool VerticalWin()
        {
            if ((BoardList[0].Name != "" && BoardList[0].Name == BoardList[3].Name && BoardList[3].Name == BoardList[6].Name) ||
             (BoardList[1].Name != "" && BoardList[1].Name == BoardList[4].Name && BoardList[4].Name == BoardList[7].Name) ||
             (BoardList[2].Name != "" && BoardList[2].Name == BoardList[5].Name && BoardList[5].Name == BoardList[8].Name))
            {
                return true;
            }
            else return false;
        }

        private bool LeftDiagonalWin()
        {
            if ((BoardList[0].Name != "" && BoardList[0].Name == BoardList[4].Name && BoardList[4].Name == BoardList[8].Name))
            {
                return true;
            }
            else return false;
        }

        private bool RightDiagonalWin()
        {
            if ((BoardList[2].Name != "" && BoardList[2].Name == BoardList[4].Name && BoardList[4].Name == BoardList[6].Name))
            {
                return true;
            }
            else return false;
        }


        private bool IsGameWonByAnyone()
        {
            if (HorizontalWin() || VerticalWin() || LeftDiagonalWin() || RightDiagonalWin())
            {
                return true;
            }
            else return false;
        }

        private bool IsGameDrawn()
        {
            return !BoardList.Any(fd => fd.Name == ""); 
        }

        private void ClearBoard()
        {
            foreach (var field in BoardList)
            {
                field.Name = "";
            }
            currentPlayer = true;
            clickedField.Clear();
        }
    }
}
