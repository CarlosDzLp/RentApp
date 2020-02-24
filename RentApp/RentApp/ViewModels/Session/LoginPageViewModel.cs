using System;
using System.Windows.Input;
using RentApp.DataBase;
using RentApp.Helpers;
using RentApp.Models.Company;
using RentApp.Models.Response;
using RentApp.Models.Tokens;
using RentApp.Models.Users;
using RentApp.Service;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class LoginPageViewModel : BindableViewBase
    {
        #region Properties
        private string _email;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        private bool _isPassword = true;
        public bool IsPassword
        {
            get { return _isPassword; }
            set { SetProperty(ref _isPassword, value); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        private string _img = "ic_show";
        public string Img
        {
            get { return _img; }
            set { SetProperty(ref _img, value); }
        }

        #endregion

        #region Constructor
        public LoginPageViewModel( )
        {
            TapImgCommand = new Command(TapImgCommandExecuted);
            LogInCommand = new Command(LogInCommandExecuted);
            ValidateUserRegisterCommand = new Command(ValidateUserRegisterCommandExecuted);
        }

        
        #endregion

        #region Methods

        #endregion

        #region Command
        public ICommand TapImgCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand ValidateUserRegisterCommand { get; set; }
        #endregion

        #region CommandExecuted
        int band = 0;
        private void TapImgCommandExecuted()
        {
            if(band == 0)
            {
                IsPassword = false;
                Img = "ic_hide";
                band = 1;
            }
            else
            {
                IsPassword = true;
                Img = "ic_show";
                band = 0;
            }
        }

        private async void LogInCommandExecuted()
        {
            try
            {
                ServiceClient client = new ServiceClient();
                Show("Cargando...");
                var authenticate = new AuthenticateModel();
                authenticate.Email = Email;
                authenticate.Password = Password;
                var response = await client.Post<Response<UserModel>, AuthenticateModel>(authenticate,"user/userlogin");
                Hide();
                if(response != null)
                {
                    if(response.Result != null && response.Count > 0 )
                    {
                        DbContext.Instance.InsertUser(response.Result);
                        if(response.Result.Type==0)
                        {
                            //usuario normal
                            //await NavigationService.NavigateAsync("/MasterDetailUser/Navigation/HomeUser");
                        }
                        else
                        {
                            //arrendatario
                            var responseCompany = await client.Get<Response<CompanyModel>>($"user/companylogin?IdCompany={response.Result.IdUser}");
                            if(responseCompany != null && responseCompany.Result != null && responseCompany.Count > 0)
                            {
                                DbContext.Instance.InsertCompany(responseCompany.Result);
                                //navegga a la pagina principal
                                //await NavigationService.NavigateAsync("/MasterAdmin");
                            }
                            else
                            {
                                //await UserDialogsService.Snackbar("Hubo un error al conectar con el servidor, intente mas tarde", "", TypeSnackbar.Error);
                            }
                        }
                    }
                    else
                    {
                        //await UserDialogsService.Snackbar(response.Message, "", TypeSnackbar.Error);
                    }
                }
                else
                {
                    Snack("Hubo un error al conectar con el servidor, intente mas tarde", "", TypeSnackbar.Error);
                }
            }
            catch(Exception ex)
            {
                Hide();
            }
        }

        private void ValidateUserRegisterCommandExecuted()
        {
            App.NavigationPage.Navigation.PushAsync(new Views.Session.RegisterPage());
            //NavigationService.NavigateAsync("/Register");
            //await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new ValidateUserPopup());
        }
        #endregion
    }
}
