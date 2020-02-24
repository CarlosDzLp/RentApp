using System;
using System.Collections.Generic;
using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class ValidateUserPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ValidateUserPopup(string email)
        {
            InitializeComponent();
            this.BindingContext = new ValidateUserPopupViewModel(email);
        }
    }
}
