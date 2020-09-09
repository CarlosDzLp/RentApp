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
        public string Password { get; set; }

        public Color ColorEmail { get; set; } = Color.FromHex("#D1D1D1");
        public Color ColorPassword { get; set; } = Color.FromHex("#D1D1D1");
        #endregion

        #region Constructor
        public LoginPageViewModel( )
        {
#if DEBUG
            //Email = "ryankar90@hotmail.com";
            //Password = "1234567890";
#endif
            LogInCommand = new Command(LogInCommandExecuted);
            RegisterCommand = new Command(RegisterCommandExecuted);
        }

        
        #endregion

        #region Methods

        #endregion

        #region Command
        public ICommand LogInCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void LogInCommandExecuted()
        {
            try
            {
                if(string.IsNullOrWhiteSpace(Email))
                {
                    ColorEmail = Color.Red;
                    return;
                }
                else
                    ColorEmail = Color.FromHex("#E3E3E3");
                if(string.IsNullOrWhiteSpace(Password))
                {
                    ColorPassword = Color.Red;
                    return;
                }
                else
                    ColorPassword = Color.FromHex("#E3E3E3");

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

        private void RegisterCommandExecuted()
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
