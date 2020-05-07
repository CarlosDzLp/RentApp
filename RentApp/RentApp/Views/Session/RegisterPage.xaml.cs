using System;
using System.Collections.Generic;
using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            try
            {
                InitializeComponent();
                this.BindingContext = new RegisterPageViewModel();
                NavigationPage.SetHasNavigationBar(this, false);
            }
            catch(Exception ex)
            {

            }

        }
    }
}
