using System.Collections.ObjectModel;
using FormsToolkit;
using RentApp.Helpers;
using RentApp.Models.Presentations;
using RentApp.ViewModels.Presentation;
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
            this.BindingContext = new CarouselPageViewModel();
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
                                       
                }
                else
                {
                    MessagingService.Current.SendMessage<MessageKeys>("StatusBar", new MessageKeys { StatusBarTransparent = false, ColorHex = item.ColorHex });
                }
            }    
        }
    }
}
