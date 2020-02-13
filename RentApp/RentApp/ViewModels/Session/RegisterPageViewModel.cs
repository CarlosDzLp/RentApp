using System;
using System.Windows.Input;
using Prism.Navigation;
using RentApp.Helpers;
using Xamarin.Forms;
using RentApp.ViewModels.Base;
using Prism.Commands;
using RentApp.Service;
using RentApp.Models.Tokens;
using RentApp.Models.Response;
using RentApp.Views.Session;

namespace RentApp.ViewModels.Session
{
    public class RegisterPageViewModel : BindableViewBase
    {
        private IServiceClient ServiceClient;
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
        public RegisterPageViewModel(INavigationService navigationService, IServiceClient serviceClient , IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            this.ServiceClient = serviceClient;
            
            ValidateEmailCommand = new DelegateCommand(ValidateEmailCommandExecuted);
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
            if (!string.IsNullOrWhiteSpace(Email))
            {
                var valid = ValidateEmail.IsEmail(Email);
                if (valid)
                {
                    await UserDialogsService.Show("Validando datos....");
                    Img = "ic_done";
                    TintColor = Color.Green;
                    var validate = new AuthenticateModel();
                    validate.Email = Email;
                    var response = await ServiceClient.Post<Response<bool>, AuthenticateModel>(validate, "user/uservalidateemail");
                    await UserDialogsService.Hide();
                    if(response != null)
                    {
                        if(response.Result && response.Count > 0)
                        {
                            await UserDialogsService.Snackbar($"El correo {Email} ya existe en RentApp", "Error", TypeSnackbar.Error);
                        }
                        else
                        {
                            App.Email= Email;
                            await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new ValidateUserPopup());
                        }
                    }
                    else
                    {
                        await UserDialogsService.Snackbar("Intente mas tarde el servidor no respondio", "Error", TypeSnackbar.Error);
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
                await UserDialogsService.Snackbar("Ingrese un correo", "Error", TypeSnackbar.Error);
            }
        }
        #endregion
    }
}
