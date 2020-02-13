using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.Design.BottomNavigation;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using RentApp.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
namespace RentApp.Droid.Controls
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        Xamarin.Forms.TabbedPage tab;
        BottomNavigationView bottomNavi;
        public CustomTabbedPageRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            tab = e.NewElement as TabbedPage;
            base.OnElementChanged(e);

            if (!(GetChildAt(0) is ViewGroup layout))
                return;

            if (!(layout.GetChildAt(1) is BottomNavigationView bottomNavigationView))
                return;

            var topShadow = LayoutInflater.From(Context).Inflate(Resource.Layout.view_shadow, null);

            var layoutParams =
                new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.MatchParent, 15);
            layoutParams.AddRule(LayoutRules.Above, bottomNavigationView.Id);

            layout.AddView(topShadow, 2, layoutParams);
            bottomNavigationView.LabelVisibilityMode = LabelVisibilityMode.LabelVisibilityLabeled;
            bottomNavi = bottomNavigationView;

            if (e.NewElement != null)
            {
                bottomNavigationView.NavigationItemSelected += BottomNavigationItemSelected;
            }

            if (e.OldElement != null)
            {
                bottomNavigationView.NavigationItemSelected -= BottomNavigationItemSelected;
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            for (int i = 0; i < Element.Children.Count; i++)
            {
                var item = bottomNavi.Menu.GetItem(i);
                if (bottomNavi.SelectedItemId == item.ItemId)
                {
                    DrawLine(item);
                    break;
                }
            }
        }

        void BottomNavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            DrawLine(e.Item);
            this.OnNavigationItemSelected(e.Item);
        }

        void DrawLine(IMenuItem item)
        { 
            int lineWidth = 8;
            int itemHeight = bottomNavi.Height;
            var rest = System.Convert.ToInt32("-" + itemHeight);
            int itemWidth = (bottomNavi.Width / Element.Children.Count);
            int leftOffset = item.ItemId * itemWidth;
            int rightOffset = itemWidth * (Element.Children.Count - (item.ItemId + 1));
            GradientDrawable bottomLine = new GradientDrawable();
            bottomLine.SetShape(ShapeType.Line);
            bottomLine.SetStroke(lineWidth, tab.SelectedTabColor.ToAndroid());
            var layerDrawable = new LayerDrawable(new Drawable[] { bottomLine });
            layerDrawable.SetLayerInset(0, leftOffset, rest, rightOffset, 0);
            bottomNavi.SetBackground(layerDrawable);
        }
    }
}
