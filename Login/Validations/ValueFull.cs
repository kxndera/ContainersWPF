using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Validations
{
    public class ValueFull
    {
        public static bool IsValueFull(string value, out string message)
        {
            message = "";
            if (string.IsNullOrWhiteSpace(value))
            {
                message = "Ciąg znaków jest pusty";
                return false;
            }
            else
                return true;
        }

        
    }
}
