using System;
using Xamarin.Forms;

namespace RentApp.Controls
{
    public class NavigationViewPage : NavigationPage
    {
        public NavigationViewPage(Page rootPage):base(rootPage)
        {
            App.NavigationViewPage = this;
            BarTextColor = Color.White;
        }

        public NavigationViewPage()
        {
            App.NavigationViewPage = this;
            BarTextColor = Color.White;
        }


        public static readonly BindableProperty IsShadowProperty = BindableProperty.Create(nameof(IsShadow), typeof(bool), typeof(NavigationViewPage), default(bool));
        public bool IsShadow
        {
            get { return (bool)GetValue(IsShadowProperty); }
            set { SetValue(IsShadowProperty, value); }
        }
    }
}
