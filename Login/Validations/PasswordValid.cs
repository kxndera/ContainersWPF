using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Validations
{
    internal class PasswordValid
    {   
        public static bool ValidationOfPassword(string password, out string message)
        {
            if (ValueFull.IsValueFull(password, out message) &&
               RightPassword.CheckPasswordLengthIsRight(password, out message)
                && ProperSymbols.ContainsProperSymbols(password, out message))
            {
                return true;
            }
            else message = "Hasło: " + message;
            return false;
        }

    }
}
