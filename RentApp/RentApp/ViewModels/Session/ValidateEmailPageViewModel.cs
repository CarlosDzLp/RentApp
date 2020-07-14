using System;
using System.Windows.Input;
using RentApp.Font;
using RentApp.Helpers;
using RentApp.Models.Response;
using RentApp.Models.Users;
using RentApp.Service;
using RentApp.ViewModels.Base;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class ValidateEmailPageViewModel : BindableBase
    {
        ServiceClient client = new ServiceClient();
        #region Properties
        public Color TintColor { get; set; }
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    SetProperty(ref email, value);
                    ValidateEmail();
                }
            }
        }
        public string Img { get; set; }

        public bool ActiveButton { get; set; }
        #endregion

        #region Constructor
        public ValidateEmailPageViewModel()
        {
            TintColor = Color.Black;
            Img = FontAwesomeIcons.Close;
#if DEBUG
            Email = "ryankar90@hotmail.com";
#endif
        }
        #endregion

        #region Methods
        private void ValidateEmail()
        {
            if(!string.IsNullOrWhiteSpace(Email))
            {
                if (Validate.Email(Email))
                {
                    Img = FontAwesomeIcons.Done;
                    TintColor = Color.Green;
                    ActiveButton = true;
                }
                else
                {
                    Img = FontAwesomeIcons.Close;
                    TintColor = Color.Red;
                    ActiveButton = false;
                }
            }
            else
            {
                Img = FontAwesomeIcons.Close;
                TintColor = Color.Black;
                ActiveButton = false;
            }            
        }
        #endregion

        #region CommandExecuted
        public async void ValidateEmailCommandExecuted()
        {
            try
            {
                ActiveButton = false;
                if (!string.IsNullOrWhiteSpace(Email))
                {
                    if (Validate.Email(Email))
                    {
                        Img = FontAwesomeIcons.Done;
                        TintColor = Color.Green;

                        Show("Obteniendo datos");
                        var response = await client.Get<Response<UserModel>>($"rentapp/validateuser?user={Email}");
                        Hide();
                        ActiveButton = true;
                        if (response != null)
                        {
                            if(response.Result == null && response.Count == 0)
                            {
                                //aqui se va a la otra pagina
                                await App.NavigationPage.Navigation.PushAsync(new Views.Session.RegisterUserPage(Email));
                            }
                            else
                            {
                                ActiveButton = true;
                                Snack("El correo ya esta en uso", "RentApp", TypeSnackbar.Error);
                            }
                        }
                        else
                        {
                            Toast("Ocurrio un error, intentelo mas tarde");
                        }
                    }
                    else
                    {
                        ActiveButton = false;
                        Img = FontAwesomeIcons.Close;
                        TintColor = Color.Red;
                    }
                }
                else
                {
                    ActiveButton = false;
                    Toast("Ingrese un correo");
                    Img = FontAwesomeIcons.Close;
                    TintColor = Color.Black;
                }
            }
            catch(Exception ex)
            {
                Hide();
                ActiveButton = false;
            }
        }
        #endregion
    }
}
