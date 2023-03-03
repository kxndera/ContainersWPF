using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWPF;

namespace TicTacToeqdsqdw.Field
{
    internal class FieldDescription : ObserverVM
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

        public int NumberOfCell { get; set; }
        public int RowIndex { get; set; }
            public int ColIndex { get; set; }
            public ICommand Command { get; set; }
        
    }
}
