using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Validations
{
    internal class LoginValid
    {
        public static bool ValidationOfLogin(string login, out string message)
        {

            if (ValueFull.IsValueFull(login, out message))
            {
                return true;
            }
            else message = "Login: " + message;
            return false;

        }
    }
}
