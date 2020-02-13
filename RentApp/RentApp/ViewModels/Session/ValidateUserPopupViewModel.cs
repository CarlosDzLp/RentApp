using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using RentApp.Helpers;
using RentApp.ViewModels.Base;
using Rg.Plugins.Popup.Services;

namespace RentApp.ViewModels.Session
{
    public class ValidateUserPopupViewModel : BindableViewBase
    {
        private string Email { get; set; }
        #region Constructor
        public ValidateUserPopupViewModel(INavigationService navigationService, IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            ValidateUserCommand = new DelegateCommand(ValidateUserCommandExecuted);
            ValidateAdminCommand = new DelegateCommand(ValidateAdminCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand ValidateUserCommand { get; set; }
        public ICommand ValidateAdminCommand { get; set; }
        #endregion

        #region CommandExecuted
        private async void ValidateAdminCommandExecuted()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("Email", App.Email);
            App.Email = string.Empty;
            await NavigationService.NavigateAsync("RegisterAdminPage", animated: true, parameters: navParameters);
            await PopupNavigation.Instance.PopAllAsync(true);
        }

        private async void ValidateUserCommandExecuted()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("Email", App.Email);
            App.Email = string.Empty;
            await NavigationService.NavigateAsync("RegisterUserPage", animated: true,parameters: navParameters);
            await PopupNavigation.Instance.PopAllAsync(true);
        }
        #endregion
    }
}
