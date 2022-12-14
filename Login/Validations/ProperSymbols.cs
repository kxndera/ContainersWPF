using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Validations
{
    class ProperSymbols
    {
       
        public static bool ContainsProperSymbols(string password, out string message)
        {
            char[] digits = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] lowercase = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] uppercase = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] specialSymbols = { '!', '@', '#', '$', '%', '^', '&', '*', '?', '<', '>' };

            if (!password.ToCharArray().Any(k => lowercase.Contains(k)))
            {
                message = "hasło nie zawiera małych liter";
                return false;
            }
            else

            if (!password.ToCharArray().Any(k => uppercase.Contains(k)))
            {
                message = "hasło nie zawiera dużych liter";
                return false;
            }
            if (!password.ToCharArray().Any(k => digits.Contains(k)))
            {
                message = "hasło nie zawiera cyfr";
                return false;
            }
            if (!password.ToCharArray().Any(k => specialSymbols.Contains(k)))
            {
                message = "hasło nie zawiera znaków specjalnych";
                return false;
            }
            else message = "";
            return true;
        }
    }
}
