using System;
using System.Windows.Input;
using RentApp.DataBase;
using RentApp.Font;
using RentApp.Helpers;
using RentApp.Models.Response;
using RentApp.Models.Tokens;
using RentApp.Models.Users;
using RentApp.Service;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class LoginPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();
        #region Properties
        public string Email { get; set; }

        public bool IsPassword { get; set; } = true;

        public string Password { get; set; }


        public ImageSource Img { get; set; }

        #endregion

        #region Constructor
        public LoginPageViewModel( )
        {
#if DEBUG
            Email = "ryankar90@hotmail.com";
            Password = "1234567890";
#endif

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
                Show("Cargando...");
                var authenticate = new AuthenticateModel();
                authenticate.User = Email;
                authenticate.Password = Password;
                var serializer = Newtonsoft.Json.JsonConvert.SerializeObject(authenticate);
                var response = await client.Post<Response<UserModel>>(serializer, "rentapp/login");
                Hide();
                if(response != null)
                {
                    if(response.Result != null && response.Count > 0 )
                    {
                        DbContext.Instance.InsertUser(response.Result);
                        App.Current.MainPage = App.Navigation(new Views.Principal.MasterPage());
                    }
                    else
                    {
                        Toast(response.Message);
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
            try
            {
                App.NavigationPage.Navigation.PushAsync(new Views.Session.ValidateEmailPage());
            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
