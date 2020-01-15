using System;
using System.Collections.Generic;
using FormsToolkit;
using RentApp.Helpers;
using RentApp.ViewModels.Session;
using Xamarin.Forms;

namespace RentApp.Views.Session
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginPageViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingService.Current.SendMessage(MessageKeys.StatusBar, false);
        }
    }
}
