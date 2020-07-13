using System;
using Xamarin.Forms;
using RentApp.Controls;
using RentApp.iOS.Controls;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using UIKit;
using System.ComponentModel;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

[assembly: ExportRenderer(typeof(Xamarin.Forms.NavigationPage), typeof(CustonNavigationPageRenderer))]
namespace RentApp.iOS.Controls
{
    public class CustonNavigationPageRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            //if (this.Element == null) return;
            //var custom = (NavigationViewPage)e.NewElement;
            //if (custom.IsShadow)
            //{
            //    NavigationBar.Layer.ShadowColor = UIColor.Gray.CGColor;
            //    NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
            //    NavigationBar.Layer.ShadowOpacity = 1;
            //}
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (Element is Xamarin.Forms.NavigationPage navigationPage)
            {
                if (navigationPage.OnThisPlatform().HideNavigationBarSeparator())
                {

                    if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
                    {
                        NavigationBar.StandardAppearance.ShadowColor = null;
                        //NavigationBar.ScrollEdgeAppearance.ShadowColor = null;
                    }
                    else
                    {
                        NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
                        NavigationBar.ShadowImage = new UIImage();
                    }
                }
            }
        }
    }
}
