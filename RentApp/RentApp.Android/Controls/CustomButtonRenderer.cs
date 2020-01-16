using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using RentApp.Controls;
using RentApp.Droid.Controls;
using Android.Content;

[assembly:ExportRenderer(typeof(Button),typeof(CustomButtonRenderer))]
namespace RentApp.Droid.Controls
{
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                var button = (CustomButton)e.NewElement;
                Control.SetAllCaps(button.IsCapital);
            }
        }
    }
}
