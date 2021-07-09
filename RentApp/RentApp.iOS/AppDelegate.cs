using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using RentApp.Helpers;
using RentApp.iOS.Helpers;
using UIKit;
using Xamarin.Forms.GoogleMaps.iOS;

namespace RentApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUIApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            var platformConfig = new PlatformConfig
            {
                ImageFactory = new CachingImageFactory()
            };

            Xamarin.FormsGoogleMaps.Init(ApiKeys.GOOGLE_MAPS_IOS_API_KEY, platformConfig);
            LoadApplication(new App());
            return base.FinishedLaunching(app, options);

        }

        //private void ColorStatus(UIApplication app)
        //{
        //    try
        //    {
        //        if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
        //        {
        //            var Window = new UIWindow(UIScreen.MainScreen.Bounds)
        //            {
        //                RootViewController = new UIViewController()
        //            };
        //            Window.MakeKeyAndVisible();
        //            var statusBar = new UIView(UIApplication.SharedApplication.StatusBarFrame)
        //            {
        //                BackgroundColor = ColorHelper.FromHex("#F4374D"),
        //                TintColor = UIColor.White,
        //            };
        //            app.Delegate.GetWindow().AddSubview(statusBar);
        //        }
        //        else
        //        {
        //            var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBarWindow")).ValueForKey(new NSString("statusBar")) as UIView;
        //            statusBar.BackgroundColor = ColorHelper.FromHex("#F4374D");
        //            statusBar.TintColor = UIColor.White;
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //}
    }
}
