using System.Windows.Input;
using RentApp.ViewModels.Base;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace RentApp.ViewModels.Session
{
    public class ValidateUserPopupViewModel : BindableViewBase
    {
        private string Email { get; set; }
        #region Constructor
        public ValidateUserPopupViewModel(string email)
        {
            Email = email;
            ValidateUserCommand = new Command(ValidateUserCommandExecuted);
            ValidateAdminCommand = new Command(ValidateAdminCommandExecuted);
        }
        #endregion

        #region Command
        public ICommand ValidateUserCommand { get; set; }
        public ICommand ValidateAdminCommand { get; set; }
        #endregion

        #region CommandExecuted
        private  void ValidateAdminCommandExecuted()
        {
            //NavigationService.NavigateAsync("/RegisterAdmin", animated: true, parameters: navParameters);
            PopupNavigation.Instance.PopAllAsync(true);
        }

        private void ValidateUserCommandExecuted()
        {
            //NavigationService.NavigateAsync("/RegisterUser", animated: true,parameters: navParameters);
            PopupNavigation.Instance.PopAllAsync(true);
        }
        #endregion
    }
}
