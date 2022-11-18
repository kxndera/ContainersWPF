using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SliderRGB.Converters
{
    class HexStringToRgbComponentConverter : IMultiValueConverter
    {
        private string[] byteToHexTable = { "0", "1", "2", "3", "4", "5", "6", "7",
            "8", "A", "B", "C", "D", "E", "F" };

        private Dictionary<string,double> hexToDoubleDictionary = new Dictionary<string, double>()
        {
            {"0", 0 }, {"1", 1 }, {"2", 2 }, {"3", 3 },
            {"4", 4 },{"5", 5 },{"6", 6 },{"7", 7 },
             {"8", 8 },{"9", 9 },{"A", 10 },{"B", 11 },
              {"C", 12 },{"D", 13 },{"E", 14 },{"F", 15 }
       };
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length != 3) return Binding.DoNothing;

            byte red = System.Convert.ToByte((double)values[0]);
            byte green = System.Convert.ToByte((double)values[1]);
            byte blue = System.Convert.ToByte((double)values[2]);

            string redHex = byteToHexTable[red/16] + byteToHexTable[red % 16];
            string greenHex = byteToHexTable[green/16] + byteToHexTable[green % 16];
            string blueHex = byteToHexTable[blue/16] + byteToHexTable[blue % 16];
            return redHex + greenHex + blueHex;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
           if(value == null)
                return new object[] {Binding.DoNothing, Binding.DoNothing, Binding.DoNothing};

            string hexStr = value.ToString().ToUpper().Trim();

            if (hexStr.Length != 6) return new object[] { Binding.DoNothing, Binding.DoNothing, Binding.DoNothing };

        }
    }
}
