using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TransmissionFluid.Converters
{
    public class HumanReadableSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            long byteCount = 0;
            int precision = 1;
            bool isPerSec = false;
            string suffix = "";

            if (parameter != null)
            {
                bool.TryParse(parameter.ToString(), out isPerSec);
                if (isPerSec)
                    suffix = "/s";
            }

            if (long.TryParse(value.ToString(), out byteCount) && byteCount >= 0)
            {
                string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
                if (byteCount == 0)
                    return "0" + " " + suf[0] + suffix;
                long bytes = Math.Abs(byteCount);
                int place = System.Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));

                if (isPerSec)
                    precision = 1;
                else if (place <= 2)
                    precision = 0;
                else
                    precision = 1;

                double num = Math.Round(bytes / Math.Pow(1024, place), precision);
                return (Math.Sign(byteCount) * num).ToString() + " " + suf[place] + suffix;
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
