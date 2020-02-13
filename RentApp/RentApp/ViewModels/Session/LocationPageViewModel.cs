using System;
using Prism.Navigation;
using Prism.Commands;
using RentApp.Helpers;
using RentApp.ViewModels.Base;

namespace RentApp.ViewModels.Session
{
    public class LocationPageViewModel : BindableViewBase
    {
        #region Constructor
        public LocationPageViewModel(INavigationService navigationService, IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            CloseCommand = new DelegateCommand(CloseCommandExecuted);
        }
        #endregion

        #region Command
        public DelegateCommand CloseCommand { get; set; }
        #endregion

        #region CommandExecuted
        private void CloseCommandExecuted()
        {
            NavigationService.GoBackAsync();
        }
        #endregion
    }
}
