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

namespace Zadanie_1
{


    //imie sprawdz czy puste
    //wiek czy jest pusty, czy jest cyfra i zakres

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {

            InitializeComponent();


        }

        public string nameValue;
        public string ageValue;


        #region Errors

        public string NameError = "Brak podanego imienia";
        public string AgeError = "Brak podanego wieku";
        public string AgeIsNotADigit = "Podany wiek nie jest cyfrą";
        public string AgeOutOfRange = "Wiek jest z poza zakresu";

        public string LegalAge = "jesteś pełnoletni";
        public string NotLegalAge = "jesteś niepełnoletni";
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            nameValue = TextBoxYourName.Text.Trim();

            ageValue = TextBoxYourAge.Text.Trim();

            Validate();


        }

        private void ButtonCheckBind_Click(object sender, RoutedEventArgs e)
        {

        }

        #region Validation

        #region Name
        public bool IsNameValueNull()
        {
            if (nameValue.Length == 0)
            {
                return true;
            }
            else return false;
        }

        public void ResultingName()
        {
            if (IsNameValueNull())
            {
                BlockErrorsName.Text = NameError;
                BlockOutcomeName.Text = "";
            }
            else if (!IsNameValueNull())
            {
                BlockOutcomeName.Text = "Witaj " + nameValue;
                BlockErrorsName.Text = "";
            }
        }

        public bool CheckName()
        {

            IsNameValueNull();
            ResultingName();
            return true;

        }


        #endregion


        #region Age



        public bool IsNotEmpty()
        {
            if (ageValue.Length == 0)
            {
                return false;
            }
            else return true;
        }
        public bool IsAgeANumber(string ageValue)
        {
            if (int.TryParse(ageValue, out int intAgeValue))
            {
                return true;
            }

            else return false;

        }

        public bool IsAgeWithinRange()
        {
            int intAgeValue = int.Parse(ageValue);

            {
                if (intAgeValue > 0 && intAgeValue < 150)
                {
                    return true;
                }
                
            }
            return false;
        }
        public bool IsLegalAge()
        {
            int intAgeValue = int.Parse(ageValue);

            if (intAgeValue > 17)
            {
                return true;
            }
            else
                return false;

        }



        public void ResultingAge()
        {
            if (IsLegalAge())
            {
                BlockOutcomeAge.Text = "Masz " + ageValue + " lat";
                BlockOutcomeAgeIsLegal.Text = LegalAge;
            }
            else
            {
                BlockOutcomeAge.Text = "Masz " + ageValue + " lat";
                BlockOutcomeAgeIsLegal.Text = NotLegalAge;
            }
            if (!IsAgeANumber(ageValue))
            {
                BlockErrorsAge.Text = AgeIsNotADigit;
            }

        }

        public bool CheckAge()
        {

            if (IsNotEmpty())
            {
                if (IsAgeANumber(ageValue))
                { 
                    IsAgeWithinRange();
                        ResultingAge();
                        BlockErrorsAge.Text = "";
                        return true;

                }
                else BlockErrorsAge.Text = AgeIsNotADigit;
                return false;
            }

            else BlockErrorsAge.Text = AgeError;
            return false;

            

        }

        #endregion

        public bool Validate()
        {
            if (CheckName() && CheckAge() == true)
            {

                return true;
            }
            else if (!IsNameValueNull() && !IsNotEmpty())
            {
                BlockOutcomeName.Text = "";
                BlockOutcomeAge.Text = "";
            } return false;
                
            
           
           
        }
        #endregion

        #region Previous version of checking

        //public void CheckAge()
        //{
        ////    string wiek = TextBoxYourAge.Text;



        ////    if (int.TryParse(wiek, out int userAge))
        ////    {

        ////        BlockErrorsAge.Text = "";
        ////        if(userAge > 18)
        ////        {
        ////            BlockOutcomeAge.Text =  wiek +  " pełnoletni";
        ////        }
        ////        if (userAge < 18 && userAge > 0)
        ////        {
        ////            BlockOutcomeAge.Text = wiek + " niepełnoletni";
        ////        }
        ////        if (userAge > 130)
        ////        {
        ////         BlockErrorsAge.Text =  "Podano zbyt dużą wartość";
        ////            BlockOutcomeAge.Text = "";
        ////        }
        ////    }
        ////    else
        ////    {
        ////        BlockErrorsAge.Text = "Podana błędny wiek";
        ////    }
        //}
        //public void CheckName()
        //{
        //    string name = TextBoxYourName.Text;



        //    int nameLength = TextBoxYourName.Text.Length;

        //    if (nameLength == 0)
        //    {
        //        BlockErrorsName.Text = "Brak podanego imienia";
        //    }
        //    else
        //    {
        //        BlockOutcomeName.Text = "Witaj " + name;
        //        BlockErrorsName.Text = "";
        //    }


        //}

        #endregion

    }
}
