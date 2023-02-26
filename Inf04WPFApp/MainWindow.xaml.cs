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

namespace Inf04WPFApp
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
        private string password;

        private void ButtonGeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            string lowercase = "qwertyuiopasdfghjklzxcvbnm";
            string uppercase = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string digits = "1234567890";
            string specialCharacters = "!@#$%^&*()-_=+";
            
            if(!int.TryParse(TextBoxPasswordLength.Text, out int passwordLength))
            {
                MessageBox.Show("nieprawidłowa wartość długości hasła");
                return;
            }
            bool containsUppercase = CheckBoxContainsUppercase.IsChecked.Value;
            bool containsDigits = CheckBoxContainsDigits.IsChecked.Value;
            bool containsSpecialCharacters = CheckBoxContainsSpecialCharacters.IsChecked.Value;

            password = "";

            Random random = new Random();

           if (containsUppercase)
            {
                password += uppercase[random.Next(uppercase.Length)];
            }
            if (containsDigits)
            {
                password +=digits[random.Next(digits.Length)];
            }
            if (containsSpecialCharacters)
            {
                password += specialCharacters[random.Next(specialCharacters.Length)];
            }

            for (int i = password.Length; i <passwordLength; i++)
            {
                password += lowercase[random.Next(lowercase.Length)];
            }
            MessageBox.Show(password);
        }
    }
}
