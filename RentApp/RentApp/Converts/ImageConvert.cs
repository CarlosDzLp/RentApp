using System;
using System.Globalization;
using System.IO;
using RentApp.Font;
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
                ImageSource image = new FontImageSource()
                {
                    FontFamily = "Solid",
                    Size = 20,
                    Color = Color.Black,
                    Glyph = FontAwesomeIcons.User
                };
                return image;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
