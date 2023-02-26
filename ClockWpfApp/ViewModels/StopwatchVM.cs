using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;

namespace ClockWpfApp.ViewModels
{
    internal class StopwatchVM : ObserverVM
    {
        private bool IsStopWatchRunning = false;
        private string timeStorage;
        public string TimeStorage
        {
            get { return timeStorage; }
            set { timeStorage = value;
                OnPropertyChanged(nameof(TimeStorage)); 
            }
        }

        private ICommand startCommand;

        public ICommand StartCommand
        {
            get { if (startCommand == null)
                    startCommand = new RelayCommand<object>(
                        o =>
                        {
                            IsStopWatchRunning = true;
                            DateTime startTime = DateTime.Now;
                            int stopWatchMilisecond = 0;
                            Task.Run(() =>
                             {
                                 while (IsStopWatchRunning)
                                 {
                                     stopWatchMilisecond++;
                            DateTime stopWatch = DateTime.Now;
                                     TimeSpan timeSpan = stopWatch - startTime;
                                    // TimeSpan timeSpan = TimeSpan.FromMilliseconds(stopWatchMilisecond);
                                     string stringTime = string.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", 
                                         timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
                                     TimeStorage = stringTime;
                                     Thread.Sleep(1);
                                 }
                             });
                        },
                    o => !IsStopWatchRunning
                        );
                        return startCommand; }
        }

        private ICommand stopCommand;
        public ICommand StopCommand
        {
            get
            {
                if (stopCommand == null)
                    stopCommand = new RelayCommand<object>(
                        o =>
                        {
                            IsStopWatchRunning = false;
                        },
                  o => IsStopWatchRunning
                        );
                return stopCommand;
            }
        }

    }
}
