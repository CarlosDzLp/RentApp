using System;
using Xamarin.Forms;

namespace RentApp.Controls
{
    public class NavigationViewPage : NavigationPage
    {
        public NavigationViewPage(Page rootPage):base(rootPage)
        {
            App.NavigationViewPage = this;
            BarTextColor = Color.Black;
            BarBackgroundColor = Color.White;
            IsShadow = true;
        }

        public NavigationViewPage()
        {
            App.NavigationViewPage = this;
            BarTextColor = Color.Black;
            BarBackgroundColor = Color.White;
            IsShadow = true;
        }


        public static readonly BindableProperty IsShadowProperty = BindableProperty.Create(nameof(IsShadow), typeof(bool), typeof(NavigationViewPage), default(bool));
        public bool IsShadow
        {
            get { return (bool)GetValue(IsShadowProperty); }
            set { SetValue(IsShadowProperty, value); }
        }
    }
}
