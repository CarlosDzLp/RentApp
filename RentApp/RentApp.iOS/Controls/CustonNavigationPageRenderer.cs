using System;
using Xamarin.Forms;
using RentApp.Controls;
using RentApp.iOS.Controls;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using UIKit;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(NavigationViewPage), typeof(CustonNavigationPageRenderer))]
namespace RentApp.iOS.Controls
{
    public class CustonNavigationPageRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (this.Element == null) return;
            var custom = (NavigationViewPage)e.NewElement;
            if (custom.IsShadow)
            {
                NavigationBar.Layer.ShadowColor = UIColor.Gray.CGColor;
                NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
                NavigationBar.Layer.ShadowOpacity = 1;
            }
        }
    }
}
