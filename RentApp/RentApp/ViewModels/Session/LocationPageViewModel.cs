using RentApp.Helpers;
using RentApp.ViewModels.Base;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class LocationPageViewModel : BindableViewBase
    {
        #region Properties
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        #endregion

        #region Constructor
        public LocationPageViewModel()
        {
            CloseCommand = new Command(CloseCommandExecuted);
            //GetLocationNameCommand = new DelegateCommand<Position>( (param) =>   GetLocationName(param));
            //GetLocationCommand = new DelegateCommand(GetLocationCommandExecuted);
        }
        #endregion

        #region Command
        public Command CloseCommand { get; set; }
        //public DelegateCommand<Position> GetLocationNameCommand { get; set; }
        public Command GetLocationCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void CloseCommandExecuted()
        {
            
        }
        private async void GetLocationCommandExecuted()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var location = await Geolocation.GetLocationAsync(request);
            if (location != null)
            {
                Longitude = location.Longitude;
                Latitude = location.Latitude;
                Snack($"Latitud:{Latitude},Longitud:{Longitude}", "Posicion", TypeSnackbar.Success);
            }
        }
        //private void GetLocationName(Position param)
        //{
            //Longitude = param.Longitude;
            //Latitude = param.Latitude;
            // UserDialogsService.Snackbar($"Latitud:{Latitude},Longitud:{Longitude}", "Posicion", TypeSnackbar.Success);
        //}
        #endregion
    }
}
