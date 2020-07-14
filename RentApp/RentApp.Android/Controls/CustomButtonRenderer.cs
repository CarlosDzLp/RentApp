using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using RentApp.Controls;
using RentApp.Droid.Controls;
using Android.Content;
using System.ComponentModel;

[assembly:ExportRenderer(typeof(Button),typeof(CustomButtonRenderer))]
namespace RentApp.Droid.Controls
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }
        CustomButton CustomButton = null;
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            CustomButton = e.NewElement as CustomButton;
            if(e.NewElement != null)
            {
                var button = (CustomButton)e.NewElement;
                Control.SetAllCaps(button.IsCapital);
                if (Control != null) SetColors();
            }
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
            if (args.PropertyName == nameof(Button.IsEnabled)) SetColors();
        }

        private void SetColors()
        {
            Control.SetTextColor(Element.IsEnabled ? Element.TextColor.ToAndroid() : CustomButton.TextColorDisabled.ToAndroid());
            Control.SetBackgroundColor(Element.IsEnabled ? Element.BackgroundColor.ToAndroid() : CustomButton.BackgroundColorDisabled.ToAndroid());
        }
    }
}
