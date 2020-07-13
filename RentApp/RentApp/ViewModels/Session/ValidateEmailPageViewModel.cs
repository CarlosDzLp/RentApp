using System;
using System.Windows.Input;
using RentApp.Font;
using RentApp.Helpers;
using RentApp.Models.Response;
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
        #endregion

        #region Constructor
        public ValidateEmailPageViewModel()
        {
            TintColor = Color.Black;
            Img = FontAwesomeIcons.Close;

            ValidateEmailCommand = new Command(ValidateEmailCommandExecuted);
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
                }
                else
                {
                    Img = FontAwesomeIcons.Close;
                    TintColor = Color.Red;
                }
            }
            else
            {
                Img = FontAwesomeIcons.Close;
                TintColor = Color.Black;
            }            
        }
        #endregion

        #region Command
        public ICommand ValidateEmailCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void ValidateEmailCommandExecuted()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Email))
                {
                    if (Validate.Email(Email))
                    {
                        Img = FontAwesomeIcons.Done;
                        TintColor = Color.Green;

                        Show("Obteniendo datos");
                        var response = await client.Get<Response<string>>($"rentapp/validateuser?user={Email}");
                        Hide();
                        if(response != null)
                        {
                            if(response.Result == null && response.Count == 0)
                            {
                                //aqui se va a la otra pagina
                                await App.NavigationPage.Navigation.PushAsync(new Views.Session.RegisterUserPage(Email));
                            }
                            else
                            {
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
                        Img = FontAwesomeIcons.Close;
                        TintColor = Color.Red;
                    }
                }
                else
                {
                    Toast("Ingrese un correo");
                    Img = FontAwesomeIcons.Close;
                    TintColor = Color.Black;
                }
            }
            catch(Exception ex)
            {
                Hide();
            }
        }
        #endregion
    }
}
