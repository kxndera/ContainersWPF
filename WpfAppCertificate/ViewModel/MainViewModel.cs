using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UtilitiesWPF;

namespace WpfAppCertificate.ViewModel
{
    internal class MainViewModel : ObserverVM
    {
        DateTime dateOfClassEnd = new DateTime(2023, 6, 23, 10, 0, 0);
        private DateTime currentTime;

        private string _time;
        public string Time

        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }

      
        public MainViewModel()
        {
          
            Task taskSubstract = new Task(() =>
            {
                while (true)
                {
                    currentTime = DateTime.Now;
                    Thread.Sleep(1000);
                   
                    TimeSpan interval = dateOfClassEnd - currentTime;
                    Time = "Dni: " + interval.Days + " Godzin: " + interval.Hours + " Minut: " + interval.Minutes + " Sekund: " + interval.Seconds;

                }
            });

           
            taskSubstract.Start();
        } 
    }

    }

