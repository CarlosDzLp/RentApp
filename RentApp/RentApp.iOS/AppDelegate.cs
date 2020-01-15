using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace RentApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {           
            global::Xamarin.Forms.Forms.Init();
            FormsToolkit.iOS.Toolkit.Init();
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);          
        }


        public void SetColor()
        {
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            UIApplication.SharedApplication.SetStatusBarHidden(false, false);
            UINavigationBar.Appearance.BarTintColor = UIColor.Black;
            //UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BackgroundColor = UIColor.Red;
        }
    }
}
