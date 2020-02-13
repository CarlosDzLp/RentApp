using System;
using Prism.Navigation;
using RentApp.Helpers;
using RentApp.ViewModels.Base;

namespace RentApp.ViewModels.Principal.User
{
    public class UserMasterDetailPageDetailViewModel : BindableViewBase
    {
        #region Constructor
        public UserMasterDetailPageDetailViewModel(INavigationService navigationService, IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
        }
        #endregion

    }
}
