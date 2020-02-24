using System;
using System.Collections.Generic;
using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class RegisterAdminPage : ContentPage
    {
        public RegisterAdminPage()
        {
            InitializeComponent();
            this.BindingContext = new RegisterAdminPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}
