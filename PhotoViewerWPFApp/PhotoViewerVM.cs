using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;

namespace PhotoViewerWPFApp
{
    internal class PhotoViewerVM : ObserverVM
    {
        private string imagePath;

        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        private ICommand loadFromFileCommand;
        private readonly ViewDialogs viewDialogs;

        public ICommand LoadFromFileCommand
        {
            get {
                if (loadFromFileCommand == null)
                    loadFromFileCommand = new RelayCommand<object>(
                        x =>
                        {
                            string path = viewDialogs.GetPathToPicture();
                            if (path != null)
                            {
                                ImagePath = path;
                            }
                        });
                    return loadFromFileCommand; }
        }

        public PhotoViewerVM(ViewDialogs viewDialogs)
        {
            this.viewDialogs = viewDialogs;
        }

    }
}
