using RentApp.Helpers;
using RentApp.ViewModels.Base;
using RentApp.Views.Session;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class RegisterAdminPageViewModel : BindableViewBase
    {
        #region Properties
        private string Email { get; set; }
        private byte[] _photo;
        public byte[] Photo
        {
            get { return _photo; }
            set { SetProperty(ref _photo, value); }
        }
        #endregion

        #region Constructor
        public RegisterAdminPageViewModel( )
        {
            LoadPhotoCommand = new Command(LoadPhotoCommandExecuted);
            LocationCommad = new Command(LocationCommadExecuted);
        }
        #endregion

        #region Command
        public Command LoadPhotoCommand { get; set; }
        public Command LocationCommad { get; set; }
        #endregion


        #region CommandExecuted
        private async void LoadPhotoCommandExecuted()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                var result =  await BottomSheet();
                if(!string.IsNullOrWhiteSpace(result))
                {
                    if(result == "Galeria")
                    {
                        var status = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Storage);
                        if (status)
                        {
                            Photo = await PhotoCamera.PickPhoto();
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        var status = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Camera);
                        if (status)
                        {
                            Photo = await PhotoCamera.TakePhoto();
                        }
                        else
                        {

                        }
                    }
                }
            }
            else
            {
                string action = await App.Current.MainPage.DisplayActionSheet("Que desea hacer", "Cancelar", "Galeria", "Tomar Foto");
                if (action == "Galeria")
                {
                    var status = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Storage);
                    if (status)
                    {
                        Photo = await PhotoCamera.PickPhoto();
                    }
                    else
                    {
                    }
                }
                else if (action == "Tomar Foto")
                {
                    var status = await Utils.PermissionsStatus(Plugin.Permissions.Abstractions.Permission.Camera);
                    if (status)
                    {
                        Photo = await PhotoCamera.TakePhoto();
                    }
                    else
                    {

                    }
                }
            }
        }
        private void LocationCommadExecuted()
        {
            //NavigationService.NavigateAsync(nameof(LocationPage), useModalNavigation: true, animated: true);
        }
        #endregion

        
    }
}
