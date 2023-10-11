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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string generatedPassword;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            byte passwordLength;
            if(!byte.TryParse(TextBoxPasswordLength.Text, out passwordLength)){
                    MessageBox.Show("Długość hasła jest niepoprawna");
                return;
                }
            bool? hasCapitalLetters = checkBoxCapitalLetters.IsChecked;
            bool? hasDigits = checkBoxDigits.IsChecked;
            bool? hasSpecialChars = checkBoxSpecialChars.IsChecked;

            byte minPasswordLength = 1;
            if (hasCapitalLetters == true)
            {
                minPasswordLength++;
            }

            if(passwordLength < minPasswordLength){
                MessageBox.Show("Długość hasła jest za krótka");
                return;
            }

            string smallLettersSet = "qwertyuiopasdfghjklzxcvbnm";
            string capitalLettersSet = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string digitsSet = "0123456789";
            string specialCharsSet = "!@#$%^&*()_+-=";
        
            generatedPassword = string.Empty;

            Random random = new Random();
            if(hasCapitalLetters == true)
            {
                char randomChar = capitalLettersSet[random.Next(0, capitalLettersSet.Length)];
                generatedPassword+=randomChar;
            }
            if(hasDigits == true)
            {
                char randomChar = digitsSet[random.Next(0, digitsSet.Length)];
                generatedPassword += randomChar;
            }
           if(hasSpecialChars == true)
            {
                char randomChar = specialCharsSet[random.Next(0, specialCharsSet.Length)];
                generatedPassword+= randomChar; 
            }
           
        int missingNumberOfSmallLetters = passwordLength - generatedPassword.Length;
            for(int i = 0; i <missingNumberOfSmallLetters; i++)
            {
                char randomChar = smallLettersSet[random.Next(0, smallLettersSet.Length)];
                generatedPassword += randomChar;
            }

            /*generatedPassword += smallLettersSet.OrderBy(c => random.Next()).
                Take(missingNumberOfSmallLetters).ToString();
            */

            MessageBox.Show(generatedPassword.ToString());
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = "Dane pracowanika: ";

            message+= textBoxName.Text + "";
            message+= textBoxSurname.Text + "";
            message += comboBoxJob.SelectionBoxItem.ToString() + "";
            message += "Hasło: " + generatedPassword;
            MessageBox.Show(message.ToString());
        }
    }
}
