using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class LocationPage : ContentPage
    {
        public LocationPage()
        {
            try
            {
                InitializeComponent();
                //mapgoogle.HeightRequest = App.ScreenHeight;
                //mapgoogle.WidthRequest = App.ScreenWidth;
                //mapgoogle.CameraChanged += Mapgoogle_CameraChanged;
                //mapgoogle.CameraMoveStarted += Mapgoogle_CameraMoveStarted;
                //mapgoogle.CameraMoving += Mapgoogle_CameraMoving;
                //Load();
            }
            catch(Exception ex)
            {

            }
        }

        

        private async void Load()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    //mapgoogle.MoveToRegion(MapSpan.FromCenterAndRadius(
                        //new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.3)));

                }
            }
            catch(Exception ex)
            {
            }
        }
    }
}
