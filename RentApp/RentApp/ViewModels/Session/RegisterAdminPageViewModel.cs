using System;
using Prism.Commands;
using Prism.Navigation;
using RentApp.Helpers;
using RentApp.ViewModels.Base;
using RentApp.Views.Session;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class RegisterAdminPageViewModel : BindableViewBase
    {
        IBottomSheet bottomSheet;
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
        public RegisterAdminPageViewModel(INavigationService navigationService,IBottomSheet bottomSheet ,IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            this.bottomSheet = bottomSheet;
            LoadPhotoCommand = new DelegateCommand(LoadPhotoCommandExecuted);
            LocationCommad = new DelegateCommand(LocationCommadExecuted);
        }
        #endregion

        #region Command
        public DelegateCommand LoadPhotoCommand { get; set; }
        public DelegateCommand LocationCommad { get; set; }
        #endregion


        #region CommandExecuted
        private async void LoadPhotoCommandExecuted()
        {
            if (Device.RuntimePlatform == Device.Android)
            {
                var result = await bottomSheet.Bottom();
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
            NavigationService.NavigateAsync(nameof(LocationPage), useModalNavigation: true, animated: true);
        }
        #endregion

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Email = parameters["Email"] as string;
            base.OnNavigatedTo(parameters);
        }
    }
}
