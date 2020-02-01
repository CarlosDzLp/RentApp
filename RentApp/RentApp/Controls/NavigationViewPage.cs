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
    }
}
