using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RentApp.Controls;
using RentApp.iOS.Controls;

[assembly:ExportRenderer(typeof(Entry),typeof(CustomEntryRenderer))]
namespace RentApp.iOS.Controls
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.Layer.CornerRadius = 0;
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
            Control.Layer.BorderWidth = 0;
            Control.ClipsToBounds = false;
        }
    }
}
