using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using RentApp.Helpers;
using RentApp.ViewModels.Base;

namespace RentApp.ViewModels.Session
{
    public class RegisterUserPageViewModel : BindableViewBase
    {
        #region Properties
        private string Email { get; set; }
        #endregion
        #region Constructor
        public RegisterUserPageViewModel(INavigationService navigationService, IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            LocationCommad = new DelegateCommand(LocationCommadExecuted);
        }
        #endregion

        #region Command
        public ICommand LocationCommad { get; set; }
        #endregion

        #region CommandExecuted
        private void LocationCommadExecuted()
        {

        }
        #endregion


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Email = parameters["Email"] as string;
            base.OnNavigatedTo(parameters);
        }
    }
}
