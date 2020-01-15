using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FormsToolkit;
using RentApp.Helpers;

namespace RentApp.Droid
{
    [Activity(Label = "RentApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            FormsToolkit.Droid.Toolkit.Init();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            MessagingService.Current.Subscribe<bool>(MessageKeys.StatusBar, (args, sender) =>
            {
                if (sender)
                {
                    setLightStatusBar(this, Android.Graphics.Color.Transparent);
                }
                else
                {
                    ClearLightStatusBar(this, Android.Graphics.Color.ParseColor("#0CB392"));
                }
            });
        }

        public void setLightStatusBar(Activity activity, Android.Graphics.Color color)
        {
            int flags = (int)activity.Window.DecorView.SystemUiVisibility; // get current flag
            flags |= (int)SystemUiFlags.LightStatusBar;   // add LIGHT_STATUS_BAR to flag
            activity.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)flags;
            activity.Window.SetStatusBarColor(color);
        }
        public void ClearLightStatusBar(Activity activity, Android.Graphics.Color color)
        {
            int newUiVisibility = (int)activity.Window.DecorView.SystemUiVisibility;
            newUiVisibility &= ~(int)Android.Views.SystemUiFlags.LightStatusBar;
            activity.Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)newUiVisibility;
            activity.Window.SetStatusBarColor(color);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}