using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2023styczen
{
    internal class Notatka
    {
        private static int liczbaNotatek;

        private int id;

        protected string tytul;

        protected string tresc;

        public Notatka(string tytul, string tresc)
        {
            liczbaNotatek++;
            id = liczbaNotatek;
            this.tytul = tytul; 
            
        }
        public void WyswietlNotatke()
        {
            Console.WriteLine("Tytuł: " + tytul);
            Console.WriteLine("Treść: " + tresc);

        }


        public void Diagnostyczna()
        {
            Console.WriteLine($"{liczbaNotatek};{id};{tytul};{tresc}");
        }
    }
}
