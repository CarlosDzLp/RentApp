using System;
using Prism.Navigation;
using RentApp.DataBase;
using RentApp.Helpers;
using RentApp.Models.Company;
using RentApp.Models.Users;
using RentApp.ViewModels.Base;

namespace RentApp.ViewModels.Principal.Administrator
{
    public class AccountAdminPageViewModel : BindableViewBase
    {
        #region Properties
        private CompanyModel _company;
        public CompanyModel Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }

        private UserModel _user;
        public UserModel User
        {
            get { return _user; }
            set { SetProperty(ref _user, value); }
        }
        #endregion

        #region Constructor
        public AccountAdminPageViewModel(INavigationService navigationService, IDialogs userDialogsService) : base(navigationService, userDialogsService)
        {
            User = DbContext.Instance.GetUser();
            Company = DbContext.Instance.GetCompany();
        }
        #endregion

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }
    }
}
