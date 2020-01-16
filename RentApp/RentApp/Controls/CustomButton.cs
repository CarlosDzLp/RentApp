using System;
using Xamarin.Forms;

namespace RentApp.Controls
{
    public class CustomButton : Button
    {
        public static readonly BindableProperty IsCapitalProperty = BindableProperty.Create(nameof(IsCapital), typeof(bool), typeof(CustomButton), default(bool));
        public bool IsCapital
        {
            get { return (bool)GetValue(IsCapitalProperty); }
            set { SetValue(IsCapitalProperty, value); }
        }
    }
}
