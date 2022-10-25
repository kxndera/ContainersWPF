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
        public string NameValueProp
        {
            get
            {
                return nameValueString;
            }
            set
            {
                nameValueString = value;
                OnPropertyChanged(nameof(NameValueProp));
            }
        }

        public string ageValueString;
        public string AgeValueProp
        {
            get
            {
                return ageValueString;
            }
            set
            {
                ageValueString = value;
                OnPropertyChanged(nameof(AgeValueProp));
            }
        }


        public string legalAgeString;
        public string LegalAgeProp
        {
            get
            {
                return legalAgeString;
            }

            set
            {
                legalAgeString = value;
                OnPropertyChanged(nameof(LegalAgeProp));
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

        //public string takeValueName;

        //public string TakeValueName
        //{
        //    get
        //    {
        //        return takeValueName;
        //    }
        //    set
        //    {
        //        takeValueName = value;
        //        OnPropertyChanged(nameof(TakeValueName));
        //    }
        //}

        //public string takeValueAge;

        //public string TakeValueAge {
        //    get {
        //        return takeValueAge;
        //    } set {
        //        takeValueAge = value;
        //        OnPropertyChanged(nameof(TakeValueAge));
        //            }
        //}

        #region Errors

        public string NameError = "Brak podanego imienia";
        public string AgeError = "Brak podanego wieku";
        public string AgeIsNotADigit = "Podany wiek nie jest cyfrą";
        public string AgeOutOfRange = "Wiek jest z poza zakresu";

        public string LegalAge = "jesteś pełnoletni/a";
        public string NotLegalAge = "jesteś niepełnoletni/a";
        #endregion



        #region INotifyPropertyChanged

      

        #endregion



        #region Buttons
        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            TakeValuesFromTextBoxes();
            DeleteAllRecords();
            if (Validate())
            {
                ShowResults();
                DeleteAllErrors();
            }
            else ShowErrors();

        }

        private void ButtonCheckBind_Click(object sender, RoutedEventArgs e)
        {
            TakeValuesFromTextBoxes();
            DeleteAllRecordsBind();
            if (Validate())
            {
                ShowResultsBind();
                DeleteAllErrorsBind();
            }
            else ShowErrorsBind();
           
        }
        #endregion 



        #region Take Values from both Textboxes
        public void TakeValuesFromTextBoxes()
        {
            nameValue = TextBoxYourName.Text.Trim();

            ageValue = TextBoxYourAge.Text.Trim();
        }

        #endregion



        #region Show Results

        public void ShowResults()
        {
            ResultingName();
            ResultingAge();
        }

        public void ShowResultsBind()
        {
            ResultingNameBind();
            ResultingAgeBind();
        }
        
     
        #endregion


        #region deleting
        public void DeleteAllRecords()
        {
            BlockOutcomeName.Text = "";
            BlockOutcomeAge.Text = "";
            BlockOutcomeAgeIsLegal.Text = "";
        }
        public void DeleteAllRecordsBind()
        {
           NameValueProp = "";
           AgeValueProp= "";
          LegalAgeProp = "";
        }
        public void DeleteAllErrors()
        {
            BlockErrorsName.Text = "";
            BlockErrorsAge.Text = "";
        }
        public void DeleteAllErrorsBind()
        {
            NameErrors = "";
            AgeErrors= "";
        }
        #endregion

        #region Validation
        public bool Validate()
        {
            if (CheckName() && CheckAge())
            {

                return true;
            }
            return false;

        }

        #region Name
        public bool IsNameValueNull(string nameValue)
        {
            if (nameValue == null) {
                
                return true; 
            }
            if (nameValue.Length == 0)
            {
                NameErrors = NameError;
                BlockErrorsName.Text = NameError;
                return true;

            }
            else {
                NameErrors = NameError;
                BlockErrorsName.Text = "";
                return false; 
            }

        }


        #region Resulting Name
        public void ResultingName()
        {
             if (!IsNameValueNull(nameValue))
            {
                BlockOutcomeName.Text = "Witaj " + nameValue;
                BlockErrorsName.Text = "";
            }
        }

        public void ResultingNameBind()
        {
            if (!IsNameValueNull(nameValue))
            {
                NameValueProp = "Witaj " + nameValue;
                NameErrors = "";
            }
        }
        #endregion





        public bool CheckName()
        {
            if (IsNameValueNull(nameValue))
            {
                return false;
            }
            else return true;

        }


        #endregion


        #region Age



        public bool IsNotEmpty()
        {
            if (ageValue == null)
            {
                return false;
            }

            if (ageValue.Length == 0)
            {
                return false;
            }
            else {

                return true;
            }
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

        public void ShowErrorsBind()
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
        public void ResultingAgeBind()
        {
            if (IsLegalAge())
            {
               AgeValueProp = "Masz " + ageValue + " lat";
              LegalAgeProp = LegalAge;
            }
            else
            {
                AgeValueProp = "Masz " + ageValue + " lat";
                LegalAgeProp = NotLegalAge;
            }
        }



        #endregion

        public bool CheckAge()
        {
            if (IsNotEmpty() && IsAgeANumber(ageValue) && IsAgeWithinRange())
            {
                return true;
            }
            else return false;

        }

        #endregion


        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}




