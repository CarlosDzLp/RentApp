using System;
using Xamarin.Forms;

namespace RentApp.Controls
{
    public class CustomImage : Image
    {
        public static readonly BindableProperty TintColorImageProperty = BindableProperty.Create(nameof(TintColorImage), typeof(Color), typeof(CustomImage),default(Color));
        public Color TintColorImage
        {
            get { return (Color)GetValue(TintColorImageProperty); }
            set { SetValue(TintColorImageProperty, value); }
        }
    }
}
