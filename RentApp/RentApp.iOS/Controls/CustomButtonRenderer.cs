using System;
using System.ComponentModel;
using RentApp.Controls;
using RentApp.iOS.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(CustomButton),typeof(CustomButtonRenderer))]
namespace RentApp.iOS.Controls
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        CustomButton CustomButton = null;
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            CustomButton = e.NewElement as CustomButton;
            if (Control != null) SetColors();
        }



        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
            if (args.PropertyName == nameof(Button.IsEnabled)) SetColors();
        }

        private void SetColors()
        {
            Control.SetTitleColor(Element.IsEnabled ? Element.TextColor.ToUIColor() : CustomButton.TextColorDisabled.ToUIColor(), Element.IsEnabled ? UIControlState.Normal : UIControlState.Disabled);
            Control.BackgroundColor = Element.IsEnabled ? Element.BackgroundColor.ToUIColor() : CustomButton.BackgroundColorDisabled.ToUIColor();
        }
    }
}
