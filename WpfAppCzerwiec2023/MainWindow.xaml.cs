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

namespace WpfAppCzerwiec2023
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
           
        private void ButtonSprawdz(object sender, RoutedEventArgs e)
        {
            if(RadioButtonPocztowka.IsChecked == true)
            {
                TextBlockName.Text = "Cena: 1 zł";
                ImagePocztowka.Visibility = Visibility.Visible;
                ImageList.Visibility = Visibility.Collapsed;
                ImagePaczka.Visibility = Visibility.Collapsed;
            }

            else if(RadioButtonList.IsChecked == true)
            {
                TextBlockName.Text = "Cena: 1,5 zł";
                ImagePocztowka.Visibility = Visibility.Collapsed;
                ImageList.Visibility = Visibility.Visible;
                ImagePaczka.Visibility = Visibility.Collapsed;
            }
            else if(RadioButtonPaczka.IsChecked == true)
            {
                TextBlockName.Text = "Cena: 10zł";
                ImagePocztowka.Visibility = Visibility.Collapsed;
                ImageList.Visibility = Visibility.Collapsed;
                ImagePaczka.Visibility = Visibility.Visible;

            }
        }

       

        private bool CheckNumbers(string number)
        {
            string acceptableNumbers = "0123456789";
            for(int i = 0; i < 5; i++)
            {
                if (!acceptableNumbers.Contains(number[i]))
                    return false;
                
            }
            return true;
        }

        private void ButtonApprove_Click(object sender, RoutedEventArgs e)
        {
            string PostalCode = TextBoxPostalCode.Text;
            if (PostalCode.Length != 5)
            {
                MessageBox.Show("Nieprawidłowa ilość znaków");

            }
            else if (CheckNumbers(PostalCode))
            {
                MessageBox.Show("Wprowadzono dane paczki");
            }
            else MessageBox.Show("Kod pocztowy ma składać się z samych cyfer");
        }
    }
}
