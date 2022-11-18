using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ConvertersWPFApp.COnverters
{
    class BoolToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          if(value is bool)
            {
                bool convertedBool = (bool)value;
                if (convertedBool == true)
                    return "Kontrolka zaznaczona";
                else
                    return "Kontrolka niezaznaczona";
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

       
    }

