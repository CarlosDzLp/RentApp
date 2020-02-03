using Android.Content;
using Android.Support.V7.Widget;
using Plugin.CurrentActivity;
using RentApp.Controls;
using RentApp.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationViewPage), typeof(CustonNavigationPageRenderer))]
namespace RentApp.Droid.Controls
{
    public class CustonNavigationPageRenderer : NavigationPageRenderer
    {
        public CustonNavigationPageRenderer(Context context) : base(context)
        {
        }
        private NavigationViewPage navigationview;
        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;

            navigationview = (NavigationViewPage)e.NewElement;
        }


        private Android.Support.V7.Widget.Toolbar _toolbar;

        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);

            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                _toolbar = (Android.Support.V7.Widget.Toolbar)child;
                if(navigationview.IsShadow)
                {
                    _toolbar.SetElevation(10);
                    _toolbar.Elevation = 10;
                } 
            }
        } 
    }
}
