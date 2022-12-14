using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Validations
{
    internal class RightPassword
    {
        public static bool CheckPasswordLengthIsRight(string password, out string message)
        {
            if (password.Length < 7)
            {
                message = "podano za mało znaków / min 8";
                return false;
            }
            else message = "";
            return true;
        }
    }
}
