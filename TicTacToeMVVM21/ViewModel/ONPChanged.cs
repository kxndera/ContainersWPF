using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMVVM21.ViewModel
{
    internal class ONPChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //metoda zgłaszająca zmiany we własnościach podanych jako argumenty
        protected void OnPropertyChanged(params string[] namesOfProperties)
        {
            //jeśli ktoś obserwuje zdarzenie PropertyChanged
            if (PropertyChanged != null)
            {
                foreach (var prop in namesOfProperties)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(prop));
                }
            }

        }
    }
}
