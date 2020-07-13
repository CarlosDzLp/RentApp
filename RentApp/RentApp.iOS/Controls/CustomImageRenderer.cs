using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using RentApp.Controls;
using RentApp.iOS.Controls;
using UIKit;
using System.ComponentModel;

[assembly:ExportRenderer(typeof(CustomImage),typeof(CustomImageRenderer))]
namespace RentApp.iOS.Controls
{
    public class CustomImageRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var custom = Element as CustomImage ;
                //Control.Image = Control.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = custom.TintColorImage.ToUIColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var custom = Element as CustomImage;
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName==CustomImage.TintColorImageProperty.PropertyName)
            {
                //Control.Image = Control.Image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = custom.TintColorImage.ToUIColor();
            } 
        }
    }
}
