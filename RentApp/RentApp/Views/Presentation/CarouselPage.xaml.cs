using System.Collections.ObjectModel;
using FormsToolkit;
using RentApp.Helpers;
using RentApp.Models.Presentations;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace RentApp.Views.Presentation
{
    public partial class CarouselPage : ContentPage
    {      
        public CarouselPage()
        {
            InitializeComponent();
            App.NavigationViewPage.BarTextColor = Color.White;
            App.NavigationViewPage.BarBackgroundColor = Color.FromHex("#FF5733");
            App.NavigationViewPage.On<iOS>().SetHideNavigationBarSeparator(true);
            if (Device.RuntimePlatform == Device.Android)
                Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);
            TheCarousel.CurrentItemChanged += TheCarousel_CurrentItemChanged;
        }


        private void TheCarousel_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            var item = e.CurrentItem as CarouselModel;
            if(item != null)
            {
                if(Device.RuntimePlatform == Device.iOS)
                {
                    App.NavigationViewPage.BarTextColor = Color.White;
                    App.NavigationViewPage.BarBackgroundColor = Color.FromHex(item.ColorHex);                   
                }
                else
                {
                    MessagingService.Current.SendMessage<MessageKeys>("StatusBar", new MessageKeys { StatusBarTransparent = false, ColorHex = item.ColorHex });
                }
            }    
        }
    }
}
