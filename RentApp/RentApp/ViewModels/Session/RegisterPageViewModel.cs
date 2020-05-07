using System;
using System.Windows.Input;
using RentApp.Helpers;
using RentApp.Models.Response;
using RentApp.Models.Tokens;
using RentApp.Service;
using RentApp.ViewModels.Base;
using RentApp.Views.Session;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class RegisterPageViewModel : BindableViewBase
    {
        #region Properties
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if(_email != value)
                {
                    SetProperty(ref _email, value);
                    OnValidateEmail();  
                }               
            }
        }

        private string _img;
        public string Img
        {
            get { return _img; }
            set { SetProperty(ref _img, value); }
        }

        private Color _tintColor;
        public Color TintColor
        {
            get { return _tintColor; }
            set { SetProperty(ref _tintColor, value); }
        }

        #endregion

        #region Constructor
        public RegisterPageViewModel()
        {
            ValidateEmailCommand = new Command(ValidateEmailCommandExecuted);
        }
        #endregion

        #region Methods
        private void OnValidateEmail()
        {
            if(!string.IsNullOrWhiteSpace(Email))
            {
                var valid = ValidateEmail.IsEmail(Email);
                if(valid)
                {
                    Img = "ic_done";
                    TintColor = Color.Green;
                }
                else
                {
                    Img = "ic_error";
                    TintColor = Color.Red;
                }
            }
            else
            {
                Img = string.Empty;
            }
        }
        #endregion

        #region Command
        public ICommand ValidateEmailCommand { get; set; }
        #endregion

        #region CommandExecuted
        
        private async void ValidateEmailCommandExecuted()
        {
            ServiceClient client = new ServiceClient();
            if (!string.IsNullOrWhiteSpace(Email))
            {
                var valid = ValidateEmail.IsEmail(Email);
                if (valid)
                {
                    Show("Validando datos....");
                    Img = "ic_done";
                    TintColor = Color.Green;
                    var validate = new AuthenticateModel();
                    validate.Email = Email;
                    var response = await client.Post<Response<bool>, AuthenticateModel>(validate, "user/uservalidateemail");
                    Hide();
                    if(response != null)
                    {
                        if(response.Result && response.Count > 0)
                        {
                            Snack($"El correo {Email} ya existe en RentApp", "Error", TypeSnackbar.Error);
                        }
                        else
                        {
                            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new ValidateUserPopup(Email));
                        }
                    }
                    else
                    {
                        Snack("Intente mas tarde el servidor no respondio", "Error", TypeSnackbar.Error);
                    }
                }
                else
                {
                    Img = "ic_error";
                    TintColor = Color.Red;
                }
            }
            else
            {
                Img = string.Empty;
                Snack("Ingrese un correo", "Error", TypeSnackbar.Error);
            }
        }
        #endregion

        protected override void GoBackCommandExecuted()
        {
            try
            {
                App.NavigationPage.Navigation.PopToRootAsync();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
