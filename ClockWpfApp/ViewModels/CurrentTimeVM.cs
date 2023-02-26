using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitiesWPF;
using UtilitiesWpf;
using System.Threading;

namespace ClockWpfApp.ViewModels
{
    internal class CurrentTimeVM : ObserverVM
    {
        private string _currentTime;

        public string CurrentTime   
        {
            get { return _currentTime; }
            set { _currentTime = value;
                OnPropertyChanged(nameof(CurrentTime));
            }
        }

        private string _refreshCurrentTime;

        public string RefreshCurrentTime
        {
            get { return _refreshCurrentTime; }
            set {
               
                    CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                OnPropertyChanged(nameof(RefreshCurrentTime));

            }
        }
        public CurrentTimeVM()
        {
            CurrentTime = DateTime.Now.ToString("HH:mm:ss");

            Task task = new Task(() =>
            {
                while (true)
                {
                    CurrentTime = DateTime.Now.ToString("HH:mm:ss");
                    Thread.Sleep(1000);
                    // jak ty sie chcesz wyspac ????
                }
               
            });

            task.Start();
        }

    }
}
