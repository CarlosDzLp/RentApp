using System;
using Xamarin.Forms;
using RentApp.Controls;
using RentApp.Droid.Controls;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Graphics;
using System.ComponentModel;

[assembly:ExportRenderer(typeof(CustomImage),typeof(CustomImageRenderer))]
namespace RentApp.Droid.Controls
{
    public class CustomImageRenderer : ImageRenderer
    {
        public CustomImageRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;

            var custom = (CustomImage) e.NewElement;
            var filter = new PorterDuffColorFilter(custom.TintColorImage.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.SetColorFilter(filter); 
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var custom = Element as CustomImage;
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomImage.TintColorImageProperty.PropertyName)
            {
                var filter = new PorterDuffColorFilter(custom.TintColorImage.ToAndroid(), PorterDuff.Mode.SrcIn);
                Control.SetColorFilter(filter);
            }
        }
    }
}
