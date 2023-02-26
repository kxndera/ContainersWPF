using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;

namespace DynamicBoardWpfApp
{
    class MainWindowViewModel : ObserverVM
    {
        //private ObservableCollection<FieldDescription> _boardList;
        public ObservableCollection<FieldDescription> BoardList { get; set; }

        public MainWindowViewModel()
        {
            BoardList = new ObservableCollection<FieldDescription>();
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                ColIndex = 0,
                RowIndex = 0,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 0,
                ColIndex = 1,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 1,
                ColIndex = 0,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 0,
                ColIndex = 2,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 1,
                ColIndex = 1,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 1,
                ColIndex = 2,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 2,
                ColIndex = 0,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 2,
                ColIndex = 1,
                Command = PropertiesNameCommand
            });
            BoardList.Add(new FieldDescription()
            {
                Name = "",
                RowIndex = 2,
                ColIndex = 2,
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
                            int currentPlayer = 1;
                           
                                o.Name = "X"; 
                                
                            

                            /*BoardList.Add(new FieldDescription()
                            {
                                Name = "Nowy",
                                RowIndex = 1,
                                ColIndex = 1,
                                Command = PropertiesNameCommand
                            });*/
                          
                        }
                        );
                return fieldNameCommand;
            }
        }
    }

    class FieldDescription : ObserverVM
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public ICommand Command { get; set; }
    }
}