using System;
using Xamarin.Forms;

namespace RentApp.Controls
{
    public class ImageGifs : Image
    {
        public static readonly BindableProperty ImgProperty = BindableProperty.Create(nameof(Img), typeof(string), typeof(ImageGifs), default(string));
        public string Img
        {
            get { return (string)GetValue(ImgProperty); }
            set { SetValue(ImgProperty, value); }
        }
    }
}
