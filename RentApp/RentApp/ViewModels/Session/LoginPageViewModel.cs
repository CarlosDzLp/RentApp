using System;
using System.Windows.Input;
using RentApp.Font;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        #region Properties
        public string Email { get; set; }

        public bool IsPassword { get; set; } = true;

        public string Password { get; set; }


        public ImageSource Img { get; set; }

        #endregion

        #region Constructor
        public LoginPageViewModel( )
        {
            Img = new FontImageSource()
            {
                FontFamily = "Solid",
                Size = 20,
                Color = Color.Black,
                Glyph = FontAwesomeIcons.Show
            };
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
                Img = new FontImageSource()
                {
                    FontFamily = "Solid",
                    Size = 20,
                    Color = Color.Black,
                    Glyph = FontAwesomeIcons.Hide
                };
                band = 1;
            }
            else
            {
                IsPassword = true;
                Img = new FontImageSource()
                {
                    FontFamily = "Solid",
                    Size = 20,
                    Color = Color.Black,
                    Glyph = FontAwesomeIcons.Show
                };
                band = 0;
            }
        }

        private async void LogInCommandExecuted()
        {
            try
            {
                //ServiceClient client = new ServiceClient();
                //Show("Cargando...");
                //var authenticate = new AuthenticateModel();
                //authenticate.Email = Email;
                //authenticate.Password = Password;
                //var response = await client.Post<Response<UserModel>, AuthenticateModel>(authenticate,"user/userlogin");
                //Hide();
                //if(response != null)
                //{
                //    if(response.Result != null && response.Count > 0 )
                //    {
                //        DbContext.Instance.InsertUser(response.Result);
                //        if(response.Result.Type==0)
                //        {
                //            //usuario normal
                //            //await NavigationService.NavigateAsync("/MasterDetailUser/Navigation/HomeUser");
                //        }
                //        else
                //        {
                //            //arrendatario
                //            var responseCompany = await client.Get<Response<CompanyModel>>($"user/companylogin?IdCompany={response.Result.IdUser}");
                //            if(responseCompany != null && responseCompany.Result != null && responseCompany.Count > 0)
                //            {
                //                DbContext.Instance.InsertCompany(responseCompany.Result);
                //                //navegga a la pagina principal
                //                //await NavigationService.NavigateAsync("/MasterAdmin");
                //            }
                //            else
                //            {
                //                //await UserDialogsService.Snackbar("Hubo un error al conectar con el servidor, intente mas tarde", "", TypeSnackbar.Error);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        //await UserDialogsService.Snackbar(response.Message, "", TypeSnackbar.Error);
                //    }
                //}
                //else
                //{
                //    Snack("Hubo un error al conectar con el servidor, intente mas tarde", "", TypeSnackbar.Error);
                //}
            }
            catch(Exception ex)
            {
                Hide();
            }
        }

        private void ValidateUserRegisterCommandExecuted()
        {
            try
            {
                App.NavigationPage.Navigation.PushAsync(new Views.Session.ValidateEmailPage());
            }
            catch(Exception ex)
            {

            }
            
            //NavigationService.NavigateAsync("/Register");
            //await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new ValidateUserPopup());
        }
        #endregion
    }
}
