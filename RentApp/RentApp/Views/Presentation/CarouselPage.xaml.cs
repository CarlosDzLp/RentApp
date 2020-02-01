using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FormsToolkit;
using RentApp.Helpers;
using RentApp.Models.Presentations;
using Xamarin.Forms;

namespace RentApp.Views.Presentation
{
    public partial class CarouselPage : ContentPage
    {      
        public CarouselPage()
        {
            InitializeComponent();
            LoadCarousel();
            App.NavigationViewPage.BarTextColor = Color.White;
            App.NavigationViewPage.BarBackgroundColor = Color.FromHex("#FF5733");
            if (Device.RuntimePlatform == Device.Android)
                NavigationPage.SetHasNavigationBar(this, false);
            TheCarousel.CurrentItemChanged += TheCarousel_CurrentItemChanged;
        }

        private void LoadCarousel()
        {
            var ListCarousel = new ObservableCollection<CarouselModel>();
            ListCarousel.Clear();
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "logo", ColorHex = "#FF5733", IsVisible = false }); ;
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "logo", ColorHex = "#5C8A1B", IsVisible = false });
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "logo", ColorHex = "#1B8A4A", IsVisible = false });
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "logo", ColorHex = "#1B4D8A", IsVisible = false });
            ListCarousel.Add(new CarouselModel { Title = "Hola mexico", Image = "logo", ColorHex = "#8A1B65", IsVisible = true });
            TheCarousel.ItemsSource = ListCarousel;
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
