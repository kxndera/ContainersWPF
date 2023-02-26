using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeMVVM21.ViewModel;

namespace TicTacToeMVVM21.Model
{
    internal class Field : ONPChanged
    {

        public int Position { get; set; }

        private string _character;

        public string Character 
        {
            get { return _character; }
            set { _character = value;
                OnPropertyChanged(nameof(Character));
                }
        }

    }
}
