using System;
using System.Globalization;
using System.IO;
using RentApp.Font;
using Xamarin.Forms;

namespace RentApp.Converts
{
    public class ImageConvertBytes : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var file = value as byte[];
            if (file != null)
            {
                var result = ImageSource.FromStream(
                    () => new MemoryStream(file));
                return result;
            }
            else
            {
                return "user";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
