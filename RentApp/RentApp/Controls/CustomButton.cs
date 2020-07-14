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


        public static readonly BindableProperty TextColorDisabledProperty = BindableProperty.Create(nameof(TextColorDisabled), typeof(Color), typeof(CustomButton), default(Color));
        public Color TextColorDisabled
        {
            get { return (Color)GetValue(TextColorDisabledProperty); }
            set { SetValue(TextColorDisabledProperty, value); }
        }


        public static readonly BindableProperty BackgroundColorDisabledProperty = BindableProperty.Create(nameof(BackgroundColorDisabled), typeof(Color), typeof(CustomButton), default(Color));
        public Color BackgroundColorDisabled
        {
            get { return (Color)GetValue(BackgroundColorDisabledProperty); }
            set { SetValue(BackgroundColorDisabledProperty, value); }
        }
    }
}
