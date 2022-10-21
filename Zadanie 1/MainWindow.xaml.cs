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

        #region without Binding
        public string nameValue;
        public string ageValue;
        #endregion

        #region Binding

        public string nameValueString;
        public string nameValueProp
        {
            get
            {
                return nameValueString;
            }
            set
            {
                nameValueString = nameValue;

            }
        }

        public string ageValueString;
        public string ageValueProp
        {
            get
            {
                return ageValueString;
            }
            set
            {
                ageValueString = ageValue;
            }
        }

        public string OutcomeString;
        public string Outcome
        {
            get
            {
                return OutcomeString;
            }
            set
            {
                OutcomeString = value;
                OnPropertyChanged(nameof(Outcome));
            }
        }

        public string legalAgeString;
        public string legalAgeProp
        {
            get
            {
                return legalAgeString;
            }

            set
            {
                legalAgeString = value;
                OnPropertyChanged(nameof(legalAgeProp));
            }
        }

        public string AgeErrorsString;

        public string AgeErrors
        {
            get
            {
                return AgeErrorsString;
            }
            set
            {
                AgeErrorsString = value;
                OnPropertyChanged(nameof(AgeErrors));
            }
        }


        public string NameErrorsString;

        public string NameErrors
        {
            get
            {
                return NameErrorsString;
            }
            set
            {
                NameErrorsString = value;
                OnPropertyChanged(nameof(NameErrors));
            }
        }
        #endregion


        #region Errors

        public string NameError = "Brak podanego imienia";
        public string AgeError = "Brak podanego wieku";
        public string AgeIsNotADigit = "Podany wiek nie jest cyfrą";
        public string AgeOutOfRange = "Wiek jest z poza zakresu";

        public string LegalAge = "jesteś pełnoletni/a";
        public string NotLegalAge = "jesteś niepełnoletni/a";
        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Buttons
        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {


            TakeValuesFromTextBoxes();
            Validate();


        }

        private void ButtonCheckBind_Click(object sender, RoutedEventArgs e)
        {

            TakeValuesFromTextBoxes();
            if (Validate())
            {
                ShowResultBind();
            }



        }
        #endregion 

        #region Take Values from both Textboxes
        public void TakeValuesFromTextBoxes()
        {
            nameValue = TextBoxYourName.Text.Trim();

            ageValue = TextBoxYourAge.Text.Trim();
        }
        #endregion

        #region Show Result from Binding
        public void ShowResultBind()
        {

            ResultingNameBinding();
            ResultingAgeBinding();
        }
        #endregion

        #region Validation

        #region Name
        public bool IsNameValueNull()
        {
            if (nameValue.Length == 0)
            {
                BlockErrorsName.Text = NameError;
                return true;

            }
            else return false;

        }


        #region Resulting Name
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

        public void ResultingNameBinding()
        {
            if (IsNameValueNull())
            {
               NameErrors = NameError;
                Outcome = "";
            }
            else if (!IsNameValueNull())
            {
                Outcome = "Witaj " + nameValue;
                NameErrors = "";
            }
        }
        #endregion


        
       

        public bool CheckName()
        {
            if (!IsNameValueNull())
            {
                return true;
            }
            else return false;

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

            return false;

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


        #region Showing Errors
        public void ShowErrors()
        {
            if (!IsNotEmpty())
            {
                BlockErrorsAge.Text = AgeError;
            }

            else if (!IsAgeANumber(ageValue))
            {
                BlockErrorsAge.Text = AgeIsNotADigit;
            }

            else if (!IsAgeWithinRange())
            {
                BlockErrorsAge.Text = AgeOutOfRange;
            }
        }


        public void ShowErrorsBinding()
        {
            if (!IsNotEmpty())
            {
                AgeErrors = AgeError;
            }

            else if (!IsAgeANumber(ageValue))
            {
                AgeErrors = AgeIsNotADigit;
            }

            else if (!IsAgeWithinRange())
            {
                AgeErrors = AgeOutOfRange;
            }
        }
        #endregion

        #region Results
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
        }




        public void ResultingAgeBinding()
        {
            if (IsLegalAge())
            {
                Outcome = "Masz " + ageValue + " lat";
                legalAgeProp = LegalAge;
            }
            else
            {
                Outcome = "Masz " + ageValue + " lat";
                legalAgeProp = NotLegalAge;
            }
        }

        #endregion

        public bool CheckAge()
        {


            if (IsNotEmpty() && IsAgeANumber(ageValue) && IsAgeWithinRange())
            {
                BlockErrorsAge.Text = "";
                return true;
            }
            else return false;

        }

        #endregion

        public bool Validate()
        {
            if (CheckName() && CheckAge())
            {
                ResultingName();
                ResultingAge();
                return true;
            }
            else
            {
                ShowErrors();
                ShowErrorsBinding();
                BlockOutcomeName.Text = "";
                BlockOutcomeAge.Text = "";
                BlockOutcomeAgeIsLegal.Text = "";
                return false;
            }
        }
        #endregion


    }
}




