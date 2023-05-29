using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;

namespace LottoWPFApp
{
    internal class ViewModelLotto : ObserverVM
    {
       
        private int numbersCount = 6;
        private int min = 1;
        private int max = 49;

        public ObservableCollection<int> DrawnNumbers { get; set; } = new ObservableCollection<int>();

        private ICommand drawnNumbersCommand;
        public ICommand DrawnNumbersCommand
        {
            get
            {
                if (drawnNumbersCommand == null)
                    drawnNumbersCommand = new RelayCommand<object>(
                        o =>
                        {
                            Random random = new Random();
                            DrawnNumbers.Clear();

                            var drawNumbers = Enumerable.Range(min, max - min + 1)
                                                        .OrderBy(x => random.Next())
                                                        .Take(numbersCount);
                            foreach (var item in drawNumbers)
                            {
                                DrawnNumbers.Add(item);
                            }


                            /*List<int> tmpNumbers = new List<int>();
                            for (int i = min; i <= max; i++)
                            {
                                tmpNumbers.Add(i);
                            }

                            for (int i = 0; i < numbersCount; i++)
                            {
                                int randomNumberIndex = random.Next(0, tmpNumbers.Count);

                                DrawnNumbers.Add(tmpNumbers[randomNumberIndex]);
                                tmpNumbers.RemoveAt(randomNumberIndex);
                            }*/

                            /*while(DrawnNumbers.Count != numbersCount)
                            {
                                int ranomNumber = random.Next(min, max + 1);
                                if (!DrawnNumbers.Contains(ranomNumber))
                                {
                                    DrawnNumbers.Add(ranomNumber);
                                }
                            }*/

                            /*for (int i = 0; i < numbersCount; i++)
                            {
                                DrawnNumbers.Add(random.Next(min, max + 1));
                            }*/
                        }
                        );
                return drawnNumbersCommand;
            }
        }
    }
}
