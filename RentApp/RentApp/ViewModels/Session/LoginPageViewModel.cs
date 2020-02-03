using System;
using System.Threading.Tasks;
using System.Windows.Input;
using RentApp.ViewModels.Base;
using Xamarin.Forms;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using RentApp.Helpers;
using RentApp.Service;

namespace RentApp.ViewModels.Session
{
    public class LoginPageViewModel : BindableViewBase
    {
        private IServiceClient _serviceClient;
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
        public LoginPageViewModel(INavigationService navigationService, IServiceClient serviceClient , IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            _serviceClient = serviceClient;
            TapImgCommand = new DelegateCommand(TapImgCommandExecuted);
            LogInCommand = new DelegateCommand(LogInCommandExecuted);
        }
        #endregion

        #region Methods

        #endregion

        #region Command
        public ICommand TapImgCommand { get; set; }
        public ICommand LogInCommand { get; set; }
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
            await UserDialogsService.Show("Cargando...");
            var guid = Guid.NewGuid();
            var response = await _serviceClient.Get<string>($"user/companylogin?IdCompany={guid}");
            await UserDialogsService.Hide();
            await NavigationService.NavigateAsync("/MasterUser");
        }
        #endregion
    }
}
