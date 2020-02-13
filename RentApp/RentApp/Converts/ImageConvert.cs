using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace RentApp.Converts
{
    public class ImageConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var result = "http://shopping.carlosdiaz.com.elpumavp.arvixevps.com" + value.ToString();
                return result;
            }
            else
            {
                return "picture";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
