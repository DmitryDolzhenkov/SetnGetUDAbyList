using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SetnGetAttribute
{
    public class CommonUtils
    {
        public static double ConvertToDouble(string koef_w)
        {
            double koef = 0;
            if (koef_w == string.Empty)
                return koef;
            char new_delimeter = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            char delimeter = '.';
            char another_delimeter = ',';
            if (koef_w.Contains(delimeter))
                koef_w = koef_w.Replace(delimeter, new_delimeter);
            else if (koef_w.Contains(another_delimeter))
                koef_w = koef_w.Replace(another_delimeter, new_delimeter);
            if (Double.TryParse(koef_w, out koef))
            {
                return koef;
            }
            else
            {
                return Double.MinValue;
            }
        }
    }
}
