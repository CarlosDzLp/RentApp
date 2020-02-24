using System;
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
        public AccountAdminPageViewModel()
        {
            User = DbContext.Instance.GetUser();
            Company = DbContext.Instance.GetCompany();
        }
        #endregion

    }
}
