using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using ComboBoxProject;

namespace ComboBoxProjedct
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public List<string> ListOfItems { get; set; }

        public List<OwnColor> ListOfOwnColors { get; set; }
        public MainWindow()
        {
            ListOfOwnColors = new List<OwnColor>();
            ListOfOwnColors.Add(new OwnColor()
            {
                NameOfColor_Pol = "Zielony",
                NameOfColor_Eng = "Green"
            });

            ListOfOwnColors.Add(new OwnColor()
            {
                NameOfColor_Pol = "Czerwony",
                NameOfColor_Eng = "Red"
            });

            ListOfOwnColors.Add(new OwnColor()
            {
                NameOfColor_Pol = "Niebieski",
                NameOfColor_Eng = "Blue"
            }); 
            InitializeComponent();
            ListOfItems = new List<string>();
            ListOfItems.Add("Pozycja bindowania 0");
            ListOfItems.Add("Pozycja bindowania 1");
            ListOfItems.Add("Pozycja bindowania 2");
            ListOfItems.Add("Pozycja bindowania 3");


            ListOfOwnColors = new List<OwnColor>();
            ListOfOwnColors.Add(new OwnColor()
            {
                NameOfColor_Pol = "Zielony",
                NameOfColor_Eng = "Green"
            });

            ListOfOwnColors.Add(new OwnColor()
            {
                NameOfColor_Pol = "Czerwony",
                NameOfColor_Eng = "Red"
            });

            ListOfOwnColors.Add(new OwnColor()
            {
                NameOfColor_Pol = "Niebieski",
                NameOfColor_Eng = "Blue"
            });



            OnPropertyChanged(nameof(ListOfItems));
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ListOfItems.Add("Pozycja bindowania 11");
            ListOfItems.Add("Pozycja bindowania 12");
            //OnPropertyChanged(nameof(ListOfItems));
        }

        
    }
}
