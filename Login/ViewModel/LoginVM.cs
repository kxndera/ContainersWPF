using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UtilitiesWpf;
using UtilitiesWPF;
using Login.Model;
using Login.Validations;
using Login.Database.Model;
using Login.Repo;
using Login.Model.Entities;

namespace Login.ViewModel
{
    class LoginVM : ObserverVM
    {
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set {  
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }


        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand<object>(
                        (o) =>
                        {
                            string message;
                             if (LoginValid.ValidationOfLogin(login, out message)
                            && (PasswordValid.ValidationOfPassword(password, out message)))
                            {
                                if (Query.LoggingValid(login, password))
                                {
                                    Message = "udało się zalogować";
                                }
                                else Message = "nie udało się zalogować";
                               
                            }
                            else Message = message;
                        }
                        );
                }
                return _loginCommand;
            }
        }

        private ICommand _registrationCommand;
        public ICommand RegistrationCommand
        {
            get
            {
                if (_registrationCommand == null)
                {
                    _registrationCommand = new RelayCommand<object>(
                        (o) =>
                        {
                            string message;
                            if (LoginValid.ValidationOfLogin(login, out message)
                           && (PasswordValid.ValidationOfPassword(password, out message)) &&
                           !AlreadyInUse.AlreadyInDatabase(login, out message))
                            {
                                Message = "Udało się zarejestować";
                                AddingUser.AddingToDatabase(login, password);
                            }
                            else
                            {
                                Message = message;
                            }
                        }
                        )
                    {

                    };
                }
                return _registrationCommand;
            }
        }
    }
}
