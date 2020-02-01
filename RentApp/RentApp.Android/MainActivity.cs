using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;
using FormsToolkit;
using RentApp.Helpers;
using Plugin.CurrentActivity;
using Prism;
using Prism.Ioc;
using RentApp.Droid.Helpers;

namespace RentApp.Droid
{
    [Activity(Label = "RentApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        static Dialogs dial = new Dialogs();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            FormsToolkit.Droid.Toolkit.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(new AndroidInitializer()));
            MessagingService.Current.Subscribe<MessageKeys>("StatusBar", (args, sender) =>
            {
                if (sender.StatusBarTransparent)
                {
                    setLightStatusBar(this, Android.Graphics.Color.White);
                }
                else
                {
                    ClearLightStatusBar(this,sender.ColorHex);
                }
            });
        }

        public class AndroidInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                containerRegistry.RegisterInstance<IDialogs>(dial);
            }
        }

        public void setLightStatusBar(Activity activity, Android.Graphics.Color color)
        {
            int flags = (int)activity.Window.DecorView.SystemUiVisibility; // get current flag
            flags |= (int)SystemUiFlags.LightStatusBar;   // add LIGHT_STATUS_BAR to flag
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)flags;
            activity.Window.SetStatusBarColor(color);
        }
        public void ClearLightStatusBar(Activity activity, string colorHex)//Android.Graphics.Color color)
        {
            int newUiVisibility = (int)activity.Window.DecorView.SystemUiVisibility;
            newUiVisibility &= ~(int)Android.Views.SystemUiFlags.LightStatusBar;
            activity.Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)newUiVisibility;
            activity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(colorHex));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}